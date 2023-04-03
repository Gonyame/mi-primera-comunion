using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    public int bulletCount = 2;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;

    public float timer = 0f;

    public bool PickedUp = false;
    
    
    
    

    void Start()
    {
        
    }

    void Update()
    {
        if (PickedUp == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            transform.up = mousePos - transform.position;

            if (Input.GetButtonDown("Fire1") && bulletCount > 0)
            {
                Shoot(mousePos - transform.position);
            }
        
            timer += Time.deltaTime;
        }

        

    }

    public void Shoot(Vector3 direction)
    {
        // Fire a bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            
        bulletCount--;
            
        if (bulletCount == 0)
        {
           Debug.Log("Out of ammo"); 
        }
    }
}

