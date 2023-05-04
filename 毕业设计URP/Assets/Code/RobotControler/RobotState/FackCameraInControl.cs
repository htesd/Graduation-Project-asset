using Code.RobotControler.Senser;

namespace Code.RobotControler.RobotState
{
    public class FackCameraInControl : CameraState
    {
        
        public FakeCamera camera;

        public FackCameraInControl(FakeCamera f)
        {
            this.camera = f;
            
        }

        public override void On_update()
        {
            
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