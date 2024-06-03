using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D myRigidbody;
        private BoxCollider2D bulletCollider;
        [SerializeField] private float bulletSpeed;


        private Player player;
        private float xSpeed;


        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            bulletCollider = GetComponent<BoxCollider2D>();
            player = FindObjectOfType<Player>();

            xSpeed = player.transform.localScale.x * bulletSpeed;
        }

        void Update()
        {
            myRigidbody.velocity = new Vector2(xSpeed, 0f);
        }


        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Enemy")
            {
                Destroy(col.gameObject);
            }
            Destroy(gameObject);
        }


        void OnCollisionEnter2D(Collision2D col)
        {
            Destroy(gameObject);
        }
    }
}