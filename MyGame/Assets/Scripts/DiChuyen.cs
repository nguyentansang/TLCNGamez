using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiChuyen : MonoBehaviour
{
    public float moveSpeed=1;
    public float moveRange=3;

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
        transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));

        if (Vector3.Distance(oldPositon, obj.transform.position) > moveRange) {
            obj.transform.position = oldPositon;
        }
    }
}
