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
    public Transform lightbar_bound;
    public Transform lightbar_waterlam;
    public Transform water_light;

    public Material[] materials;


    void Start()
    {


        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tempchild = transform.GetChild(i);

            if (Regex.Match(tempchild.name, @"[a-z]{4}").Value == "bugg")
            {
                // Debug.Log("haha!");

                // Debug.Log(Regex.Match(tempchild.name,@"[0-9]+"));

                int.TryParse(Regex.Match(tempchild.name, @"[0-9]+").Value, out int index);

                lighbar_rings[index - 1] = tempchild.GetComponent<Transform>();

               continue;
            }

            if (Regex.Match(tempchild.name, @"waterlamp").Success)
            {
                lightbar_waterlam = tempchild.GetComponent<Transform>();
                continue;
            }

            if (Regex.Match(tempchild.name, @"bound").Success)
            {
                lightbar_bound = tempchild.GetComponent<Transform>();
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

        // turn_lightring_onbynum(Random.Range(0, 10));


    }

    // Update is called once per frame
        void Update()
        {
            
            
                
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
                return true;
            }

            return false;
        }
        
        public bool turn_lightbound_on()
        {
            for (int i = 0; i < lightbar_bound.gameObject.GetComponent<Renderer>().materials.Length; i++)
            {
                lightbar_bound.gameObject.GetComponent<Renderer>().materials[i] = this.materials[0];
            }
                return true;
        }
            
        
        public bool turn_lightbound_off()
        {
            for (int i = 0; i < lightbar_bound.gameObject.GetComponent<Renderer>().materials.Length; i++)
            {
                lightbar_bound.gameObject.GetComponent<Renderer>().materials[i] = this.materials[1];
            }
            return true;
        }
        
        public bool turn_lighttarget_on()
        {
            lightbar_target.gameObject.GetComponent<Renderer>().material = materials[0];
            return true;
        }
            
        
        public bool turn_lighttarget_off()
        {
            lightbar_target.gameObject.GetComponent<Renderer>().material = materials[1];
            return true;
        }
        
        public bool turn_lightwatter_on()
        {
            lightbar_waterlam.gameObject.GetComponent<Renderer>().material = materials[0];
            return true;
        }
            
        
        public bool turn_lightwatter_off()
        {
            lightbar_waterlam.gameObject.GetComponent<Renderer>().material = materials[1];
            return true;
        }
        
        public bool water_light_on()
        {
            water_light.GetComponent<Renderer>().material = materials[0];
            return true;
        }
            
        
        public bool water_light_off()
        {
            water_light.GetComponent<Renderer>().material = materials[1];
            return true;
        }
        
        
        
        
        


    }

