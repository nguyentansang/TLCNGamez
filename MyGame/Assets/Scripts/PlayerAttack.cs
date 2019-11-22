using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay;
    public bool hit = false;

    public Animator anim;

    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !hit)
        {
            hit = true;
            trigger.enabled = true;
            attackdelay = 0.7f;
        }

        if (hit)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                hit = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("hit", hit);
    }
}
