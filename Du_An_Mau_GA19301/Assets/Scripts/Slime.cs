using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isAlive = true;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!isAlive)
            return;

        Move();
        DetectPlayer();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        anim.SetBool("IsMoving", Mathf.Abs(rb.velocity.x) > Mathf.Epsilon);
    }

    void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            anim.SetTrigger("Attack");
            OnAttack();
        }
    }

    private void OnAttack()
    {
        if (!isAlive)
            return;
        Instantiate(bullet, gun.transform.position, transform.rotation);
    }
    public void TakeDamage()
    {
        if (!isAlive)
            return;

        isAlive = false;
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Die");
    }

    private void Die()
    {
        isAlive = false;
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        Destroy(gameObject, 1f); 
    }
}
