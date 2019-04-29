using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadius : MonoBehaviour
{

    [SerializeField] Rigidbody2D wormBody, scarabeBody, flyBody, bombBody;
    [SerializeField] Animator anim;
    public float powerX = 3f, powerY = 1f;

   

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
     
    }

    void OnTriggerStay2D(Collider2D target)
    {

        //condition that checks if animator parameter Flame is true so it only triggers if bomb is in explode animation
        //Right now it is propulsing the scarabe but other objects deactivate too fast as soon as the bomb is in contact with them

        if (anim.GetBool(TagManager.FLAME_TAG) == true)
        {
            //propulseCollider.SetActive(true);

            if (target.tag == TagManager.FOOD_TAG || 
                target.tag == TagManager.WORM_TAG ||
                target.tag == TagManager.BOMB_TAG)
            {
                
                StartCoroutine (ForceApplied());
               
                //target.attachedRigidbody.transform.gameObject.SetActive(false);
            }

           
            IEnumerator ForceApplied()
            {
                yield return new WaitForSeconds(1f);
                target.attachedRigidbody.AddRelativeForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);
                Lose.canLose = false;

            }
         
               
            

        }
     
    }

    
   
    
  

}//class
