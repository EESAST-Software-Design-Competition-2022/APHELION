using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBall : MonoBehaviour
{
    public float EnemyBallDamage = 15f;
    public float EnemyBallSpeed = 10f;

    void Update()
    {
        this.transform.Translate(Vector3.forward * EnemyBallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        var player = GameObject.Find("Player").GetComponent<PlayMove>();
        if (other.gameObject.tag == "Play")
        {
            player.damage.Play();
            GameObject.Find("PlayUI").GetComponent<PlayerUI>().PlayerLife -= EnemyBallDamage;
            Destroy(gameObject);
        }
    }
}
