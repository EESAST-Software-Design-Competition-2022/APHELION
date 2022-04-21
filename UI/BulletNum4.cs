using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNum4 : MonoBehaviour
{
    void Update()
    {
        float num = GameObject.Find("Player").GetComponent<Fire>().scatternum;
        gameObject.GetComponent<Text>().text = ""+num;
    }
}
