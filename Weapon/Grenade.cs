using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{
    public float grenadedamage = 40f;
    public GameObject Fire4;
    public AudioSource grenadeAudio,buildingAudio;
    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        grenadedamage = 40*data.attack/100;     
    }
    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<Fire>();
        if (other.gameObject.tag == "EnemyBug")
        {
            player.grenade_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= grenadedamage;

            GameObject fire4 = Instantiate(Fire4, null);
            fire4.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyTroll")
        {
            player.grenade_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= grenadedamage;

            GameObject fire4 = Instantiate(Fire4, null);
            fire4.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            player.grenade_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= grenadedamage;

            GameObject fire4 = Instantiate(Fire4, null);
            fire4.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= grenadedamage;

            GameObject fire4 = Instantiate(Fire4, null);
            fire4.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= grenadedamage;

            GameObject fire4 = Instantiate(Fire4, null);
            fire4.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower1")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower1>();
            ec.tower1Life -= grenadedamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower2")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower2>();
            ec.tower2Life -= grenadedamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyCrystal")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyCrystal>();
            ec.EnemyCrystalLife -= grenadedamage;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyBase")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBase>();
            ec.EnemyBaseLife -= grenadedamage;
            Destroy(this.gameObject);
        }
    }
}