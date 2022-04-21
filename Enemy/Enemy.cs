using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyLife;
    public float EnemySpeed;
    public float Damage;
    public float enemyrotatespeed;

    public float time1 = 3;
    public float time2 = 3;

    public bool isSlow = false;
    public float timer = 0;
    public float slowTime = 5f;

    public AudioSource attackPlayerAudio;
    public AudioSource attackBaseAudio;

    public Animator anim;

    public float distance1;
    public float distance2;

    //转向
    public void WalkToBase(Enemy enemy)
    {
        Vector3 v3 = GameObject.Find("EnemyPoint").transform.position - gameObject.transform.position;
        gameObject.transform.position += v3.normalized * EnemySpeed * Time.deltaTime;

        this.gameObject.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            Quaternion.LookRotation(GameObject.Find("EnemyPoint").transform.position - enemy.transform.position),
            enemyrotatespeed * Time.deltaTime
            );
    }
    //转向玩家
    public void RotateToPlayer(Enemy enemy)
    {
        this.gameObject.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            Quaternion.LookRotation(GameObject.Find("Player").transform.position - enemy.transform.position),
            enemyrotatespeed * Time.deltaTime
            );
    }
    public void RotateToBase(Enemy enemy)
    {
        this.gameObject.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            Quaternion.LookRotation(GameObject.Find("PlayerBase").transform.position - enemy.transform.position),
            enemyrotatespeed * Time.deltaTime
            );
    }
    //开始减速
    public void BeginSlow()
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
    //攻击玩家
    public void Attack1()
    {
        GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife -= Damage;
        attackPlayerAudio.Play();
    }
    //攻击玩家基地
    public void Attack2()
    {
        GameObject.Find("PlayerBase").GetComponent<PlayerBase>().PlayerBaseLife -= Damage;
        attackBaseAudio.Play();
    }
}
