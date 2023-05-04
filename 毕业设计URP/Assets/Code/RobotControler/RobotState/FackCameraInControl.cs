using Code.RobotControler.Senser;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Code.RobotControler.RobotState
{
    public class FackCameraInControl : CameraState
    {
        
        public float  rotation_sensitivity = 3f ;
        public float move_speed = 10.0f;
        private float xRotation = 0.0f;
        private float yRotation = 0.0f;
        public FakeCamera camera;

        public FackCameraInControl(FakeCamera f)
        {
            
            this.camera = f;
            
        }

        public override void On_update()
        {
            Vector3 position =
                new Vector3(this.camera.car.camera_x, this.camera.car.camera_y, this.camera.car.camera_z);
            this.camera.transform.Translate(position);
            
        }

        public override void enter_state()
        {
            
            
          
             
            
        }

        public override void quite_state()
        {
            
        }
        
    }
}