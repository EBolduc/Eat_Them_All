﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public float minY = -25f;
    public float maxY = 25f;

    static public bool canLose = false;
    private float timeTriggered = 0f;

  

    void Awake()
    {
       
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.FOOD_TAG)
        {
            print("GAME OVER!!");
        }
    }

    private void DeactivateObject()
    {
        if (transform.position.y <= minY)
        {
            gameObject.SetActive(false);
        }
    }

    /*
        private void OnTriggerExit2D(Collider2D target)
        {
            canLose = false;
        }

        IEnumerator LoseDelay()
        {
            if (canLose == false)
            {
                yield return new WaitForSeconds(2f);
                canLose = true;
            }
        }

        private void OnTriggerStay2D(Collider2D target)
        {
            if (target.tag == TagManager.LOOSE_TAG)
            {
                timeTriggered += Time.deltaTime;
            }

            if (timeTriggered > 3)
            {
                canLose = true;
            }

        }

        public void GameLost()
        {
            if (canLose == true)
            {
                Debug.Log("Game Over");
            }
        }
            */
}
