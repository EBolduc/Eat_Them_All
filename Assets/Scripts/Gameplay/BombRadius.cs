using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadius : MonoBehaviour
{
    [SerializeField] Rigidbody2D wormBody, scarabeBody, flyBody, bombBody;
    [SerializeField] Animator anim;
    public float powerX = 0.5f, powerY = 0.5f;
    

    void OnTriggerStay2D(Collider2D target)
    {
        Vector2 forceVector = new Vector2(powerX, powerY);
        if (target.tag == TagManager.FOOD_TAG || target.tag == TagManager.WORM_TAG || target.tag == TagManager.BOMB_TAG)
        {
            if (anim.GetBool("Flame") == true)
            {
                StartCoroutine (ForceApplied());
            } 
        }

        IEnumerator ForceApplied()
        {
            yield return new WaitForSeconds(1f);
            target.attachedRigidbody.AddRelativeForce(forceVector, ForceMode2D.Force);
        }
    }







}//class
