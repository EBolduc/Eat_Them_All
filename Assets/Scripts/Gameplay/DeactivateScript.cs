using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScript : MonoBehaviour
{

   public float minY = -25f;
   public float maxY = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lose.canLose == false)
        {
            if (transform.position.y <= minY || transform.position.y >= maxY)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == TagManager.DEACTIVATE_LINE_TAG && Lose.canLose == false)
        {
            gameObject.SetActive(false);
        }
    }












































}//class
