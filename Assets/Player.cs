using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10;
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        //how to set scale
        //transform.localScale = new Vector3(2,2,2)
        // aka
        transform.localScale = Vector3.one * 2;
    }

    // Update is called once per frame
    void Update()
    {
       HandleMovement();
       //HandleRotate();
    }

    void HandleMovement(){
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount, Space.World);
    }

    void HandleRotate(){
        //transform.Rotate(Vector3.up * Time.deltaTime * 180);
        //rotate works in local (or object) space, you so if the parent is rotated it will rotate the others based on the parents rotation, change this way
        transform.Rotate(Vector3.up * Time.deltaTime * 180, Space.World);
        //transform.Translate(Vector3.forward * Time.deltaTime * 7, Space.World);
    }
}
