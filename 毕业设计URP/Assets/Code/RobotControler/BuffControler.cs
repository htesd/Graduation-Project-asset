 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
 using System.Threading;
 using Code.RobotControler;
using Code.RobotControler.RobotState;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Code.util;
public class BuffControler : RoboControler
{

    // Start is called before the first frame update
    public bool buff_rotation = false;
    public float rotationbalace = 1.0f;
    public float time_counter=0.0f;
    int active_num = 0;
    //buff rotation
    public Transform buff_base;
    public FanControler[] bufffans;
  
    public override void change_state(RoboState state)
    {
        this.state = state;
    }
    
    
    void Start()
    {
        
        bufffans = new FanControler[5];
        int fan_bum = 0;
        
        //find object
        for (int i = 0; i < transform.childCount; i++)
        {    
            Transform tempchild = transform.GetChild(i);
            
            if (tempchild.name=="buff_base")
            {
                buff_base = transform.GetChild(i);
            }
            
        }

        List<Transform> fan_transform = UtilsForGameobject.getallChildren_by_keyword(this.transform, "fan_blade");


        if (fan_transform.Count == 5)
        {
            for (int i = 0; i < fan_transform.Count; i++)
            {
                this.bufffans[i] = fan_transform[i].GetComponent<FanControler>();
            }
        }
        //初始化状态
        change_state(Buff_activeing.buff_activing);
        //确认激活状态
        foreach (FanControler buff_fan in bufffans)
        {
            if (buff_fan.is_active==true)
            {
                active_num += 1;
            }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.state.On_update(this);
    }
    
    
    
    
    /// <summary>
    /// return the rotation of the buff_rotation
    /// </summary>
    /// <returns></returns>
    public void buff_rotation_stop()
    {
        buff_rotation=!buff_rotation;

        /*return buff_rotation;*/
    }

    public void buff_rotation_reset()
    {
        this.time_counter = 0.0f;
        buff_rotation=false;
    }

    
    
    public void randam_active()
    {
            
        int fan_num = Random.Range(0, 5);
        int ring_num = Random.Range(0, 9);
        
        bufffans[fan_num].turn_lightring_onbynum(ring_num);

    }
    /// <summary>
    /// 保证每次只有一个
    /// </summary>
    public void randam_active_normal()
    {
            
        int fan_num = Random.Range(0, 5);
        int ring_num = Random.Range(0, 9);
  
        bufffans[fan_num].turn_lightring_onbynum(ring_num);

    }
    
    


}
