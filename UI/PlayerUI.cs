using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public float PlayerLife = 100;
    public bool IsDead = false;
    public int level = 1;
    public float xp = 0;
    public int kill = 0;
    public int score = 0;

    public float time = 0;
    private int maxxp = 100;
    private int maxlevel = 6;

    public AudioSource levelUp;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("PlayerBlood").GetComponent<Slider>().maxValue = PlayerLife;
        GameObject.Find("Xp").GetComponent<Slider>().maxValue = maxxp;
    }

    void Update()
    {
        var skill = GameObject.Find("Player").GetComponent<Skill>();
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        var si = GameObject.Find("SkillItem");

        time += Time.deltaTime;

        GameObject.Find("PlayerBlood").GetComponent<Slider>().value = PlayerLife;
        GameObject.Find("Xp").GetComponent<Slider>().value = xp;

        GameObject.Find("Bd").GetComponent<Text>().text = "Kill:" + kill;
        GameObject.Find("Score").GetComponent<Text>().text = "Score:" + score;
        GameObject.Find("Level").GetComponent<Text>().text = "Level:" + level;
        GameObject.Find("Time").GetComponent<Text>().text = "Time:" + (int)time;

        GameObject.Find("Attack").GetComponent<Text>().text = "ATK:" + data.attack;
        GameObject.Find("Defence").GetComponent<Text>().text = "DEF:" + data.defence;
        GameObject.Find("FireRate").GetComponent<Text>().text = "FRT:" + data.fireRate;
        GameObject.Find("MoveSpeed").GetComponent<Text>().text = "MSD:" + data.moveSpeed;

        if (level < maxlevel)
        {
            if (xp >= 100)
            {
                switch(level)
                {
                    case 1:
                    GameObject node1 = Instantiate(Item1,null);
                    node1.transform.position = si.transform.position;
                    break;
                    case 2:
                    GameObject node2 = Instantiate(Item2,null);
                    node2.transform.position = si.transform.position;
                    break;
                    case 3:
                    GameObject node3 = Instantiate(Item3,null);
                    node3.transform.position = si.transform.position;
                    break;
                    case 4:
                    GameObject node4 = Instantiate(Item4,null);
                    node4.transform.position = si.transform.position;
                    break;
                    case 5:
                    GameObject node5 = Instantiate(Item5,null);
                    node5.transform.position = si.transform.position;
                    break;
                }
                levelUp.Play();
                level += 1;
                xp = 0;
            }
        }
        else
        {
            xp = 100;
        }

        var player = GameObject.Find("Player");
        if (PlayerLife <= 0)
        {
            IsDead = true;
            this.gameObject.transform.Find("Lose").gameObject.SetActive(true);
            Destroy(player);
        }
        
        if (level >= 2)
        {
            skill.Fire1 = true;
        }
        if (level >= 3)
        {
            skill.Fire2 = true;
        }
        if (level >= 4)
        {
            skill.Fire3 = true;
        }
        if (level >= 5)
        {
            skill.Fire4 = true;
        }
        if (level >= 6)
        {
            skill.Fire5 = true;
        }
        tower();
    }
    void tower()
    {
        bool tower1 = GameObject.Find("Tower1").GetComponent<Tower1>().fire;
        bool tower2 = GameObject.Find("Tower2").GetComponent<Tower2>().fire;
        if(tower1 == false|| tower2 == false)
        {
            gameObject.transform.Find("Judge").gameObject.SetActive(true);
        }
    }
}
