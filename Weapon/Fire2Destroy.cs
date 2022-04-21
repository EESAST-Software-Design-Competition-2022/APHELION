using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2Destroy : MonoBehaviour
{
    public float lifetime2 = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime2);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
