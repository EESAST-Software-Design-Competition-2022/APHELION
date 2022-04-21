using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2 : MonoBehaviour
{    
    public float robotSpeed = 2f;
    public float robotDamage = 10f;
    public float enemyrotatespeed = 1f;

    public GameObject die;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("PlayUI").GetComponent<PlayerUI>().IsDead == false)
        anim.SetBool("walk", true);
        this.transform.Translate(Vector3.forward * robotSpeed * Time.deltaTime);
        {
            float distance1 = Vector3.Distance(GameObject.Find("Point1").transform.position, this.transform.position);
            float distance2 = Vector3.Distance(GameObject.Find("Point2").transform.position, this.transform.position);
            float distance3 = Vector3.Distance(GameObject.Find("Point3").transform.position, this.transform.position);
            float distance4 = Vector3.Distance(GameObject.Find("Point4").transform.position, this.transform.position);

            if (distance1 <= 20f)
            {
                Vector3 v3 = GameObject.Find("Tower1").transform.GetChild(4).transform.position - gameObject.transform.position;
                gameObject.transform.position += v3.normalized * robotSpeed * Time.deltaTime;
               
                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(GameObject.Find("Tower1").transform.GetChild(4).transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );                

                if (distance1 <= 4f)
                {
                    GameObject.Find("Tower1").GetComponent<Tower1>().tower1Life -= robotDamage;
                    GameObject dieEffect = Instantiate(die, null);
                    dieEffect.transform.position = this.transform.position;
                    Destroy(gameObject);
                }
            }
            if (distance2 <= 20f)
            {
                Vector3 v3 = GameObject.Find("Tower2").transform.GetChild(4).transform.position - gameObject.transform.position;
                gameObject.transform.position += v3.normalized * robotSpeed * Time.deltaTime;            

                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(GameObject.Find("Tower2").transform.GetChild(4).transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );

                if (distance2 <= 4f)
                {
                    GameObject.Find("Tower2").GetComponent<Tower2>().tower2Life -= robotDamage;
                    GameObject dieEffect = Instantiate(die, null);
                    dieEffect.transform.position = this.transform.position;                   
                    Destroy(gameObject);
                }
            }
            if (distance3 <= 10f)
            {
                Vector3 v3 = GameObject.Find("EnemyCrystal").transform.position - gameObject.transform.position;
                gameObject.transform.position += v3.normalized * robotSpeed * Time.deltaTime;
                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(GameObject.Find("EnemyCrystal").transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );

                if (distance3 <= 3f)
                {
                    GameObject.Find("EnemyCrystal").GetComponent<EnemyCrystal>().EnemyCrystalLife -= robotDamage;
                    GameObject dieEffect = Instantiate(die, null);
                    dieEffect.transform.position = this.transform.position;
                    Destroy(gameObject);
                }
            }
            if (distance4 <= 10f)
            {
                Vector3 v3 = GameObject.Find("EnemyBase").transform.position - gameObject.transform.position;
                gameObject.transform.position += v3.normalized * robotSpeed * Time.deltaTime;
                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(GameObject.Find("EnemyBase").transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );
                if (distance1 <= 3f)
                {
                    GameObject.Find("EnemyBase").GetComponent<EnemyBase>().EnemyBaseLife -= robotDamage;
                    GameObject dieEffect = Instantiate(die, null);
                    dieEffect.transform.position = this.transform.position;
                    GameObject.Find("Point1").transform.position = new Vector3(0, 100, 0);
                    Destroy(gameObject);
                }
            }
        }
    }
}
