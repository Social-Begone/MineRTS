using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public Transform ts;
    Vector2 pos;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float startTimeBtwShots;
    private float timeBtwShots;
    private bool enemyVisible = false;
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        Health enemy = hitInfo.GetComponent<Health>();
        Transform enemy2 = hitInfo.GetComponent<Transform>();
        if (!enemy.team)
        {
            pos = enemy2.position - ts.position;
            transform.right = pos;
            enemyVisible = true;
        }
    }

    void Update()
    {
        if (enemyVisible) 
        { 
            enemyVisible = false;

            if (timeBtwShots <= 0)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
    
        }
    }
}