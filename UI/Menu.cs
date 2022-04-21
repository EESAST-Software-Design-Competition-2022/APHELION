using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource button,bgm;
    void Awake()
    {
        bgm.Play();
    }
    public void Play()
    {
        button.Play();
        bgm.Stop();
        SceneManager.LoadScene("Play");
    }
    public void Quit()
    {
        button.Play();
        Application.Quit();
    }
}
