using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{

    public float startPositionFoodX = 0.35f;
    public float startPositionFoodY = 2f;

    public GameObject[] foods;

    void Start()
    {
       StartSpawningFood();
    }

    void Update()
    {
        
    }

    public void StartSpawningFood()
    {
        Instantiate(foods[Random.Range(0, foods.Length)],
        new Vector3(startPositionFoodX, startPositionFoodY, 0f), Quaternion.identity);
    }


}
