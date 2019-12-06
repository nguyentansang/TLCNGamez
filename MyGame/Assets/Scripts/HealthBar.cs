using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    Image heathBar;
    float maxH = 250f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        heathBar = GetComponent<Image>();
        health = maxH;
    }

    // Update is called once per frame
    void Update()
    {
        heathBar.fillAmount = health / maxH;
    }
}
