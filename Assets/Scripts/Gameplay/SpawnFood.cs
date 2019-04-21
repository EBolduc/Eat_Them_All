using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    

    public float startPositionFoodX = 0.35f;
    public float startPositionFoodY = 1f;

    void Start()
    {
        SpawnFoods();
    }

    void Update()
    {
        
    }


    public void SpawnFoods ()
    {
        GameObject nextFood = (GameObject)Instantiate(Resources.Load(GetRandomFood(), typeof(GameObject)), new Vector2(startPositionFoodX, startPositionFoodY), Quaternion.identity);
    }


    string GetRandomFood()
    {
        int randomFood = Random.Range(1, 4);

        string randomFoodName = "Prefabs/Burger";

        switch (randomFood)
        {
            case 1:
                randomFoodName = "Prefabs/Burger";
                break;
            case 2:
                randomFoodName = "Prefabs/Bread";
                break;
            case 3:
                randomFoodName = "Prefabs/Chicken";
                break;
        }

        return randomFoodName;

    }



}
