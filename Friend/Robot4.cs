using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot4 : MonoBehaviour
{
    public float timegap = 1;
    public float time = 2;

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Update()
    {
        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);
        if(distance <= 20)
        {
            if(time>timegap)
            {
                if(GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife<100)
                {
                    GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife += 4;
                }
                else
                {
                    GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife = 100;
                }
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }            
        }
    }
}


