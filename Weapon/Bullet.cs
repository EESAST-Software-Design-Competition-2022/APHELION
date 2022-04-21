using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float bulletdamage = 1f;
    public GameObject Fire1;
    void Update()
    {
       var data = GameObject.Find("Player").GetComponent<PlayerData>();
       bulletdamage = 1*(data.attack/100);
    }
    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<Fire>();
        if (other.gameObject.tag == "EnemyBug")
        {
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= bulletdamage;

            player.bugAudio.Play();

            GameObject fire1 = Instantiate(Fire1, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyTroll")
        {
            player.trollAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= bulletdamage;

            GameObject fire1 = Instantiate(Fire1, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            player.hulkAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= bulletdamage;

            GameObject fire1 = Instantiate(Fire1, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            player.hulkAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= bulletdamage;

            GameObject fire1 = Instantiate(Fire1, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= bulletdamage;

            GameObject fire1 = Instantiate(Fire1, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower1")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower1>();
            ec.tower1Life -= bulletdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower2")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower2>();
            ec.tower2Life -= bulletdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyCrystal")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyCrystal>();
            ec.EnemyCrystalLife -= bulletdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyBase")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBase>();
            ec.EnemyBaseLife -= bulletdamage;
            Destroy(this.gameObject);       
        }
    }
}
