using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCtrl : MonoBehaviour
{
    public int status = 0;

    void Update()
    {
        var enemyCreate = GameObject.Find("EnemyCreatePoint");
        if(status == 0)
        {
            enemyCreate.transform.GetChild(0).gameObject.SetActive(true);
            enemyCreate.transform.GetChild(1).gameObject.SetActive(false);
            enemyCreate.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(status == 1)
        {
            enemyCreate.transform.GetChild(0).gameObject.SetActive(false);
            enemyCreate.transform.GetChild(1).gameObject.SetActive(true);
            enemyCreate.transform.GetChild(2).gameObject.SetActive(false);
            Destroy(GameObject.Find("On1"));
        }
        if(status == 2)
        {
            enemyCreate.transform.GetChild(0).gameObject.SetActive(false);
            enemyCreate.transform.GetChild(1).gameObject.SetActive(false);
            enemyCreate.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(GameObject.Find("On2"));
        }
    }  
}
