using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public GameObject chairPreFab;
    void Start()
    {
        
    }


    void Update()
    {
        SpawnChairs();
    }

    void SpawnChairs(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 3.4f, Random.Range(-10f, 10f));
            Vector3 spawnRot = Vector3.up * Random.Range(0,360);
            //Instantiate method actually creates something in the game
            Instantiate(chairPreFab, spawnPos, Quaternion.Euler(spawnRot));
            //often you will want to keep track of what you instantiate
            //Instantiate() returns an object (not a GameObject) you must explicitly cast the object back to a gameobject if u want gameobj funcs
            GameObject newChair = (GameObject)Instantiate(chairPreFab, spawnPos, Quaternion.Euler(spawnRot));
            //its that easy to cast, just put the desired type in () before what youre casting
            newChair.transform.parent = transform;
        }
    }
}
