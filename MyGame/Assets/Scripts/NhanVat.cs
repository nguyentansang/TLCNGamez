using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat : MonoBehaviour
{
    public float jumpPower;
    public float movePower = 20f;
    public float maxVelocity = 4f;

    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;
    GameObject obj;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        jumpPower = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0)) {
        //    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower));
        //}
        PlayerWalkKeyBoard();
    }

    void PlayerWalkKeyBoard() {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal"); //A <- : -1 , D -> : 1

        if (h > 0) {
            if(vel < maxVelocity)
            {
                forceX = movePower;
            }
            Vector3 scale = transform.localScale;
            scale.x=1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h > 0) {
            if (vel < maxVelocity)
            {
                forceX = -movePower;
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpPower;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    void OnColliSionEnter2d(Collision2D target)
    {
        if(target.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}
