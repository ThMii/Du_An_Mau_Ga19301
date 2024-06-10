using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Điều chỉnh hướng đạn dựa trên hướng của player
        Vector2 moveDirection = transform.right;
        if (transform.localScale.x < 0)
        {
            moveDirection = -transform.right; // Điều chỉnh hướng nếu player quay sang trái
        }

        rb.velocity = moveDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}