using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class JuegoMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void irMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void volverJuego()
    {
        SceneManager.LoadScene("SpawningScene");
    }
    public void VolverLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}