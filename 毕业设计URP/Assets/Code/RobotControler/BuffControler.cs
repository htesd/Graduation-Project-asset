using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuffControler : MonoBehaviour
{

    // Start is called before the first frame update
    public bool buff_rotation = false;
    public float rotationbalace = 1.0f;
    //buff rotation
    private Transform buff_base;
    public FanControler[] bufffans;
    private float time_counter=0;


    void Start()
    {
        bufffans = new FanControler[5];
       
        //find object
        for (int i = 0; i < transform.childCount; i++)
        {    
            Transform tempchild = transform.GetChild(i);
            
            if (tempchild.name=="buff_base")
            {
                buff_base = transform.GetChild(i);
            }


        }
     
        
        /*InvokeRepeating(nameof(buff_rotation_stop),1,1);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        buff_rotate();
        
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
    
    

    private void buff_rotate()
    {
        

            if (buff_rotation)
            {
                float angle = Random.value * (float)0.265 + (float)0.75;
                float w = Random.value * (float)0.116 + (float)1.884;
                float b = (float)2.09 - angle;
                float spd = angle * math.sin(w * time_counter) + b;
                time_counter += Time.deltaTime;
                buff_base.Rotate(Vector3.left * Time.deltaTime * spd / math.PI * 180*rotationbalace);


            }
        
    }
    
    
}
