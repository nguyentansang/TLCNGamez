using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiChuyen : MonoBehaviour
{
    public float moveSpeed=1;
    public float moveRange=2;
    public bool facingRight = true;
    private Vector3 oldPositon;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPositon = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(oldPositon, obj.transform.position)<= moveRange)
        {
            //obj.transform.position = oldPositon;
            transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
            //   facingRight = !facingRight;
            if (Vector3.Distance(oldPositon, obj.transform.position) > 1.7)
                flip();
        }
        else
        {
            transform.Translate(new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0));
            if (moveRange > 0)
                moveRange = moveRange - (1 * Time.deltaTime * moveSpeed);
            else
                moveRange = 2;
        //    facingRight = !facingRight;
           
        }
    }
    void flip() {
        //facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }
}
