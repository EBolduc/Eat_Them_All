using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Animator anim;
    private bool hasExplode;
    private GameObject[] food;

    public GameObject bomb;

    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        food = GameObject.FindGameObjectsWithTag(TagManager.FOOD_TAG); 
       
    }

    private void FixedUpdate()
    {
        if(bomb == enabled)
        {
            Invoke("Detonate", 5);
        }
    }

    private void Update()
    {
        print(hasExplode);

        if (hasExplode == true)
        {
           
            print("it was a great Bomb");
        }

    }


    //DON'T WORK AGAIN, might maybe put that function in a separate script attached to the bomb
    void Detonate()
    {
        Vector3 explosionPosion = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosion, radius);
        
        foreach(Collider hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            if(rb!=null)
            rb.AddExplosionForce(power, explosionPosion, radius, upForce,ForceMode2D.Impulse);

            
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
