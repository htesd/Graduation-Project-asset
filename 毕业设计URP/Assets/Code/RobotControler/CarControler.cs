using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
   
   public WheelCollider[] wheelColliders;
    public float motorTorque = 200f;
    public float rotationSpeed = 5f;
    public float strafeSpeed = 1f;

    private float forwardInput;
    private float sidewaysInput;
    private float rotationInput;

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical") * motorTorque;
        sidewaysInput = Input.GetAxis("Horizontal") * strafeSpeed;

        rotationInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationInput += rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationInput -= rotationSpeed;
        }

        DriveMecanumWheels();
    }

    void DriveMecanumWheels()
    {
        /*float frontLeft = forwardInput + rotationInput + sidewaysInput;
        float frontRight = forwardInput - rotationInput - sidewaysInput;
        float rearLeft = forwardInput + rotationInput - sidewaysInput;
        float rearRight = forwardInput - rotationInput + sidewaysInput;*/
        float frontLeft = -forwardInput ;
        float frontRight = forwardInput ;
        float rearLeft = -forwardInput ;
        float rearRight = forwardInput ;

        wheelColliders[0].motorTorque = frontLeft;
        wheelColliders[1].motorTorque = frontRight;
        wheelColliders[2].motorTorque = rearLeft;
        wheelColliders[3].motorTorque = rearRight;

        /*// Apply sideways force
        wheelColliders[0].GetGroundHit(out WheelHit hit);
        Vector3 lateralForce = -hit.sidewaysDir * sidewaysInput;
        wheelColliders[0].attachedRigidbody.AddForceAtPosition(lateralForce, hit.point);

        wheelColliders[1].GetGroundHit(out hit);
        lateralForce = -hit.sidewaysDir * sidewaysInput;
        wheelColliders[1].attachedRigidbody.AddForceAtPosition(lateralForce, hit.point);

        wheelColliders[2].GetGroundHit(out hit);
        lateralForce = -hit.sidewaysDir * sidewaysInput;
        wheelColliders[2].attachedRigidbody.AddForceAtPosition(lateralForce, hit.point);

        wheelColliders[3].GetGroundHit(out hit);
        lateralForce = -hit.sidewaysDir * sidewaysInput;
        wheelColliders[3].attachedRigidbody.AddForceAtPosition(lateralForce, hit.point);*/
    }
}
