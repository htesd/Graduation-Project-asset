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
            //通过不断的计算最短路径可以确定方向可以得到一个比较好的前进曲线//如果大于一个值就采用位移，小于一个值就采用固定位置 
            
            Vector3 trans_vector = this.camera.car.head_position - this.camera.transform.position;
           

            if (trans_vector.magnitude > 0.01f) // 你可以根据需要调整这个阈值
            {
                // trans_vector=trans_vector.normalized;
                this.camera.transform.Translate(trans_vector * Time.deltaTime);
                this.camera.transform.LookAt(this.camera.car.head_position);
            }
            // Vector3 position = this.camera.car.head_position + new Vector3(this.camera.car.camera_x,
            //    this.camera.car.camera_y, this.camera.car.camera_z);
            
            // this.camera.transform.position = position;

        }

        public override void enter_state()
        {
            
            
          
             
            
        }

        public override void quite_state()
        {
            
        }
        
    }
}