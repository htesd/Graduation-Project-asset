using UnityEngine;

namespace Code.RobotControler
{
    public  abstract class RoboControler : MonoBehaviour
    {
        public float blood;
        public Transform controler_transform;

        //等待添加摄像机类型，暂时还没有想好,用于机器人控制和画面传输
        public RoboState state;

        public abstract void change_state(RoboState state);
        
        
        //添加通用方法
        
    }
}