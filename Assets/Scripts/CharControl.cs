using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CharControl : MonoBehaviour
{
    public Transform myTransform;              // this transform
    public Vector3 destinationPosition;        // The destination Point
    public float destinationDistance;          // The distance between myTransform and destinationPosition

    public float moveSpeed;                     // The Speed the character will move
    public ThirdPersonCharacter controller;



    void Start()
    {
        myTransform = transform;                            // sets myTransform to this GameObject.transform
        destinationPosition = myTransform.position;         // prevents myTransform reset
        controller = this.GetComponent<ThirdPersonCharacter>();
        moveSpeed = 0;
    }

    void Update()
    {

        // keep track of the distance between this gameObject and destinationPosition
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (destinationDistance < .25f)
        {       // To prevent shakin behavior when near destination
            moveSpeed = 0;
        }
        else if (destinationDistance > .25f)
        {           // To Reset Speed to default
            moveSpeed = 30;
        }


        // Moves the Player if the Left Mouse Button was clicked
        if (Input.GetMouseButtonDown(0) )
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform.tag == "Terrain")
                {
                    destinationPosition = hit.point;
                    destinationPosition.y = myTransform.position.y;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationPosition - transform.position);
                    myTransform.rotation = targetRotation;
                }
                if (hit.transform.tag == "HealthPickup") {
                    destinationPosition = hit.point;
                    destinationPosition.y = myTransform.position.y;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationPosition - transform.position);
                    myTransform.rotation = targetRotation;
                }
       
            }
        }

        // To prevent code from running if not needed



    }
    void FixedUpdate()
    {
        MovePlayer();

        
    }


    void MovePlayer()
    {
        //Works but teleports
       // myTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        controller.Move(controller.transform.forward * moveSpeed * Time.deltaTime, false, false);
    }
}