using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private float timer = 4;
    public GameObject ShootBall;


    void Update()
    {
        int shootStatus = GameObject.Find("Control").GetComponent<PlayCtrl>().status;

        if(shootStatus==1||shootStatus==2)
        {
            timer += Time.deltaTime;
            if(timer>3)
            {
                Shoot();
                timer = 0;
            }
        }
    }
    void Shoot()
    {
        GameObject node = Instantiate(ShootBall,null);
        float dx = Random.Range(-5,5);
        node.transform.position = gameObject.transform.position+new Vector3(dx,1,0);
    }
}
