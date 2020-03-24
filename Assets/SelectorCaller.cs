using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorCaller : MonoBehaviour
{
    public Collider2D selectCollider;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        UnitMovement enemy = hitInfo.GetComponent<UnitMovement>();
        Health enemy2 = hitInfo.GetComponent<Health>();
        if (enemy2.team)
        {
            enemy.isSelected = true;
        }
    }

    private void Update()
    {
        Destroy(gameObject, 0.4f);
    }
}
