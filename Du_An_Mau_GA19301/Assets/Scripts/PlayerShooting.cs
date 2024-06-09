using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (transform.localScale.x < 0)
        {
            // Nếu player quay sang trái
            bullet.transform.Rotate(0f, 180f, 0f);
            rb.velocity = -transform.right * bulletSpeed;
        }
        else
        {
            // Nếu player quay sang phải
            rb.velocity = transform.right * bulletSpeed;
        }
    }
}
