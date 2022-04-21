using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHulkBig : MonoBehaviour
{
    public float EnemyLife = 500;
    public float EnemySpeed = 2f;
    public float Damage = 10f;

    public float enemyrotatespeed = 1f;

    private float time1 = 0;
    private float time2 = 0;

    public bool isSlow = false;
    public float timer = 0;
    public float slowTime = 5f;

    public Rigidbody rock;
    public Transform rockPoint;

    public AudioSource attackPlayerAudio;
    public AudioSource attackBaseAudio;
    public AudioSource isAttack;

    public GameObject EnemyItem;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = EnemyLife;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyLife;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("PlayUI").GetComponent<PlayerUI>().IsDead == false)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyLife;

            var player = GameObject.Find("Player");
            var playerbase = GameObject.Find("PlayerCrystal");

            float distance1 = Vector3.Distance(player.transform.position, this.transform.position);
            float distance2 = Vector3.Distance(playerbase.transform.position, this.transform.position);

            var ui = GameObject.Find("PlayUI");
            var pb = ui.gameObject.GetComponent<PlayerUI>();

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
            if (distance1 <= 15f)
            {
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);

                Vector3 v3 = GameObject.Find("Player").transform.position - gameObject.transform.position;

                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(player.transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );

                if (time1 > 1.5)
                {
                    Attack1();

                    time1 = 0;
                }
                else
                {
                    time1 += Time.deltaTime;
                }
            }

            else if(distance2 <= 3.5f)
            {
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);
                
                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(playerbase.transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );

                if (time2 > 1.5)
                {
                    Attack2();

                    time2 = 0;
                }
                else
                {
                    time2 += Time.deltaTime;
                }
            }

            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("attack", false);
                Vector3 v3 = GameObject.Find("EnemyPoint").transform.position - gameObject.transform.position;
                gameObject.transform.position += v3.normalized * EnemySpeed * Time.deltaTime;

                this.gameObject.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(GameObject.Find("EnemyPoint").transform.position - this.gameObject.transform.position),
                    enemyrotatespeed * Time.deltaTime
                    );
            }
            if(EnemyLife<=0)
            {
                GameObject.Find("Control").GetComponent<PlayCtrl>().status = 1;
                Destroy(gameObject);
            }
        }
    }

    void Attack1()
    {
        Rigidbody rockClone;
        rockClone = (Rigidbody)Instantiate(rock, rockPoint.position, rockPoint.rotation);
        rockClone.velocity = transform.TransformDirection(Vector3.forward * 15);
        attackPlayerAudio.Play();
    }
    void Attack2()
    {
        GameObject.Find("PlayerBase").GetComponent<PlayerBase>().PlayerBaseLife -= Damage;
        attackBaseAudio.Play();
    }
}

