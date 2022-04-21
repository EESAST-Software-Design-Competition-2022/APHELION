using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNum1 : MonoBehaviour
{
    void Update()
    {
        float num = GameObject.Find("Player").GetComponent<Fire>().rocketnum;
        gameObject.GetComponent<Text>().text = ""+num;
    }
}
