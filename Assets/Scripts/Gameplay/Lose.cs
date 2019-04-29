using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public float minY = -25f;
    public float maxY = 21f;

    private GameObject bomb;
    private GameObject food;

    static public bool canLose = true;
    private float timeTriggered = 0f;

  

    void Awake()
    {
        bomb = GameObject.FindWithTag(TagManager.BOMB_TAG);
        bomb = GameObject.FindWithTag(TagManager.FOOD_TAG);
    }

    
    void Update()
    {
        print("canLose : " + canLose);
        SetCanLoseTrue();
        LoseByBomb();
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if ((target.tag == TagManager.FOOD_TAG ||
            target.tag == TagManager.WORM_TAG ) &&
            canLose == true)
        {
            print("GAME OVER!!!");
            Time.timeScale = 0f;
        }
    }

  /*  private void DeactivateObject()
    {
        if (food.transform.position.y <= minY || food.transform.position.y >=maxY)
        {
            food.SetActive(false);
        }
    }
*/
    private void LoseByBomb()
    {
        if (bomb != null)
        {
            if (bomb.transform.position.y < -25f && canLose == true)
            {
                print("GAME OVER!!!");
                Time.timeScale = 0f;
            }
        }
    }



    void SetCanLoseTrue()
    {
        if (Lose.canLose == false)
        {
            print("lose is false");
            StartCoroutine(CanLoseTiming());
        }
        else if (Lose.canLose == true)
        {
            print("coroutine stopped");
            StopCoroutine(CanLoseTiming());
        }

        IEnumerator CanLoseTiming()
        {
            yield return new WaitForSeconds(5f);
            print("Lose is getting true");
            Lose.canLose = true;


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
