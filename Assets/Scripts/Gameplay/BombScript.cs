using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    static public bool hasExplode;
    private Animator anim;
    
    
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }


    private void start()
    {
        hasExplode = false;
    }
    
    // maybe need USE SINGLETONto keep the variable hasexplode


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
