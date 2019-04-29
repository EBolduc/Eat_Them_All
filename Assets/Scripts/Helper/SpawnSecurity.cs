using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecurity : MonoBehaviour
{

    
    private float timeElapsed;
    private bool newObject;
    public int spawnSecurityTime = 250;

    private GameObject spawnFood;

    private void Awake()
    {
        
    }


    void Update()
    {
       
        if (newObject == true)
        {
            timeElapsed = 0f;
        }
        else
        {
            timeElapsed++;
        }

        newObject = false;
        print(timeElapsed);


        SpawnMissingObject();
    }


    private void OnTriggerEnter2D(Collider2D target)
    {

        if(target.tag == TagManager.FOOD_TAG ||
            target.tag == TagManager.WORM_TAG ||
            target.tag == TagManager.BOMB_TAG)
        {
            newObject = true;
            
        }
    }


    void SpawnMissingObject()
    {
        if(timeElapsed == spawnSecurityTime)
        {
            print("Spawn");
            SpawnFood.instance.StartSpawningFood();
        }
    }

}
