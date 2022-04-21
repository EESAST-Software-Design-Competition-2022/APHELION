using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public float rocketdamage = 20f;
    public GameObject Fire2;

    public AudioSource rocketAudio,buildingAudio;

    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        rocketdamage = 20*data.attack/100;
    }
    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<Fire>();
        if (other.gameObject.tag == "EnemyBug")
        {
            player.rocket_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= rocketdamage;

            GameObject fire2 = Instantiate(Fire2, null);
            fire2.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyTroll")
        {
            player.rocket_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= rocketdamage;

            GameObject fire2 = Instantiate(Fire2, null);
            fire2.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            player.rocket_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= rocketdamage;

            GameObject fire2 = Instantiate(Fire2, null);
            fire2.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= rocketdamage;

            GameObject fire2 = Instantiate(Fire2, null);
            fire2.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= rocketdamage;

            GameObject fire2 = Instantiate(Fire2, null);
            fire2.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower1")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower1>();
            ec.tower1Life -= rocketdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower2")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower2>();
            ec.tower2Life -= rocketdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyCrystal")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyCrystal>();
            ec.EnemyCrystalLife -= rocketdamage;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyBase")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBase>();
            ec.EnemyBaseLife -= rocketdamage;
            Destroy(this.gameObject);
        }
    }
}
