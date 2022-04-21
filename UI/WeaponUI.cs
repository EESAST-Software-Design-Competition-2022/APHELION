using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var judge = GameObject.Find("Player").GetComponent<Fire>();


        if (judge.bullet_status == 0)
        {
            gameObject.transform.GetChild(4).transform.Find("Main1").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).transform.Find("Main1").gameObject.SetActive(false);
        }
        if (judge.bullet_status == 1)
        {
            gameObject.transform.GetChild(5).transform.Find("Dep1").transform.gameObject.SetActive(true);
        }
        else
        {          
            gameObject.transform.GetChild(5).transform.Find("Dep1").gameObject.SetActive(false);
        }

        if (judge.rocket_status == 0)
        {
            gameObject.transform.GetChild(4).transform.Find("Main2").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).transform.Find("Main2").gameObject.SetActive(false);
        }
        if (judge.rocket_status == 1)
        {
            gameObject.transform.GetChild(5).transform.Find("Dep2").gameObject.SetActive(true);
        }
        else
        {            
            gameObject.transform.GetChild(5).transform.Find("Dep2").gameObject.SetActive(false);
        }

        if (judge.arrow_status == 0)
        {
            gameObject.transform.GetChild(4).transform.Find("Main3").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).transform.Find("Main3").gameObject.SetActive(false);
        }
        if (judge.arrow_status == 1)
        {
            gameObject.transform.GetChild(5).transform.Find("Dep3").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(5).transform.Find("Dep3").gameObject.SetActive(false);
        }

        if (judge.grenade_status == 0)
        {
            gameObject.transform.GetChild(4).transform.Find("Main4").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).transform.Find("Main4").gameObject.SetActive(false);
        }
        if (judge.grenade_status == 1)
        {
            gameObject.transform.GetChild(5).transform.Find("Dep4").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(5).transform.Find("Dep4").gameObject.SetActive(false);
        }

        if (judge.scatter_status == 0)
        {
            gameObject.transform.GetChild(4).transform.Find("Main5").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).transform.Find("Main5").gameObject.SetActive(false);
        }
        if (judge.scatter_status == 1)
        {
            gameObject.transform.GetChild(5).transform.Find("Dep5").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(5).transform.Find("Dep5").gameObject.SetActive(false);
        }
    }
}
