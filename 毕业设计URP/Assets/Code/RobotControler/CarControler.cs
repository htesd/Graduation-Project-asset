using System;
using System.Collections;
using System.Collections.Generic;
using Code.RobotControler;
using Code.util;
using UnityEngine;

public class CarControler : RoboControler
{   
    
    
    public WheelCollider[] wheelColliders;
    public Transform[] wheelMeshes;
    public float motorTorque = 1f;
    public float rotationSpeed = 5f;
    public float forwardExtremumSlip = 0.4f;
    public float forwardExtremumValue = 1.0f;
    public float forwardAsymptoteSlip = 0.8f;
    public float forwardAsymptoteValue = 0.5f;
    public float forwardStiffness = 1f;
    public float sidewaysExtremumSlip = 0.2f;
    public float sidewaysExtremumValue = 1.0f;
    public float sidewaysAsymptoteSlip = 0.5f;
    public float sidewaysAsymptoteValue = 0.75f;
    public float sidewayStiffness = 1f;
    public float camera_x=0;
    public float camera_y=0;
    public float camera_z=-0.1f;
    public Vector3 head_position;

    
    private float rotationInput;
    private float Angle = 0.0f;


    private RoboState State = null;
    
    private void Start()
    {
        //设置车辆的属性
        for (int i = 0; i < wheelColliders.Length; i++)
        {

            WheelFrictionCurve forwardFriction = new WheelFrictionCurve();
            
            forwardFriction.extremumSlip=this.forwardExtremumSlip;
            forwardFriction.extremumValue=this.forwardExtremumValue;
            forwardFriction.asymptoteSlip=this.forwardAsymptoteSlip;
            forwardFriction.asymptoteValue=this.forwardAsymptoteValue;
            forwardFriction.stiffness=this.forwardStiffness;
            
            WheelFrictionCurve sidewayFriction = new WheelFrictionCurve();
            sidewayFriction.extremumSlip=this.sidewaysExtremumSlip;
            sidewayFriction.extremumValue=this.sidewaysExtremumValue;
            sidewayFriction.asymptoteSlip=this.sidewaysAsymptoteSlip;
            sidewayFriction.asymptoteValue=this.sidewaysAsymptoteValue;
            sidewayFriction.stiffness=this.sidewayStiffness;

            
            
            // Debug.Log("hahahahahaha!");
            // Debug.Log(wheelColliders[i].forwardFriction.extremumValue);
            // Debug.Log(wheelColliders[i].forwardFriction.extremumSlip);
            // Debug.Log(wheelColliders[i].forwardFriction.asymptoteSlip);
            // Debug.Log(wheelColliders[i].forwardFriction.asymptoteValue);
            // Debug.Log(wheelColliders[i].forwardFriction.stiffness);
            wheelColliders[i].forwardFriction = forwardFriction;
            wheelColliders[i].sidewaysFriction = sidewayFriction;
            // Debug.Log("hahahahahaha!");
            // Debug.Log(wheelColliders[i].forwardFriction.extremumValue);
            // Debug.Log(wheelColliders[i].forwardFriction.extremumSlip);
            // Debug.Log(wheelColliders[i].forwardFriction.asymptoteSlip);
            // Debug.Log(wheelColliders[i].forwardFriction.asymptoteValue);
            // Debug.Log(wheelColliders[i].forwardFriction.stiffness);
            //初始化相机参数
            Transform head = UtilsForGameobject.getallChildren_by_keyword(this.transform, "head")[0];

            this.head_position = head.transform.position;


        }
        
     
        
    }

    //理论上来说这里被控制单位不应该有update
    void Update()
    {
        
        /*
        rotationInput = 0f;
        

        float rotation_input = 60;

        
        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput += rotationSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationInput -= rotationSpeed;
        }
        */
      
    }

    public void act_vertical_and_horizontal(float forwardInput,float horizontalinput)
    {
       
        
        for (int i = 0; i < wheelColliders.Length; i++)
        {

            if (forwardInput>0)
            {
                wheelColliders[i].steerAngle = Mathf.Rad2Deg*Mathf.Asin(horizontalinput/Mathf.Sqrt((Mathf.Pow(forwardInput,2)+Mathf.Pow(horizontalinput,2))));

            }
            else
            {
                wheelColliders[i].steerAngle = -Mathf.Rad2Deg*Mathf.Asin(horizontalinput/Mathf.Sqrt((Mathf.Pow(forwardInput,2)+Mathf.Pow(horizontalinput,2))));

            }

            Debug.Log(horizontalinput);
            Debug.Log(forwardInput);

            if (horizontalinput>0)
            {
                if (forwardInput>0)
                {
                    wheelColliders[i].motorTorque = -this.motorTorque/2*forwardInput-horizontalinput*this.motorTorque/2;
                }
                else
                {
                    wheelColliders[i].motorTorque = -this.motorTorque / 2 * forwardInput +
                                                    horizontalinput * this.motorTorque / 2;
                }
            }
            else
            {
                if (forwardInput>0)
                {
                    wheelColliders[i].motorTorque = -this.motorTorque / 2 * forwardInput + horizontalinput * this.motorTorque / 2;
                }
                else
                {
                    wheelColliders[i].motorTorque = -this.motorTorque/2*forwardInput-horizontalinput*this.motorTorque/2;
                }
            }
            
            
        }


    }


    public override void change_state(RoboState state)
    {   
        state.quite_state();
        this.state = state;
        this.state.enter_state();
    }
}
