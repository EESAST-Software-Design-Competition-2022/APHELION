using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Destroy : MonoBehaviour
{
    public AudioSource skillAudio_2;
    void Start()
    {
        skillAudio_2.Play();
        Invoke("Destroy", 5);
    }

    void Destroy()
    {
        skillAudio_2.Stop();
        Destroy(gameObject);
    }
}
