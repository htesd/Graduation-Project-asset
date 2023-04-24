using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Code.RobotControler.RobotState
{
    public class Buff_actived : RoboState
    {
        public static Buff_actived buff_activing = new Buff_actived();
        
        public void be_atacked(BuffControler controler)
        {
            
        }
        
        public void On_update(BuffControler controler)
        {
           
        }
        
        public void be_atacked(RoboControler controler)
        {
            throw new System.NotImplementedException();
        }

        public void On_update(RoboControler controler)
        {
           
        }
    }
}