using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private float attackCooldown = 1.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isAlive = true;
    private GameObject player;
    private float lastAttackTime = 0f;

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

        MoveTowardsPlayer();
        DetectPlayerAndAttack();
    }

    void MoveTowardsPlayer()
    {
        if (player == null)
            return;

        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        anim.SetBool("Move", Mathf.Abs(rb.velocity.x) > Mathf.Epsilon);
    }

    void DetectPlayerAndAttack()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                anim.SetTrigger("Attack");
                lastAttackTime = Time.time;
            }
        }
    }

    // This method is called by an animation event during the attack animation
    private void OnAttack()
    {
        if (!isAlive)
            return;

        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
    }

    public void TakeDamage()
    {
        if (!isAlive)
            return;

        isAlive = false;
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        StartCoroutine(DestroyAfterDelay(1f)); // Destroy the enemy after 1 second to allow the death animation to play
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}