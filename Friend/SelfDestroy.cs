using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public int time = 10;
    void Start()
    {
        Invoke("Destroy",time);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
