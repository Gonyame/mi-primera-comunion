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

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionDistance && distanceToTarget > stoppingDistance)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }
        if (isFollowing)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
