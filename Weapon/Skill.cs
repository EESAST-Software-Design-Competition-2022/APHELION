using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public bool Fire1;
    public bool Fire2;
    public bool Fire3;
    public bool Fire4;
    public bool Fire5;

    public float fire3Gap = 2;

    private float time1;
    private float time2;
    private float time3;
    private float time4;
    private float time5;

    public float timer1;
    public float timer2;
    public float timer3;
    public float timer4;
    public float timer5;

    private float lastTime;
    public float skill_1_k;

    public GameObject rocket1;
    public GameObject rocket2;
    public GameObject rocket3;
    public GameObject rocket4;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill5;

    public bool isButton_1;
    public bool isButton_3;
    public bool endCoolDown_1;
    public bool beginCoolDown_1;
    public bool endCoolDown_2;
    public bool beginCoolDown_2;
    public bool endCoolDown_3;
    public bool beginCoolDown_3;
    public bool endCoolDown_4;
    public bool beginCoolDown_4;
    public bool endCoolDown_5;
    public bool beginCoolDown_5;
    
    public float coolDownTime;

    public AudioSource skillAudio_1,skillAudio_3,skillAudio_4,skillAudio_5;
    // Start is called before the first frame update
    void Start()
    {
        time1 = 0;
        time3 = 0;
        Fire1 = false;
        Fire2 = false;
        Fire3 = false;
        Fire4 = false;
        Fire5 = false;

        timer1 = 0;
        timer2 = 0;
        timer3 = 0;
        timer4 = 0;
        timer5 = 0;

        coolDownTime = 10;
        isButton_1 = false;
        isButton_3 = false;
        endCoolDown_1 = true;
        beginCoolDown_1 = false;
        endCoolDown_2 = true;
        beginCoolDown_2 = false;
        endCoolDown_3 = true;
        beginCoolDown_3 = false;
        endCoolDown_4 = true;
        beginCoolDown_4 = false;
        endCoolDown_5 = true;
        beginCoolDown_5 = false;
        lastTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        var num = GameObject.Find("Player").GetComponent<Fire>();
        var status = GameObject.Find("Player").GetComponent<Fire>();
        var p = GameObject.Find("Player");
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        var skill_1 = GameObject.Find("Skill_1");
        var skillUI = GameObject.Find("SkillUI");
        skillUI.transform.Find("Skill (0)").gameObject.SetActive(false);
        skillUI.transform.Find("Skill (1)").gameObject.SetActive(false);
        skillUI.transform.Find("Skill (2)").gameObject.SetActive(false);
        skillUI.transform.Find("Skill (3)").gameObject.SetActive(false);
        skillUI.transform.Find("Skill (4)").gameObject.SetActive(false);

        #region Skill_1

        if(beginCoolDown_1)
        {
            timer1 += Time.deltaTime;
            if(timer1 >= coolDownTime)
            {
                timer1 = 0;
                endCoolDown_1 = true;
                beginCoolDown_1 = false;
            }
        }
        if(beginCoolDown_2)
        {
            timer2 += Time.deltaTime;
            if(timer2 >= coolDownTime)
            {
                timer2 = 0;
                endCoolDown_2 = true;
                beginCoolDown_2 = false;
            }
        }
        if(beginCoolDown_3)
        {
            timer3 += Time.deltaTime;
            if(timer3 >= coolDownTime)
            {
                timer3 = 0;
                endCoolDown_3 = true;
                beginCoolDown_3 = false;
            }
        }
        if(beginCoolDown_4)
        {
            timer4 += Time.deltaTime;
            if(timer4 >= coolDownTime)
            {
                timer4 = 0;
                endCoolDown_4 = true;
                beginCoolDown_4 = false;
            }
        }
        if(beginCoolDown_5)
        {
            timer5 += Time.deltaTime;
            if(timer5 >= coolDownTime)
            {
                timer5 = 0;
                endCoolDown_5 = true;
                beginCoolDown_5 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.T)&&status.bullet_status == 0&&endCoolDown_1)
        {
            num.bulletnum -= 10;
            beginCoolDown_1 = true;
            endCoolDown_1 = false;
            isButton_1 = true;
            skillAudio_1.Play();
        }
        if (Input.GetKeyDown(KeyCode.T)&&status.arrow_status == 0&&endCoolDown_3)
        {
            num.bulletnum -= 10;
            beginCoolDown_3 = true;
            endCoolDown_3 = false;
            isButton_3 = true;
            skillAudio_3.Play();
        }
        if(Fire1&&isButton_1)
        {
            FireFirst();
            time1 += Time.deltaTime;
            if(time1>lastTime)
            {
                skillAudio_1.Stop();
                time1 = 0;
                isButton_1 = false;
                data.attack = 100;
                data.defence = 200;
                data.fireRate = 200;
                data.moveSpeed = 300;
                skill_1.transform.Find("Skill_1_1").gameObject.SetActive(false);
                skill_1.transform.Find("Skill_1_2").gameObject.SetActive(false);
                skill_1.transform.Find("Skill_1_3").gameObject.SetActive(false);
                skill_1.transform.Find("Skill_1_4").gameObject.SetActive(false);
            }
        }
        #endregion
        if (Fire2&&Input.GetKeyDown(KeyCode.T)&&status.rocket_status == 0&&endCoolDown_2)
        {
            num.rocketnum -= 10;
            beginCoolDown_2 = true;
            endCoolDown_2 = false;
            Firesecond();
        }
        if(Fire3&&isButton_3)
        {
            if(fire3Gap>0.4)
            {
                Firethird();
                fire3Gap = 0;
            }
            if(time3>lastTime)
            {
                time3 = 0;
                isButton_3 = false;
                skillAudio_3.Stop();
            }
            fire3Gap += Time.deltaTime;
            time3 += Time.deltaTime;
        }
        if (Fire4&&Input.GetKeyDown(KeyCode.T)&&status.grenade_status == 0&&endCoolDown_4)
        {
            num.grenadenum -= 5;
            skillAudio_4.Play();
            beginCoolDown_4 = true;
            endCoolDown_4 = false;
            Firefourth();
        }
        if (Fire5&&Input.GetKeyDown(KeyCode.T)&&status.scatter_status == 0&&endCoolDown_5)
        {
            num.scatternum -= 10;
            skillAudio_5.Play();
            beginCoolDown_5 = true;
            endCoolDown_5  = false;
            Firefifth();
        }
        if(Fire1&&status.bullet_status == 0)
        {
            skillUI.transform.Find("Skill (0)").gameObject.SetActive(true);
            if(!endCoolDown_1)
            {
                int timeRemain1 = (int)(coolDownTime-timer1);
                GameObject.Find("Skill (0)").transform.Find("Shade1").gameObject.SetActive(true);
                GameObject.Find("Skill (0)").transform.Find("Count (0)").gameObject.SetActive(true);
                GameObject.Find("Count (0)").GetComponent<Text>().text = ""+timeRemain1;
            }
            else
            {
                GameObject.Find("Skill (0)").transform.Find("Shade1").gameObject.SetActive(false);
                GameObject.Find("Skill (0)").transform.Find("Count (0)").gameObject.SetActive(false);
            }
        }
        if(Fire2&&status.rocket_status == 0)
        {
            skillUI.transform.Find("Skill (1)").gameObject.SetActive(true);
            if(!endCoolDown_2)
            {
                int timeRemain2 = (int)(coolDownTime-timer2);
                GameObject.Find("Skill (1)").transform.Find("Shade2").gameObject.SetActive(true);
                GameObject.Find("Skill (1)").transform.Find("Count (1)").gameObject.SetActive(true);
                GameObject.Find("Count (1)").GetComponent<Text>().text = ""+timeRemain2;
            }
            else
            {
                GameObject.Find("Skill (1)").transform.Find("Shade2").gameObject.SetActive(false);
                GameObject.Find("Skill (1)").transform.Find("Count (1)").gameObject.SetActive(false);
            }
        }
        if(Fire3&&status.arrow_status == 0)
        {
            skillUI.transform.Find("Skill (2)").gameObject.SetActive(true);
            if(!endCoolDown_3)
            {
                int timeRemain3 = (int)(coolDownTime-timer3);
                GameObject.Find("Skill (2)").transform.Find("Shade3").gameObject.SetActive(true);
                GameObject.Find("Skill (2)").transform.Find("Count (2)").gameObject.SetActive(true);
                GameObject.Find("Count (2)").GetComponent<Text>().text = ""+timeRemain3;
            }
            else
            {
                GameObject.Find("Skill (2)").transform.Find("Shade3").gameObject.SetActive(false);
                GameObject.Find("Skill (2)").transform.Find("Count (2)").gameObject.SetActive(false);
            }
        }
        if(Fire4&&status.grenade_status == 0)
        {
            skillUI.transform.Find("Skill (3)").gameObject.SetActive(true);
            if(!endCoolDown_4)
            {
                int timeRemain4 = (int)(coolDownTime-timer4);
                GameObject.Find("Skill (3)").transform.Find("Shade4").gameObject.SetActive(true);
                GameObject.Find("Skill (3)").transform.Find("Count (3)").gameObject.SetActive(true);
                GameObject.Find("Count (3)").GetComponent<Text>().text = ""+timeRemain4;
            }
            else
            {
                GameObject.Find("Skill (3)").transform.Find("Shade4").gameObject.SetActive(false);
                GameObject.Find("Skill (3)").transform.Find("Count (3)").gameObject.SetActive(false);
            }
        }
        if(Fire5&&status.scatter_status == 0)
        {
            skillUI.transform.Find("Skill (4)").gameObject.SetActive(true);
            if(!endCoolDown_5)
            {
                int timeRemain5 = (int)(coolDownTime-timer5);
                GameObject.Find("Skill (4)").transform.Find("Shade5").gameObject.SetActive(true);
                GameObject.Find("Skill (4)").transform.Find("Count (4)").gameObject.SetActive(true);
                GameObject.Find("Count (4)").GetComponent<Text>().text = ""+timeRemain5;
            }
            else
            {
                GameObject.Find("Skill (4)").transform.Find("Shade5").gameObject.SetActive(false);
                GameObject.Find("Skill (4)").transform.Find("Count (4)").gameObject.SetActive(false);
            }
        }
    }

    private void FireFirst()
    {
        var status = GameObject.Find("Player").GetComponent<Fire>();
        var skill_1 = GameObject.Find("Skill_1");
        var data = GameObject.Find("Player").GetComponent<PlayerData>();

        if(status.rocket_status == 1)
        {
            skill_1.transform.Find("Skill_1_1").gameObject.SetActive(true);
            data.attack = 100 + 100;
        }
        if(status.arrow_status == 1)
        {
            skill_1.transform.Find("Skill_1_2").gameObject.SetActive(true);
            data.fireRate = 200 + 100;
        }
        if(status.grenade_status == 1)
        {
            skill_1.transform.Find("Skill_1_3").gameObject.SetActive(true);
            data.defence = 200 + 100;
        }
        if(status.scatter_status == 1)
        {
            skill_1.transform.Find("Skill_1_4").gameObject.SetActive(true);
            data.moveSpeed = 300 + 100;
        }
    }

    private void Firesecond()
    {
        var fire1 = GameObject.Find("Fire_1");
        var fire2 = GameObject.Find("Fire_2");
        var fire3 = GameObject.Find("Fire_3");
        var fire4 = GameObject.Find("Fire_4");
        var fire5 = GameObject.Find("Fire_5");
        GameObject node1 = Instantiate(skill2,null);
        node1.transform.position = fire1.transform.position;
        GameObject node2 = Instantiate(skill2,null);
        node2.transform.position = fire2.transform.position;
        GameObject node3 = Instantiate(skill2,null);
        node3.transform.position = fire3.transform.position;
        GameObject node4 = Instantiate(skill2,null);
        node4.transform.position = fire4.transform.position;
        GameObject node5 = Instantiate(skill2,null);
        node5.transform.position = fire5.transform.position;
    }
    private void Firethird()
    {

        var arrowPoint = GameObject.Find("Skill_3");
        GameObject node = Instantiate(skill3,null);
        float dx = Random.Range(-5,5);
        float dz = Random.Range(-5,5);
        node.transform.position = arrowPoint.transform.position+ new Vector3(dx,0,dz);
    }
    private void Firefourth()
    {
        var status = GameObject.Find("Player").GetComponent<Fire>();
        var create = GameObject.Find("RocketPoint");
        if(status.bullet_status == 1)
        {
            GameObject node = Instantiate(rocket1, null);
            node.transform.position = create.transform.position;
        }
        if(status.rocket_status == 1)
        {
            GameObject node = Instantiate(rocket2, null);
            node.transform.position = create.transform.position;
        }
        if(status.arrow_status == 1)
        {
            GameObject node = Instantiate(rocket3, null);
            node.transform.position = create.transform.position;
        }
        if(status.scatter_status == 1)
        {
            GameObject node = Instantiate(rocket4, null);
            node.transform.position = create.transform.position;
        }
    }
    private void Firefifth()
    {
        var skill5Point = GameObject.Find("Skill_5");
        GameObject node = Instantiate(skill5, null);
        node.transform.position = skill5Point.transform.position;
    }
}
