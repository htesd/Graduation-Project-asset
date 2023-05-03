namespace Code.RobotControler.RobotState
{
    public abstract class State
    {
        public abstract void On_update();
        
        public abstract void enter_state();
        
        public abstract void quite_state();
    }
}