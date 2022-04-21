using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyRobot3",5);
    }

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector3.Distance(GameObject.Find("Tower1").transform.position, this.transform.position);
        if(distance1 <= 25)
        {
            GameObject.Find("Tower1").GetComponent<Tower1>().fire = false;
        }
        float distance2 = Vector3.Distance(GameObject.Find("Tower2").transform.position, this.transform.position);
        if(distance2 <= 25)
        {
            GameObject.Find("Tower2").GetComponent<Tower2>().fire = false;
        }
    }
    void DestroyRobot3()
    {
        GameObject.Find("Tower1").GetComponent<Tower1>().fire = true;
        GameObject.Find("Tower2").GetComponent<Tower2>().fire = true;
        GameObject.Find("PlayUI").transform.Find("Judge").gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
