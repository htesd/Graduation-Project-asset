using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Code.RobotControler.RobotState
{
    public class Buff_activeing : RoboState
    {
        public static Buff_activeing buff_activing = new Buff_activeing();
        
        public void be_atacked(BuffControler controler)
        {
            
        }
        
        public void On_update(BuffControler controler)
        {
            if (controler.buff_rotation)
            {
            //保持正常旋转，同时还要保持每次只有一个扇叶可以被激活
                float angle = Random.value * (float)0.265 + (float)0.75;
                float w = Random.value * (float)0.116 + (float)1.884;
                float b = (float)2.09 - angle;
                float spd = angle * math.sin(w * controler.time_counter) + b;
                controler.time_counter += Time.deltaTime;
                controler.buff_base.Rotate(Vector3.left * Time.deltaTime * spd / math.PI * 180 * controler.rotationbalace);
            }

            
            
            

            
            
            
        }
        
        public void be_atacked(RoboControler controler)
        {
            throw new System.NotImplementedException();
        }

        public void On_update(RoboControler controler)
        {
           
        }


        public void randam_active(BuffControler controler)
        {
            
            int fan_num = Random.Range(0, 4);
            int ring_num = Random.Range(0, 9);
            controler.bufffans[fan_num].turn_lightring_onbynum(ring_num);
            

        }
        
    }
}