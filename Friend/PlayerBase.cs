using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public float PlayerBaseLife = 500;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SliderBase").GetComponent<Slider>().maxValue = PlayerBaseLife;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("SliderBase").GetComponent<Slider>().value = PlayerBaseLife;
        if (PlayerBaseLife <= 0)
        {
            GameObject.Find("PlayUI").transform.Find("Over").gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
