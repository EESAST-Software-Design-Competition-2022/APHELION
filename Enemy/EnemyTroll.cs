using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTroll : MonoBehaviour
{
    public float EnemyLife = 300;
    public float EnemySpeed = 3f;
    public float Damage = 10f;

    public float enemyrotatespeed = 1f;

    private float time = 0;

    Animator anim;

    public AudioSource attackPlayerAudio;
    public AudioSource attackBaseAudio;
    private float reduce;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = EnemyLife;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        reduce = (GameObject.Find("Player").GetComponent<PlayerData>().defence-200)/15;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyLife;
        if (GameObject.Find("PlayUI").GetComponent<PlayerUI>().IsDead == false)
        {
            var player = GameObject.Find("Player");
            float distance = Vector3.Distance(player.transform.position, this.transform.position);
            var ui = GameObject.Find("PlayUI");
            var pb = ui.gameObject.GetComponent<PlayerUI>();

            anim.SetBool("attack", false);

            Vector3 v3 = GameObject.Find("Player").transform.position - gameObject.transform.position;
            gameObject.transform.position += v3.normalized * EnemySpeed * Time.deltaTime;

            this.gameObject.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.LookRotation(player.transform.position - this.gameObject.transform.position),
                enemyrotatespeed * Time.deltaTime
                );

            if (distance <= 3f)
            {
                anim.SetBool("attack", true);

                if (time > 2)
                {
                    Attack();

                    time = 0;
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
            if(EnemyLife<=0)
            {
                player.GetComponent<Fire>().trollAudio.Play();
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().xp += 10;
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().kill += 1;
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().score += 10;
                Destroy(gameObject);
            }
        }
    }

    void Attack()
    {
        GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife -= (Damage-reduce);
    }
}
