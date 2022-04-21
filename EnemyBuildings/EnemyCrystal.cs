using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCrystal : MonoBehaviour
{
    public float EnemyCrystalLife = 200;
    public GameObject die;
    public GameObject Enemy3;
    public GameObject Enemy4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Slider").GetComponent<Slider>().maxValue = EnemyCrystalLife;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyCrystalLife;
        if (EnemyCrystalLife <= 0)
        {
            GameObject.Find("Control").GetComponent<PlayCtrl>().status = 2;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            GameObject.Find("Point3").transform.position = new Vector3(0, 100, 0);

            Destroy(gameObject);

        }
    }
}