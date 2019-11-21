using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heart : MonoBehaviour
{
    public Sprite[] Heartsprite;

    public Player player; // De goi bien tu ben Player.cs
    public Image Heartt;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.ourHealth > 5)
            player.ourHealth = 5;


        if (player.ourHealth < 0)
            player.ourHealth = 0;

        Heartt.sprite = Heartsprite[player.ourHealth];
    }
}
