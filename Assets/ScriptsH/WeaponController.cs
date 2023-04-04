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
    public GameObject Door;

    [SerializeField] private Animator anim;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (PickedUp == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

            if (Input.GetButtonDown("Fire1") && bulletCount > 0)
            {
                Shoot(mousePos - transform.position);
            }
        
            timer += Time.deltaTime;

            if (Door != null && PickedUp)
            {
                Door.SetActive(false); // Deactivate the door
            }
        }

        

    }

    public void Shoot(Vector3 direction)
    {
        // Fire a bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;

        anim.SetTrigger("Shoot");
            
        bulletCount--;
            
        if (bulletCount == 0)
        {
            // Destroy the weapon add a delay
            Destroy(gameObject, 1f);
        }
    }
}

