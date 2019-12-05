using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public TurketAI turret;
    public bool isLeft = false;
    public Player player;

    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurketAI>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            if (isLeft)
                turret.Attack(false);

            else
                turret.Attack(true);
        }
    }
}
