using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    public static SpawnFood instance;

    public float startPositionFoodX = -1f, startPositionFoodY = 20f;

    public GameObject selectedFood, nextFood;
    public GameObject[] foods;
    public int currentFoodArrayIndex;
    int prefabCount = 56;

    void Awake()
    {
        MakeInstance();
        InitiateFoods();
    }

    void Start()
    {
       //StartSpawningFood();-----------------------------------------
    }

    void Update()
    {
        
    }

    void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void InitiateFoods() {
        ShuffleFoods(foods);
        for (int i = 0; i < foods.Length; i++) {
            foods[i].SetActive(false);
        }
        selectedFood = foods[0];
        selectedFood.transform.position = new Vector2(startPositionFoodX, startPositionFoodY);
        selectedFood.SetActive(true);
    }

    void ShuffleFoods(GameObject[] arrayToShuffle) {
        for (int i = 1; i < foods.Length; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

  
    
    public void SpawnNewFood() {

        if (currentFoodArrayIndex < foods.Length - 1)
        {
            currentFoodArrayIndex++;

            if (!foods[currentFoodArrayIndex].activeInHierarchy) {
                selectedFood = foods[currentFoodArrayIndex];
                foods[currentFoodArrayIndex].transform.position = new Vector2(startPositionFoodX, startPositionFoodY);
                foods[currentFoodArrayIndex].SetActive(true);
            }


        } else
        {
            selectedFood = foods[0];
            currentFoodArrayIndex = 0;
            if (!foods[currentFoodArrayIndex].activeInHierarchy)
            {
                foods[currentFoodArrayIndex].transform.position = new Vector2(startPositionFoodX, startPositionFoodY);
                foods[currentFoodArrayIndex].SetActive(true);
            }
            
        }
    }

    

    /*------------------------------------------------------------------
        public void StartSpawningFood()
        {
            Instantiate(foods[Random.Range(0, foods.Length)],
            new Vector3(startPositionFoodX, startPositionFoodY, 0f), Quaternion.identity);


        }
    -------------------------------------------------------------------*/



}
