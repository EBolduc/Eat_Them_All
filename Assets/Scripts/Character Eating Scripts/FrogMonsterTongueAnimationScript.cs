using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMonsterTongueAnimationScript : MonoBehaviour
{

    [SerializeField] Animator anim;



    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Food") {
            anim.Play("FrogTongueAnim");
            anim.Play("Idle");
        }

    }











































}//class
