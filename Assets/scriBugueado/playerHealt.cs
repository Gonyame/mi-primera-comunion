using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("oso"))
        {
            PlayerController.instance.atrapado();
            transform.position = collision.transform.position + new Vector3(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("oso"))
        {
            PlayerController.instance.atrapado();
            transform.position = collision.transform.position + new Vector3(0f, 0f, 0f);
        }
    }
}

