using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Self_Destroy : MonoBehaviour
{
    public float lifetime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    // Update is called once per frame
    private void Destroy()
    {
        Object.Destroy(this.gameObject);
    }
}
