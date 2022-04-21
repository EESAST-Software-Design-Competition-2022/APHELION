using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scatter : MonoBehaviour
{
    public float scatterdamage = 2f;
    public GameObject Fire5;

    public AudioSource iceAudio,buildingAudio;
    // Update is called once per frame
    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        scatterdamage = 2*data.attack/100;
    }
    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<Fire>();
        if (other.gameObject.tag == "EnemyBug")
        {
            player.ice_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= scatterdamage;

            GameObject fire5 = Instantiate(Fire5, null);
            fire5.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyTroll")
        {
            player.ice_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= scatterdamage;

            GameObject fire5 = Instantiate(Fire5, null);
            fire5.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            player.ice_Audio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= scatterdamage;

            ec.isSlow = true;

            GameObject fire5 = Instantiate(Fire5, null);
            fire5.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= scatterdamage;

            GameObject fire1 = Instantiate(Fire5, null);
            fire1.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            player.witchAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= scatterdamage;

            GameObject fire5 = Instantiate(Fire5, null);
            fire5.transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower1")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower1>();
            ec.tower1Life -= scatterdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Tower2")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<Tower2>();
            ec.tower2Life -= scatterdamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyCrystal")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyCrystal>();
            ec.EnemyCrystalLife -= scatterdamage;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyBase")
        {
            player.buildingAudio.Play();
            var ec = other.gameObject.GetComponent<EnemyBase>();
            ec.EnemyBaseLife -= scatterdamage;
            Destroy(this.gameObject);
        }
    }
}
