using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDetener : MonoBehaviour
{
    public Animator uwu;
    public Animator uvu;
    // Start is called before the first frame update
    public void detener_uwu()
    {
        uwu.SetBool("move", true);
    }
    public void reproducir_uwu()
    {
        uwu.SetBool("move", false);
    }
    public void detener_uvu()
    {
        uvu.SetBool("move", true);
    }
    public void reproducir_uvu()
    {
        uvu.SetBool("move", false);
    }
}
