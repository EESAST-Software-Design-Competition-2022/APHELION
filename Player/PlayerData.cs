using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float attack;
    public float fireRate;
    public float defence;
    public float moveSpeed;

    void Awake()
    {
        attack = 100;
        fireRate = 200;
        defence = 100;
        moveSpeed = 300;
    }
}
