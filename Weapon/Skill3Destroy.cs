using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3Destroy : MonoBehaviour
{
    public AudioSource skillAudio_3;
    void Start()
    {
        skillAudio_3.Play();
        Invoke("Destroy", 5);
    }

    void Destroy()
    {
        skillAudio_3.Stop();
        Destroy(gameObject);
    }
}
