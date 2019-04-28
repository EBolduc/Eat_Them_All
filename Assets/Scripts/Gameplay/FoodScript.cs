using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
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
        //|| transform.position.y >=maxY
        if (transform.position.y <= minY ) {
            gameObject.SetActive(false);
        }
    }














































}//class
