using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Gameobject
    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollier;

    //movement
    [SerializeField]
    private float forwardSpeed = 5f;
    private Vector3 angleZ;
    private float rotateZ = 0;
    public float fallingSpeed = -2.5f;
    public float freeFallSpeed = -0.5f;


    //bool
    private bool cantMove = false;
    private bool leftLimit = false;
    private bool rightLimit = false;


    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollier = GetComponent<BoxCollider2D>();
        angleZ = GetComponent<Transform>().eulerAngles;

    }

    void Start()
    {
      
    }


    void Update()
    {
        if (cantMove == false)
        {
            //ObjectMovement();
            CheckUserInput();
        }

        Debug.Log(cantMove);

    }

/*
    void ObjectMovement()
    {

        float h = Input.GetAxisRaw("Horizontal");

      

        //go right
        if (h > 0 && rightLimit == false)
        {
            myRigidBody.velocity = new Vector2(forwardSpeed, fallingSpeed);
        }
        //go left
        else if (h < 0 && leftLimit == false)
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed, fallingSpeed);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0f, freeFallSpeed);
        }

        //rotate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }


    }

    */

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(forwardSpeed, fallingSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed, fallingSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody.velocity = new Vector2(0, fallingSpeed * 3);
        }
    }

    void SpawnNewObject()
    {

    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        //Add target tag all objects with colliders to stop the item movement
        if ((target.collider.tag == TagManager.LEVEL_COLLIDER_TAG || target.collider.tag == TagManager.FOOD_TAG) &&  cantMove == false)
        {
            cantMove = true;

            StartCoroutine(SpawnDelay());

        }
    }

    
    IEnumerator SpawnDelay()
    {
        if (cantMove == true)
        {
            yield return new WaitForSeconds(1f);
            FindObjectOfType<SpawnFood>().SpawnFoods();
        }
    }
    


    private void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.tag == TagManager.BORDER_LEFT_TAG)
        {
            leftLimit = true;
        }

        if (target.tag == TagManager.BORDER_RIGHT_TAG)
        {
            rightLimit = true;
        }

    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == TagManager.BORDER_LEFT_TAG)
        {
            leftLimit = false;
        }

        if (target.tag == TagManager.BORDER_RIGHT_TAG)
        {
            rightLimit = false;
        }
    }

}























