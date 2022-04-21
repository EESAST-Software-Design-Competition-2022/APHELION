using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    void Start() 
    {
        Invoke("Destroy",6);
    }
    void Update()
    {
        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);

        if(distance<=4)
        {
            GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife -= 13;
            Destroy(gameObject);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
