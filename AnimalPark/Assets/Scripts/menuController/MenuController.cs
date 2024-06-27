using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void config()
    {
        SceneManager.LoadScene("Config");
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void modoJogo1()
    {
        PlayerPrefs.SetInt("joystick", 1);
        PlayerPrefs.SetInt("smartwatch", 0);
        SceneManager.LoadScene("Menu");
    }
    public void modoJogo2()
    {
        PlayerPrefs.SetInt("smartwatch", 1);
        PlayerPrefs.SetInt("joystick", 0);
        SceneManager.LoadScene("Menu");

    }
}
