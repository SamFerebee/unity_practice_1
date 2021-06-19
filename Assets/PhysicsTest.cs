using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Rigidbody myRigidBody;
    Vector3 velocity;
    float speed = 10;
    void Start()
    {
        transform.position = new Vector3(-3,.51f,-3);
        myRigidBody = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
    }

    //FixedUpdate gets called at a constant rate
    void FixedUpdate(){
        //myRigidBody.position += velocity * Time.deltaTime;
        myRigidBody.transform.Translate(velocity * Time.deltaTime, Space.World); 
        //some shapes will rotate when collidign with others, click on the component in unity, go to rigidbody, constraint settings and freeze
        //if you want your object to ignore collision with something, but still have the collision detected, go to the object you want to ignore in unity, in box collector heading check off Trigger      
    }
    void HandleMovement(){
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;
        
    }


}

//OnTriggerEnter is a function that auto runs if the object hits a trigger/is triggered
//can only use if physics is turned of, but if you dont actually want physics on the object select the is Kinematic option in the component in unity under rigid body header

//when we use ontriggerenter we also need to know what triggered it since there will be many diff triggers, we use tags
//in inspector in unity create a tag then in an object give them the tag
//then in your ontrigger use triggercollidert.ag
// void OnTriggerEnter(Collider triggerCollider){
//     if(triggerCollider.tag == "Coin"){
            //Destroy(triggerCollider.gameObject);
//     }
// }
//collider.gameObject gives you the gameobject tied to that trigger