using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat : MonoBehaviour
{
    public float speed = 30f, maxspeed = 3, jumpPow = 250f;
    //public float maxVelocity = 4f;

    private bool grounded;
    private Rigidbody2D r2;
    private Animator anim;
    GameObject obj;

    
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        jumpPow = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPow));
        }
        
    }
    
}
