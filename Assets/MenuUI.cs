using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;

    void Start()
    {
        Cursor.visible = true;
    }

    public void Play()
    {
        sound1.Play();
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        sound2.Play();
        Application.Quit();
    }
}
