using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWitch : MonoBehaviour
{
    public float EnemyLife = 800;
    public float EnemySpeed = 1f;
    public float Damage = 50f;

    public float enemyrotatespeed = 1f;

    private float time1 = 5;

    public bool isSlow = false;
    public float timer = 0;
    public float slowTime = 5f;

    public GameObject bug;
    public GameObject witchDieEffect;

    public AudioSource attackBaseAudio;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = EnemyLife;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("PlayUI").GetComponent<PlayerUI>().IsDead == false)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyLife;

            anim.SetBool("attack", false);
            Vector3 v3 = GameObject.Find("EnemyPoint").transform.position - gameObject.transform.position;
            gameObject.transform.position += v3.normalized * EnemySpeed * Time.deltaTime;

            var playerbase = GameObject.Find("PlayerCrystal");
            float distance = Vector3.Distance(playerbase.transform.position, this.transform.position);

            this.gameObject.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.LookRotation(GameObject.Find("EnemyPoint").transform.position - this.gameObject.transform.position),
                enemyrotatespeed * Time.deltaTime
                );

            if(isSlow)
            {
                timer += Time.deltaTime;
                EnemySpeed = 1f;
                gameObject.transform.Find("SlowEffect").gameObject.SetActive(true);
                if(timer>slowTime)
                {
                    isSlow = false;
                    timer = 0;
                    EnemySpeed = 2f;
                    gameObject.transform.Find("SlowEffect").gameObject.SetActive(false);
                }
            }
            if(time1>10)
            {
                anim.SetBool("attack",true);
                GameObject node = Instantiate(bug,null);
                node.transform.position = GameObject.Find("BugPoint").transform.position;
                time1 = 0;
            }
            time1 += Time.deltaTime;

            if(distance<=5)
            {
                GameObject witchDie = Instantiate(witchDieEffect, null);
                witchDie.transform.position = this.transform.position;
                GameObject.Find("PlayerBase").GetComponent<PlayerBase>().PlayerBaseLife -= Damage;
                Destroy(gameObject);
            }

            if(EnemyLife<=0)
            {
                GameObject witchDie = Instantiate(witchDieEffect, null);
                witchDie.transform.position = this.transform.position;
                Destroy(gameObject);
            }
        }
    }
}
