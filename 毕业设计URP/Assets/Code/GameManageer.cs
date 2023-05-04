using System.Collections;
using System.Collections.Generic;
using Code.util;
using UnityEngine;
using UnityEngine.Networking;

public class GameManageer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
        Debug.Log(UtilsForGameobject.get_granfather(this.transform).name);
        if (this.GetComponent<CarControler>()==null)
        {
            Debug.Log("get null!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void send_test()
    {
        Debug.Log("wtf???");
    }
}
