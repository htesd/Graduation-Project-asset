using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class FanControler : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] lighbar_rings = new Transform[10];
    public Transform lightbar_target;
    public Transform lightbar_bound_up;
    public Transform lightbar_bound_down;
    public Transform lightbar_waterlam;
    public Transform water_light;
    public bool is_active = false;

    public Material[] materials;
    

    void Start()
    {


        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tempchild = transform.GetChild(i);

            if (Regex.Match(tempchild.name, @"[a-z]{4}").Value == "bugg")
            {

                int.TryParse(Regex.Match(tempchild.name, @"[0-9]+").Value, out int index);

                lighbar_rings[index - 1] = tempchild.GetComponent<Transform>();

               continue;
            }

            if (Regex.Match(tempchild.name, @"waterlamp").Success)
            {
                lightbar_waterlam = tempchild.GetComponent<Transform>();
               
                continue;
            }

            if (Regex.Match(tempchild.name, @"bound_up").Success)
            {
                lightbar_bound_up = tempchild.GetComponent<Transform>();
                continue;
            }
            if (Regex.Match(tempchild.name, @"bound_down").Success)
            {
                lightbar_bound_down = tempchild.GetComponent<Transform>();
                continue;
            }
            if (Regex.Match(tempchild.name, @"target").Success)
            {
                lightbar_target = tempchild.GetComponent<Transform>();
                continue;
            }
            
            if (Regex.Match(tempchild.name, @"water_light").Success)
            {
                water_light = tempchild.GetComponent<Transform>();
                continue;
            }

        }
        
        
        turn_lightbound_up_on();
        
        this.lightbar_target.gameObject.SetActive(false);


    }


        
        public bool turn_lightring_onbynum(int num)
        {
            if (num > this.lighbar_rings.Length)
            {
                return false;
            }
            else
            {
                lighbar_rings[num].gameObject.GetComponent<Renderer>().material=materials[0];
                return true;
            }
            return false;
        }
        public bool turn_lightring_offbynum(int num)
        {
            if (num > this.lighbar_rings.Length)
            {
                return false;
            }
            else
            {
                lighbar_rings[num].gameObject.GetComponent<Renderer>().material = materials[1];
                this.is_active = true;
                return true;
            }

        
        }
        
        public void turn_lightbound_up_on()
        {   
            // Debug.Log("change bound on ");

            Material[] Mat;
            Mat = new Material[4];
            for (int i = 0; i < 4;  i++)
            {
                Mat[i] = this.materials[0];
            }
            
            lightbar_bound_up.gameObject.GetComponent<Renderer>().materials = Mat;
            
              
        }
            
        
        public void turn_lightbound_up_off()
        {   
            
            // Debug.Log("change bound off ");

            Material[] Mat;
            Mat = new Material[4];
            for (int i = 0; i < 4;  i++)
            {
                Mat[i] = this.materials[1];
            }
            
            lightbar_bound_up.gameObject.GetComponent<Renderer>().materials = Mat;

            
        }
        public void turn_lightbound_down_on()
        {   
            // Debug.Log("change bound on ");

            Material[] Mat;
            Mat = new Material[4];
            for (int i = 0; i < 4;  i++)
            {
                Mat[i] = this.materials[0];
            }
            
            lightbar_bound_up.gameObject.GetComponent<Renderer>().materials = Mat;
            
              
        }
            
        
        public void turn_lightbound_down_up_off()
        {   
            
            // Debug.Log("change bound off ");

            Material[] Mat;
            Mat = new Material[4];
            for (int i = 0; i < 4;  i++)
            {
                Mat[i] = this.materials[1];
            }
            
            lightbar_bound_up.gameObject.GetComponent<Renderer>().materials = Mat;

            
        }
        public void turn_lighttarget_on()
        {
            lightbar_target.gameObject.GetComponent<Renderer>().material = materials[0];
            
        }
            
        
        public void turn_lighttarget_off()
        {
            lightbar_target.gameObject.GetComponent<Renderer>().material = materials[1];
          
        }
        
        public void turn_lightwatterlam_on()
        {
            lightbar_waterlam.gameObject.GetComponent<Renderer>().material = materials[0];
           
        }
            
        
        public void turn_lightwatterlam_off()
        {
            lightbar_waterlam.gameObject.GetComponent<Renderer>().material = materials[1];
           
        }
        
        public void turn_water_light_on()
        {
            water_light.GetComponent<Renderer>().material = materials[0];
            
        }
            
        
        public void turn_water_light_off()
        {
            water_light.GetComponent<Renderer>().material = materials[1];
           
        }
        
        
        //整合状态
        public void enter_target_mode()
        {
            
        }
        
        
        
        
        


    }

