using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower1 : MonoBehaviour
{
    public float tower1Life = 200f;
    private float time = 3;
    private float timegap = 2;
    public bool fire = true;
    public GameObject TowerBullet;
    public GameObject die;
    public GameObject EnemyBig;
    public AudioSource shoot;

    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = tower1Life;
    }

    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = tower1Life;

        var player = GameObject.Find("Player");
        var robot3 = GameObject.Find("Robot3(Clone)");

        float distance1 = Vector3.Distance(player.transform.position, this.transform.position);

        if(distance1 <= 25&&fire)
        {            
            if(time>timegap)
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
        if (tower1Life <= 0)
        {
            GameObject.Find("Point1").transform.position = new Vector3(0, 100, 0);

            GameObject dieEffect = Instantiate(die, null);
            dieEffect.transform.position = this.transform.position;
            
            GameObject node = Instantiate(EnemyBig,null);
            node.transform.position = GameObject.Find("EnemyCreatePoint").transform.GetChild(0).GetChild(1).gameObject.transform.position; 

            Destroy(gameObject);         
        }
    }
    
    private void CreateBullet()
    {
        GameObject firepoint = Instantiate(TowerBullet, this.transform);
        firepoint.transform.position = this.transform.position;
    }
}
