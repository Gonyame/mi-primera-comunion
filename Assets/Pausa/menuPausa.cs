using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject MenuPausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reaunudar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        MenuPausa.SetActive(true);
    }

    public void Reaunudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        MenuPausa.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Jaz");
    }

    public void Quit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
