using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBug : MonoBehaviour
{
    public float EnemyLife = 100;
    public float EnemySpeed = 5f;
    public float Damage = 5f;
    public GameObject bugDieEffect;

    public float enemyrotatespeed = 2f;

    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = EnemyLife;
    }

    void Update()
    {
        float reduce = (GameObject.Find("Player").GetComponent<PlayerData>().defence-200)/15;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = EnemyLife;
        
        if (GameObject.Find("PlayUI").GetComponent<PlayerUI>().IsDead == false)
        {
            Vector3 v3 = GameObject.Find("Player").transform.position - gameObject.transform.position;
            gameObject.transform.position += v3.normalized * EnemySpeed * Time.deltaTime;


            var player = GameObject.Find("Player");
            var ui = GameObject.Find("PlayUI");
            var pb = ui.gameObject.GetComponent<PlayerUI>();

            this.gameObject.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.LookRotation(player.transform.position - this.gameObject.transform.position),
                enemyrotatespeed * Time.deltaTime
                );
            
            float distance = Vector3.Distance(player.transform.position, this.transform.position);

            if (distance <= 3f)
            {
                pb.PlayerLife -= (Damage-reduce);
                
                GameObject bugDie = Instantiate(bugDieEffect, null);
                bugDie.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }

            if(EnemyLife<=0)
            {
                player.GetComponent<Fire>().bugAudio.Play();
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().xp += 10;
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().kill += 1;
                GameObject.Find("PlayUI").GetComponent<PlayerUI>().score += 10;
                Destroy(gameObject);
            }
        }
    }
}
