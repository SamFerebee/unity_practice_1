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
       //HandleMovement();
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

/* TALK TO OTHER SCRIPTS
if a script needs to interact with another script, there are multiple ways to find that script
want to find player of type Player
Player player
1. if you know the object name the script is attached to
GameObject playerObj = GameObject.Find("Player"); <--this returns a reference to the object
player = playerObj.GetComponent<Player>();
2. find by tag
GameObject playerObj = GameObject.FindGameObjectWithTag("player");
player = playerObj.GetComponent<Player>();
3. best way: FindObjectOfType
player = FindObjectOfType<Player>()
this will search the scene for the object to which script named player is attached
and return a reference to that instance of that script
then you can do stuff like player.whatever()
from the other script, not the player script

a great thing to do is to make an event so when something happens another script can be listening for that event and do something eg
    public event Action OnPlayerDeath;
then in update() call OnPlayerDeath() if health <= 0
in other scripts if you have a variable holding the player, you can call player.OnPlayerDeath eg
    player.OnPlayerDeath += GameOver;
this "subscribes" gameover to onplayerdeath
when onplayerdeath is invoked, all subscribers are called
this is good because for example player doesnt care about ui, it exists without it, it just needs to tell others about what its doing
if there are no subscribers to an event, when it gets invoked it will be null
so we typically check to make sure its note null
if(OnPlayerDeath != null){
    OnPlayerDeath();
}
*/