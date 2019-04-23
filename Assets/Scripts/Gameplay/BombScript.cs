using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Animator anim;
    private bool hasExplode;
    private GameObject[] food;


    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        food = GameObject.FindGameObjectsWithTag(TagManager.FOOD_TAG); 
       
    }

    private void Update()
    {
        Debug.Log(hasExplode);
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.FLAME_TAG)
        {
            anim.SetBool(TagManager.FLAME_PARAMETER, true);
            hasExplode = true;
            StartCoroutine(BombDeactivate());
        }
    }

    IEnumerator BombDeactivate()
    {
       
        yield return new WaitForSeconds(1.5f);
        
        this.transform.parent.gameObject.SetActive(false);

    }

    //DOES NOT WORK
    public void OnCollisionStay2D(Collision2D target)
    {
        if(target.collider.tag == TagManager.FOOD_TAG)
        {
            if (hasExplode == true)
            {
                RaycastHit hitInfo = new RaycastHit();
               
                
                    hitInfo.transform.gameObject.SetActive(false);
                
                  //  transform.gameObject.SetActive(false);
            }
        }
    }

    
}
