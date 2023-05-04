using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackError044 : MonoBehaviour

{
    bool isClose;
    public Animator antram;
    private int forzar;
    

    void Start()
    {
        forzar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            antram.SetBool("Close", true);

            if(forzar > 0 )
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    forzar--;
                }
            }

            if (forzar == 0)
            {
                antram.SetBool("Close", false);

            }    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          isClose = true;
            forzar = 3;
        }
    }

    public void ResetTrap()
    {
        antram.SetTrigger("Idle");
    }
}
