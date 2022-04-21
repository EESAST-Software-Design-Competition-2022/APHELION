using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",10);
    }
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "EnemyBug")
        {
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= 20;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyTroll")
        {
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= 20;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulk")
        {
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= 20;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            var ec = other.gameObject.GetComponent<EnemyHulkBig>();
            ec.EnemyLife -= 40;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            var ec = other.gameObject.GetComponent<EnemyWitch>();
            ec.EnemyLife -= 40;
            Destroy(this.gameObject);
        }
    }
}
