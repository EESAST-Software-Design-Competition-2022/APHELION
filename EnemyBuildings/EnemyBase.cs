using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public float EnemyBaseLife = 500;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = EnemyBaseLife;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyBaseLife;
        if(EnemyBaseLife<=0)
        {
            GameObject.Find("PlayUI").transform.Find("Win").gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
