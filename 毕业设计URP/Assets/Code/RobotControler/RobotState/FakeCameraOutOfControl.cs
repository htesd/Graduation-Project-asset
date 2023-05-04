using Code.RobotControler.Senser;
using Code.RobotControler.Senser;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Code.RobotControler.RobotState
{
    public class FakeCameraOutOfControl : CameraState
    {
        
        public float  rotation_sensitivity = 3f ;
        public float move_speed = 10.0f;
        private float xRotation = 0.0f;
        private float yRotation = 0.0f;
        public FakeCamera camera;

        public FakeCameraOutOfControl(FakeCamera f)
        {
            this.camera = f;
        }
        
        public override void On_update()
        {
            //Input.GetAxis("MouseX")获取鼠标移动的X轴的距离
            
            xRotation -= Input.GetAxis("Mouse X")*rotation_sensitivity ;
            yRotation += Input.GetAxis("Mouse Y") * rotation_sensitivity;
            //欧拉角转化为四元数
            Quaternion rotation = Quaternion.Euler(-yRotation, -xRotation, 0);
            camera.transform.rotation = rotation;
            
            
            camera.transform.Translate(Vector3.forward * Input.GetAxis("Vertical")*move_speed*Time.deltaTime  );
            camera.transform.Translate(Vector3.right * Input.GetAxis("Horizontal")*move_speed*Time.deltaTime  );
            
            
            if (Input.GetKey("e"))
            {
                camera.transform.Translate(Vector3.up*move_speed*Time.deltaTime);
            }
            if (Input.GetKey("q"))
            {
                camera.transform.Translate(Vector3.down*move_speed*Time.deltaTime);
            }

        }

        public override void enter_state()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public override void quite_state()
        {
           
        }
    }
}