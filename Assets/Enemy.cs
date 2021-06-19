using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 8;
    public Transform targetTransform;
    void Start()
    {
        transform.position = new Vector3(5,.51f,5);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement(){
        //ChaseTarget();
    }

    void ChaseTarget(){
        //1. calc direction between enemy and target 2) take our pos - their pos to get displacement 3) normalize vector to get direction
        Vector3 displacementFromTarget = targetTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed;
        if(displacementFromTarget.magnitude > 1.5f){
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
