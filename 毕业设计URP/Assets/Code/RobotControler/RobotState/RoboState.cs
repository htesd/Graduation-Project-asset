using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.RobotControler;
public interface RoboState
{
        public void be_atacked(RoboControler controler);

        public void On_update(RoboControler controler);

        public void be_atacked(BuffControler controler);
        
        public void On_update(BuffControler controler);


}
