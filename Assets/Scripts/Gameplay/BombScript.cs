using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public static BombScript instance;
    private Animator anim;
    public bool hasExplode;
    private GameObject[] food;
    
    
    
     
    void Awake()
    {

        MakeInstance();
        anim = GetComponentInParent<Animator>();
        food = GameObject.FindGameObjectsWithTag(TagManager.FOOD_TAG);
    }


    private void Update()
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

    
   

}
