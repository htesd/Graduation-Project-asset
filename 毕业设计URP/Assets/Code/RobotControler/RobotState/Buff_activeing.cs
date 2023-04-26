using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Code.RobotControler.RobotState
{
    public class Buff_activeing : RoboState
    {
        
        private RoboControler roboControler;
        private BuffControler buffcontroler;
        private float timecounter_fortarget=0.0f;
        private int active_num = 0;
        
        public Buff_activeing(RoboControler r)
        {
            this.roboControler = r;
            this.buffcontroler = (BuffControler)r;
        }
        
        public override void be_atacked()
        {
            active_num = 0;
            
            //直接点亮所有被激活的
            foreach (FanControler fan in this.buffcontroler.bufffans)
            {
                if (fan.active_state==2)
                {
                    fan.enter_actived_mode();
                    active_num += 1;
                }
            }
            
            //点亮所有的符要有一个提示！
            //TODO 等待后续代码
            if (active_num==this.buffcontroler.bufffans.Length)
            {
                Debug.LogWarning("all active!");
            }
            else
            {
                //重置倒计时
                this.timecounter_fortarget = 3;
            }
        }
        
        public  override void On_update()
        {
            
            if (buffcontroler.buff_rotation)
            {
            //保持正常旋转，同时还要保持每次只有一个扇叶可以被激活
                float angle = Random.value * (float)0.265 + (float)0.75;
                float w = Random.value * (float)0.116 + (float)1.884;
                float b = (float)2.09 - angle;
                float spd = angle * math.sin(w * buffcontroler.time_counter) + b;
                buffcontroler.time_counter += Time.deltaTime;
                buffcontroler.buff_base.Rotate(Vector3.left * Time.deltaTime * spd / math.PI * 180 * buffcontroler.rotationbalace);
            }
            
            //每隔一段时间选择一个新的符
            
            if (active_num<buffcontroler.bufffans.Length)
            {
                this.timecounter_fortarget += Time.deltaTime;
                
            }
            this.timecounter_fortarget += Time.deltaTime;
            if (timecounter_fortarget>2.5)
            {
               //取消所有装甲状态，然后新增一个状态

               foreach (FanControler fan in buffcontroler.bufffans)
               {
                   fan.active_state = 0;
                   fan.enter_unaactiveable_mode();
               }

               int temp_num = Random.Range(0, buffcontroler.bufffans.Length);
            
               buffcontroler.bufffans[temp_num].active_state = 1;
               buffcontroler.bufffans[temp_num].enter_target_mode();

               this.timecounter_fortarget = 0;

            }

        }
        
    

        public void randam_active()
        {
            
            int fan_num = Random.Range(0, 4);
            int ring_num = Random.Range(0, 9);
            this.buffcontroler.bufffans[fan_num].turn_lightring_onbynum(ring_num);
            

        }
        
        public override void enter_state()
        {
            
            /*
            //确认激活状态
            foreach (FanControler buff_fan in bufffans)
                {
                    if (buff_fan.is_active==true)
                    {
                        active_num += 1;
                    }    
                }
            */
            
            //为每个传感器添加对应的响应函数.传入attacked函数
            foreach (FanControler fan in this.buffcontroler.bufffans)
            {
                fan.lighbar_rings[0].GetComponent<RingSenser>().OnBulletHit.AddListener(this.buffcontroler.state.be_atacked);
            }
            
            
        }

        public override void quite_state()
        {
            
        }
        
    }
}