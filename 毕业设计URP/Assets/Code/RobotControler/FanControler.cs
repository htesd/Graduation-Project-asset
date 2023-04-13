using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class FanControler : MonoBehaviour
{
    // Start is called before the first frame update

    public LightControler[] lighbar_rings = new LightControler[10];
    public Transform lightbar_target;
    public Transform lightbar_bound;
    public Transform lightbar_waterlam;
    

    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tempchild = transform.GetChild(i);

            if (Regex.Match(tempchild.name,@"[a-z]{4}").Value == "bugg")
            {
                // Debug.Log("haha!");
                
                // Debug.Log(Regex.Match(tempchild.name,@"[0-9]+"));

                int.TryParse(Regex.Match(tempchild.name,@"[0-9]+").Value, out int index);

                lighbar_rings[index-1] = tempchild.GetComponent<LightControler>();
                
                Debug.Log(index);
            }


            for (int j = 0; j < lighbar_rings.Length; j++)
            { 
                

            }
            


        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
