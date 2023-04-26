using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void NotifyCallback();
public class RingSenser : MonoBehaviour
{
    public NotifyCallback Callback;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.contacts[0].point);
        if (transform.parent.transform.GetComponent<FanControler>().active_state!=1)
        {
            Debug.Log("无法激活！");
        }
        else
        {
            transform.parent.transform.GetComponent<FanControler>().active_state = 2;
            this.Callback();
        }
        
    }
}
