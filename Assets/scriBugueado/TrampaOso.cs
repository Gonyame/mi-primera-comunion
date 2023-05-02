using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacion : MonoBehaviour
{
    public GameObject objetoAnimado;
    private Animator animator;
    private Animator anim;

    void Start()
    {
        anim = objetoAnimado.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //animator.SetTrigger("ActivarAnimacion");
            anim.SetTrigger("cerrandotrampa");

        }
    }
}