using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Object.Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health enemy = hitInfo.GetComponent<Health>();
        if (!enemy.team)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}