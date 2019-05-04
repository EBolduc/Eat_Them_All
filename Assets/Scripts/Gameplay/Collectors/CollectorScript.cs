using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject != SpawnFood.instance.selectedFood && target.tag == TagManager.FOOD_TAG || target.tag == TagManager.WORM_TAG || target.tag == TagManager.SCARABE_TAG)
        {
            target.gameObject.SetActive(false);
            StartCoroutine(SpawnDelay());
        }
        else {
            target.gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnDelay() {
        yield return new WaitForSeconds(1f);
        SpawnFood.instance.SpawnNewFood();
    }




























}//class
