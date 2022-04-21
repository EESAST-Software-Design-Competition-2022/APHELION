using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float arrowdamage = 10f;
    public GameObject Fire3;
    public AudioSource arrowAudio,buildingAudio;
    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        arrowdamage = 10*data.attack/100;
    }
    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<Fire>();
        if (other.gameObject.tag == "EnemyBug")
        {
            player.arrowAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= arrowdamage;

            GameObject fire3 = Instantiate(Fire3, null);
            fire3.transform.position = this.transform.position;
        }

        if (other.gameObject.tag == "EnemyTroll")
        {
            player.arrowAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= arrowdamage;

            GameObject fire3 = Instantiate(Fire3, null);
            fire3.transform.position = this.transform.position;
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            player.arrowAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= arrowdamage;

            GameObject fire3 = Instantiate(Fire3, null);
            fire3.transform.position = this.transform.position;
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= arrowdamage;

            GameObject fire3 = Instantiate(Fire3, null);
            fire3.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= arrowdamage;

            GameObject fire3 = Instantiate(Fire3, null);
            fire3.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower1")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower1>();
            ec.tower1Life -= arrowdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower2")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower2>();
            ec.tower2Life -= arrowdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyCrystal")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyCrystal>();
            ec.EnemyCrystalLife -= arrowdamage;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyBase")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBase>();
            ec.EnemyBaseLife -= arrowdamage;
            Destroy(this.gameObject);
        }
    }
}

