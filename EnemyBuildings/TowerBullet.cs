using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float TowerBulletDamage = 15f;
    public float TowerBulletSpeed = 10f;

    void Update()
    {
        Vector3 v3 = GameObject.Find("TakeBullet").transform.position - gameObject.transform.position;
        gameObject.transform.position += v3.normalized * TowerBulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<PlayMove>();
        if (other.gameObject.tag == "Play")
        {
            player.damage.Play();
            GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife -= TowerBulletDamage;
            Destroy(gameObject);
        }
    }
}
