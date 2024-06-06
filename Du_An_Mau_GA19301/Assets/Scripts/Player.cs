using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        Vector2 moveInput;
        Vector2 jumpInput;

        private float gravityScaleAtStart;

        //[SerializeField] private GameObject bullet;
        //[SerializeField] private GameObject gun;

        private Rigidbody2D rb;
        private Animator anim;
        private CapsuleCollider2D caps;
        private BoxCollider2D box;

        [SerializeField] float runSpeed = 10f;
        [SerializeField] float jumpSpeed = 10f;
        [SerializeField] private float climbSpeed = 10f;

        private bool isAlive = true;
        [SerializeField] private Vector2 deathVelocity = new Vector2(0f, 10f);


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            caps = GetComponent<CapsuleCollider2D>();
            gravityScaleAtStart = rb.gravityScale;
            box = GetComponent<BoxCollider2D>();
        }


        void Update()
        {
            if (!isAlive)
                return;

            Run();
            Flip();
            ClimbLadder();
            DieFromEnemy();
        }

        private void DieFromEnemy()
        {
            if (caps.IsTouchingLayers(LayerMask.GetMask("Enemy")) ||
                box.IsTouchingLayers(LayerMask.GetMask("Traps")))
            {
                isAlive = false;
                anim.SetTrigger("Death");
                rb.velocity = deathVelocity;
                FindObjectOfType<GameSession>().ProcessPlayerDeath();
            }
        }

        // void OnFire(InputValue value)
        //{
        // if (!isAlive)
        //return;
        // Instantiate(bullet, gun.transform.position, transform.rotation);
        // }
        void Flip()
        {
            bool havemove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
            if (havemove)
            {
                transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
            }
        }

        void OnMove(InputValue value)
        {
            if (!isAlive)
                return;
            moveInput = value.Get<Vector2>();
            Debug.Log(moveInput);
        }
        void OnJump(InputValue value)
        {
            if (!isAlive)
                return;

            if (!box.IsTouchingLayers(LayerMask.GetMask("Ground")))
                return;

            if (value.isPressed)
            {
                rb.velocity += new Vector2(0f, jumpSpeed);
            }
        }
        void Run()
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;

            bool isRunning = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

            if (isRunning)
            {
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }
        }
        void ClimbLadder()
        {
            if (!box.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                rb.gravityScale = gravityScaleAtStart;
                anim.SetBool("IsClimbing", false);
                return;
            }

            Vector2 climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
            rb.velocity = climbVelocity;
            rb.gravityScale = 0f;

            bool isPlayerMovementVertical = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
            anim.SetBool("IsClimbing", isPlayerMovementVertical);
        }
    }
}