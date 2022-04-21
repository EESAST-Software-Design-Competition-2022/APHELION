using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNum3 : MonoBehaviour
{
    void Update()
    {
        float num = GameObject.Find("Player").GetComponent<Fire>().grenadenum;
        gameObject.GetComponent<Text>().text = ""+num;
    }
}
