using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject != SpawnFood.instance.selectedFood && target.tag == TagManager.FOOD_TAG)
        {
            target.gameObject.SetActive(false);
            SpawnFood.instance.SpawnNewFood();
        }
        else {
            target.gameObject.SetActive(false);
        }
    }
}
