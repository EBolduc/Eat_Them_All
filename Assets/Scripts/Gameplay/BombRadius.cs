﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadius : MonoBehaviour
{

    [SerializeField] Rigidbody2D wormBody, scarabeBody, flyBody, bombBody;
    [SerializeField] Animator anim;
    float powerX = 3f, powerY = 1f;

    private void Awake()
    {
        
    }
    void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D target)
    {
        //condition that checks if animator parameter Flame is true so it only triggers if bomb is in explode animation
        //Right now it is propulsing the scarabe but other objects deactivate too fast as soon as the bomb is in contact with them
        if (anim.GetBool(TagManager.FLAME_TAG) == true)
        {
            Debug.Log("Flame Anim Bool is True");
            
            if (target.tag == TagManager.FOOD_TAG || target.tag == TagManager.WORM_TAG)
            {

                target.attachedRigidbody.AddRelativeForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);
                //target.attachedRigidbody.transform.gameObject.SetActive(false);
                
            }

            if (target.tag == TagManager.SCARABE_TAG)
            {
                target.attachedRigidbody.AddRelativeForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);
            }
        }
    }












































}//class
