using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNum : MonoBehaviour
{
    void Update()
    {
        float num = GameObject.Find("Player").GetComponent<Fire>().bulletnum;
        gameObject.GetComponent<Text>().text = ""+num;
    }
}
