using Code.RobotControler.Senser;

namespace Code.RobotControler.RobotState
{
    public class FakeCameraOutOfControl : CameraState
    {
        
        public FakeCamera camera;

        public FakeCameraOutOfControl(FakeCamera f)
        {
            this.camera = f;
        }
        
        public override void On_update()
        {
            

        }

        public override void enter_state()
        {
            
        }

        public override void quite_state()
        {
           
        }
    }
}