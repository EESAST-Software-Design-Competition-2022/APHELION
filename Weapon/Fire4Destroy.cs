using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire4Destroy : MonoBehaviour
{
    public float lifetime4 = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime4);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}