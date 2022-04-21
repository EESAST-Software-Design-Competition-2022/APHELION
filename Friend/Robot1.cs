using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot1 : MonoBehaviour
{
    public float robotSpeed = 2f;
    public float robotDamage = 10f;

    public GameObject die;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Update()
    {
        anim.SetBool("walk", true);
        this.transform.Translate(Vector3.forward * robotSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyBug")
        {
            var ec = other.gameObject.GetComponent<EnemyBug>();
            ec.EnemyLife -= robotDamage;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyTroll")
        {
            var ec = other.gameObject.GetComponent<EnemyTroll>();
            ec.EnemyLife -= robotDamage;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyHulk")
        {
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= robotDamage;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyHulkBig")
        {
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= robotDamage;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyWitch")
        {
            var ec = other.gameObject.GetComponent<EnemyHulk>();
            ec.EnemyLife -= robotDamage;
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
