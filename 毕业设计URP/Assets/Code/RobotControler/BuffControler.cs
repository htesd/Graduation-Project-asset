 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Code.RobotControler;
using Code.RobotControler.RobotState;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class BuffControler : RoboControler
{

    // Start is called before the first frame update
    public bool buff_rotation = false;
    public float rotationbalace = 1.0f;
    //buff rotation
    public Transform buff_base;
    public FanControler[] bufffans;
    public float time_counter=0;

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
            
            if (Regex.Match(tempchild.name, @"buff_fan_blade").Success)
            {
                bufffans[fan_bum] = tempchild.GetComponent<FanControler>();
            }

        }
        
        
        //初始化状态
        
        change_state(Buff_activeing.buff_activing);
        
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
            
        int fan_num = Random.Range(0, 4);
        int ring_num = Random.Range(0, 9);
        Debug.Log(fan_num);
        Debug.Log(ring_num);
        Debug.Log(bufffans.Length);
        bufffans[fan_num].turn_lightring_onbynum(ring_num);

    }


}
