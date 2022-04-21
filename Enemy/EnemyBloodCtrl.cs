using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBloodCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var camera = GameObject.Find("Camera");
        gameObject.transform.LookAt(camera.transform);
    }
}
