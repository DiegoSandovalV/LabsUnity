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

    //Speeds
    [SerializeField]
    float speedMult = 1;
    [SerializeField]
    float sppedMultAng = 0.5f;
    [SerializeField]
    float speedRollMultAngle = 0.05f;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        spaceShipRB = GetComponent<Rigidbody>();

        //ignore gravity
        spaceShipRB.useGravity = false;
    }

    void Update(){
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
    }

    void FixedUpdate(){
        spaceShipRB.AddForce(spaceShipRB.transform.TransformDirection(Vector3.forward) * verticalMovement * speedMult, ForceMode.VelocityChange);

        spaceShipRB.AddForce(spaceShipRB.transform.TransformDirection(Vector3.right) * horizontalMovement * speedMult, ForceMode.VelocityChange);

        spaceShipRB.AddTorque(spaceShipRB.transform.right * speedRollMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        spaceShipRB.AddTorque(spaceShipRB.transform.right * speedRollMultAngle * mouseInputX, ForceMode.VelocityChange);

        spaceShipRB.AddTorque(spaceShipRB.transform.forward * speedRollMultAngle * rollInput, ForceMode.VelocityChange);
    }
}

