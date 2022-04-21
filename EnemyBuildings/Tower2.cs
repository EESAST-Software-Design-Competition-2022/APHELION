using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower2 : MonoBehaviour
{
    public float tower2Life = 200f;
    private float time = 3;
    private float timegap = 2;
    public GameObject TowerBullet;
    public bool fire = true;
    public GameObject die;
    public AudioSource shoot;

    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = tower2Life;
    }

    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = tower2Life;

        var player = GameObject.Find("Player");
        var robot3 = GameObject.Find("Robot3(Clone)");
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= 25&&fire)
        {           
            if (time > timegap)
            {
                shoot.Play();
                CreateBullet();
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        if (tower2Life <= 0)
        {
            Destroy(gameObject);
            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;

            GameObject.Find("Point2").transform.position = new Vector3(0, 100, 0);
        }
        float distance2 = Vector3.Distance(robot3.transform.position, this.transform.position);
    }

    private void CreateBullet()
    {
        GameObject firepoint = Instantiate(TowerBullet, this.transform);
        firepoint.transform.position = this.transform.position;
    }
}
