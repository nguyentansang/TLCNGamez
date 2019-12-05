using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Damage", 1);
            }
            Destroy(gameObject);
        }
  
    }
   
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
