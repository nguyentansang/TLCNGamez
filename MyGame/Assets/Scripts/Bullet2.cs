using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Start()
    {
           // rb.velocity = transform.right * speed;   
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("boss"))
            {
                col.SendMessageUpwards("Damage", 10);
            }
            Destroy(gameObject);
        }
    }
}
