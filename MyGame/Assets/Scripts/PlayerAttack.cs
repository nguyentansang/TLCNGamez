using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay;
    public bool hit = false;
    public float bulletspeed = 20f;
    public float bullettimer;

    public Transform FireBall;
    public Animator anim;
    public GameObject bulletPrefab;
    public Collider2D trigger;
    public Player player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        player = gameObject.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !hit)
        {
            hit = true;
            trigger.enabled = true;
            attackdelay = 0.4f;
            Shoot();
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

    void Shoot() {
        if (player.faceright)
        {
            Vector2 direction = transform.right * bulletspeed;
            direction.Normalize();
            GameObject bulletclone;
            bulletclone = Instantiate(bulletPrefab, FireBall.position, FireBall.rotation);
            bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
        }
        if (player.faceright==false)
        {
            Vector2 direction = -transform.right * bulletspeed;
            direction.Normalize();
            GameObject bulletclone;
            bulletclone = Instantiate(bulletPrefab, FireBall.position, FireBall.rotation);
            bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
        }
    }
}
