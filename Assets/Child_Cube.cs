using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Cube : MonoBehaviour
{
    float speed = 10;
    public Transform parentTransform;
    void Start()
    {
        //this is global position
        transform.position = new Vector3(-2,.51f,-2);
        //position also has transform.localPosition, transform.localPosition = Vector3.zero would snap you to the parent, localPosition 0 means 0 offset from the parent
        //how to set a parent
        //transform.parent = parentTransform;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        //HandleRotate();
    }

    void HandleMovement(){
        //ChaseParent();
    }

    void ChaseParent(){
        Vector3 displacementFromTarget = parentTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed;
        if(displacementFromTarget.magnitude > 1f){
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    void HandleRotate(){
        //transform.eulerAngles += new Vector3(0,180 * Time.deltaTime, 0);
        //better way to write it
        //transform.eulerAngles += new Vector3(0,1,0) * 180 * Time.deltaTime;
        //shorthanded to
        //transform.eulerAngles += Vector3.up * 180 * Time.deltaTime;
        //can als use Vector3.left .down etc
        //and the proper way to do it with .rotate
        transform.Rotate(Vector3.up * Time.deltaTime * 180);
        
    }
}
