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
    
    

    void Update()
    {
        if (PickedUp == true)
        {
            if (Input.GetButtonDown("Fire1") && bulletCount > 0)
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
        
        timer += Time.deltaTime;
        }
        
    }
}

