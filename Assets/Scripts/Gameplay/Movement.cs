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


    //other
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
            ObjectMovement();
        }
    }


    void ObjectMovement()
    {

        float h = Input.GetAxisRaw("Horizontal");

        //go right
        if (h > 0 && rightLimit == false)
        {
            myRigidBody.velocity = new Vector2(forwardSpeed, myRigidBody.velocity.y);
        }
        //go left
        else if (h < 0 && leftLimit == false)
        {
            myRigidBody.velocity = new Vector2(-forwardSpeed, myRigidBody.velocity.y);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }

        //rotate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, rotateZ - 90);
            rotateZ = transform.eulerAngles.z;
        }


    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == TagManager.FLOOR_TAG)
        {
            cantMove = true;
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























