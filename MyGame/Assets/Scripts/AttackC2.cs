using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackC2 : MonoBehaviour
{
    public BossAI turret;
    public bool isLeft = false;
    public Player player;

    private void Awake()
    {
        turret = gameObject.GetComponentInParent<BossAI>();

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
