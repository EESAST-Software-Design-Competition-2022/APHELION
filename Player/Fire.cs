using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float bulletspeed = 40f;
    public float rocketspeed = 10f;
    public float arrowspeed = 30f;
    public float grenadespeed = 5f;
    public float scatterspeed = 20f;

    public Rigidbody bullet;
    public Rigidbody rocket;
    public Rigidbody arrow;
    public Rigidbody grenade;
    public Rigidbody scatter;

    public Transform FirePoint;
    public Transform RightHand;

    private GameObject playerWeapon;

    public int bulletnum = 100;
    public int rocketnum = 20;
    public int arrownum = 50;
    public int grenadenum = 50;
    public int scatternum = 20;

    public int bullet_status = 0;
    public int rocket_status = 1;
    public int arrow_status = 2;
    public int grenade_status = 3;
    public int scatter_status = 4;

    Animator shoot;

    public AudioSource bulletAudio;
    public AudioSource rocketAudio;
    public AudioSource arrowAudio;
    public AudioSource scatterAudio;
    public AudioSource grenadeAudio;
    public AudioSource swapAudio;
    public AudioSource bugAudio,trollAudio,hulkAudio,witchAudio,arrow_Audio,rocket_Audio,grenade_Audio,ice_Audio,buildingAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Animator>();
    }
    private void Swap()
    {

        if(bullet_status == 0)
        {
            bullet_status = 1;
        }
        else if(bullet_status == 1)
        {
            bullet_status = 0;
        }

        if (rocket_status == 0)
        {
            rocket_status = 1;
        }
        else if (rocket_status == 1)
        {
            rocket_status = 0;
        }

        if (arrow_status == 0)
        {
            arrow_status = 1;
        }
        else if (arrow_status == 1)
        {
            arrow_status = 0;
        }

        if (grenade_status == 0)
        {
            grenade_status = 1;
        }
        else if (grenade_status == 1)
        {
            grenade_status = 0;
        }

        if (scatter_status == 0)
        {
            scatter_status = 1;
        }
        else if (scatter_status == 1)
        {
            scatter_status = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        bulletspeed = 20+(data.fireRate-200)/5;
        rocketspeed = 10+(data.fireRate-200)/5;
        arrowspeed = 35+(data.fireRate-200)/5;
        grenadespeed = 5+(data.fireRate-200)/5;
        scatterspeed = 20+(data.fireRate-200)/5;
        if(!gameObject.GetComponent<PlayMove>().isOpen)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                swapAudio.Play();
                Swap();
            }
            if (bullet_status == 0)
            {
                if (bulletnum > 0)
                {   
                    if (Input.GetMouseButton(0))
                    {
                        bulletAudio.Play();
                        Rigidbody bulletClone;

                        bulletnum -= 1;

                        bulletClone = (Rigidbody)Instantiate(bullet, FirePoint.position, FirePoint.rotation);
                        bulletClone.velocity = transform.TransformDirection(Vector3.forward * bulletspeed);

                        shoot.SetBool("Shoot1", true);
                    }
                    else
                    {
                        shoot.SetBool("Shoot1", false);
                    }
                }
                else
                {
                    bulletnum += 100;

                    bullet_status = 4;
                    rocket_status -= 1;
                    arrow_status -= 1;
                    grenade_status -= 1;
                    scatter_status -= 1;
                }

            }
            //rocket
            if (rocket_status == 0)
            {
                if (rocketnum > 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        rocketAudio.Play();
                        Rigidbody rocketClone;

                        rocketnum -= 1;

                        rocketClone = (Rigidbody)Instantiate(rocket, FirePoint.position, FirePoint.rotation);
                        rocketClone.velocity = transform.TransformDirection(Vector3.forward * rocketspeed);

                        shoot.SetBool("Shoot1", true);
                    }
                    else
                    {
                        shoot.SetBool("Shoot1", false);
                    } 
                }
                else
                {
                    rocketnum += 20;

                    bullet_status -= 1;
                    rocket_status = 4;
                    arrow_status -= 1;
                    grenade_status -= 1;
                    scatter_status -= 1;
                }
            }
            if (arrow_status == 0)
            {
                if (arrownum > 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        arrowAudio.Play();
                        Rigidbody arrowClone;

                        arrownum -= 1;

                        arrowClone = (Rigidbody)Instantiate(arrow, FirePoint.position, FirePoint.rotation);
                        arrowClone.velocity = transform.TransformDirection(Vector3.forward * arrowspeed);

                        shoot.SetBool("Shoot1", true);
                    }
                    else
                    {
                        shoot.SetBool("Shoot1", false);
                    }
                }
                else
                {
                    arrownum += 50;

                    bullet_status -= 1;
                    rocket_status -= 1;
                    arrow_status = 4;
                    grenade_status -= 1;
                    scatter_status -= 1;
                }
            }
            if (grenade_status == 0)
            {   
                if (grenadenum > 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        grenadeAudio.Play();
                        Rigidbody grenadeClone;

                        grenadenum -= 1;

                        grenadeClone = (Rigidbody)Instantiate(grenade, FirePoint.position, FirePoint.rotation);
                        grenadeClone.velocity = transform.TransformDirection(Vector3.forward * grenadespeed);

                        shoot.SetBool("Shoot1", true);
                    }
                    else
                    {
                        shoot.SetBool("Shoot1", false);
                    }
                }
                else
                {
                    grenadenum += 10;

                    bullet_status -= 1;
                    rocket_status -= 1;
                    arrow_status -= 1;
                    grenade_status = 4;
                    scatter_status -= 1;
                }
            }
            if (scatter_status == 0)
            {
                if (scatternum > 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        scatterAudio.Play();
                        Rigidbody scatterClone;

                        scatternum -= 1;

                        scatterClone = (Rigidbody)Instantiate(scatter, FirePoint.position, FirePoint.rotation);
                        scatterClone.velocity = transform.TransformDirection(Vector3.forward * scatterspeed);

                        shoot.SetBool("Shoot1", true);
                    }
                    else
                    {
                        shoot.SetBool("Shoot1", false);
                    }
                }
                else
                {
                    scatternum += 30;

                    bullet_status -= 1;
                    rocket_status -= 1;
                    arrow_status -= 1;
                    grenade_status -= 1;
                    scatter_status = 4;
                }
            }
        }            
    }
}
