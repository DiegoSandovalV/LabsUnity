using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    Rigidbody spaceShipRB;

    //inputs 
     float verticalMovement;
     float horizontalMovement;
     float mouseInputX;
     float mouseInputY;
     float rollInput;

    //Speeds variables
    public float speedMult = 1;
    public float sppedMultAng = 0.5f;
    public float speedRollMultAngle = 0.05f;
    public float speedRollVerticalMulstAngle = 0.1f;

    /**
    * Function Start
    * Locks the cursor to the center of the screen
    */
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        spaceShipRB = GetComponent<Rigidbody>();

    }

    /**
    * Function Update
    * Gets the inputs from the player
    */
    void Update(){
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        
    }

    /**
    * Function FixedUpdate
    * Adds the forces of movement to the spaceship
    */
    void FixedUpdate(){
        spaceShipRB.AddForce(spaceShipRB.transform.TransformDirection(Vector3.forward) * verticalMovement * speedMult, ForceMode.VelocityChange);

        spaceShipRB.AddForce(spaceShipRB.transform.TransformDirection(Vector3.right) * horizontalMovement * speedMult, ForceMode.VelocityChange);

        spaceShipRB.AddTorque(spaceShipRB.transform.right * speedRollVerticalMulstAngle * mouseInputY * -1, ForceMode.VelocityChange);
        spaceShipRB.AddTorque(spaceShipRB.transform.right * speedRollVerticalMulstAngle * mouseInputX, ForceMode.VelocityChange);

        spaceShipRB.AddTorque(spaceShipRB.transform.forward * speedRollMultAngle * rollInput, ForceMode.VelocityChange);
    }
}

