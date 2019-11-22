using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 30f, maxspeed = 5, jumpPow, maxjump=9;
    public bool grounded = true, faceright = true;
    public int ourHealth, maxHealth=5;

    public Rigidbody2D r2;
    public Animator anim;
    // Start is called before the first frame update 
    void Start()
    {
        jumpPow = 300f;
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (grounded)
            {
                grounded = false;
                r2.AddForce(Vector2.up * jumpPow);
            }
        }
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if(r2.velocity.x > maxspeed)
        {
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }

        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);

        if (h>0 && !faceright)
        {
            Flip();
        }
        else if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        if (ourHealth <= 0)
        {
            Death();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("YellowFlash");
    }
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
    }

    //an tien va tien bien mat
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coins"))
        {
            Destroy(col.gameObject);

        }
    }
}
