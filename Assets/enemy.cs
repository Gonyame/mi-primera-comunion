using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float detectionDistance = 5f;
    public float stoppingDistance = 1f;
    private bool isFollowing = false;
    Animator animacion;

    private void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionDistance && distanceToTarget > stoppingDistance)
        {
            isFollowing = true;
            animacion.SetBool("siguiendo", true);
        }
        else
        {
            isFollowing = false;
            animacion.SetBool("siguiendo", false);
        }
        if (isFollowing)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (transform.position.x - target.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
