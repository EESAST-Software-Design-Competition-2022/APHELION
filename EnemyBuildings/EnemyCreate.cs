using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject enemy;
    public int gapTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", 0, gapTime);
    }

    void Create()
    {
        GameObject node = Instantiate(enemy, this.transform);
        node.transform.position = this.transform.position;
    }
}
