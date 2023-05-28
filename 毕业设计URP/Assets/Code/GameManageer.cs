using System;
using System.Collections;
using System.Collections.Generic;
using Code.util;
using UnityEngine;

using NetMQ;
using NetMQ.Sockets;
using UnityEngine.Rendering;

/*
 * 同样用于进行视频传输
 */
public class GameManageer : MonoBehaviour
{
    public int port = 5558; // ZeroMQ端口号
    public int width = 1440; // 图像宽度
    public int height = 1080; // 图像高度
            
  

    private byte[] imgData;
    public bool trans_frame = false; 
    
    public RenderTexture targetTexture; // 设置为相机的目标纹理

    private Texture2D resultTexture;

    private void Awake()
    {
        resultTexture = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.RGBA32, false);
    }
    void Start() {
        //设置屏幕大小：
        Screen.SetResolution(width, height, false);

        // 创建ZeroMQ的PUSH套接字
        PushSocket pushSocket = new PushSocket();
        pushSocket.Bind($"tcp://*:{port}");
        // 开始协程，循环发送图像数据
        StartCoroutine(SendImage(pushSocket));
    }
    private void Update()
    {
        // 异步复制目标纹理的数据到系统内存中
        //AsyncGPUReadback.Request(targetTexture, 0, TextureFormat.RGBA32, OnCompleteReadback);
    }
    

    private void OnCompleteReadback(AsyncGPUReadbackRequest request)
    {
        if (request.hasError)
        {
            Debug.Log("GPU readback error detected.");
            return;
        }

        // 将读取到的数据保存到结果纹理中
        resultTexture.LoadRawTextureData(request.GetData<uint>());
        resultTexture.Apply();
        

        // 在此处可以将结果纹理传递给C++程序进行分析
        // ...

        // 释放请求的资源
        //request.Dispose();
    }
  

    IEnumerator SendImage(PushSocket pushSocket) {
        while (true)
        {
            if (trans_frame)
            {
                // 从屏幕输出中捕获图像
                
              
                Texture2D screenCapture = ScreenCapture.CaptureScreenshotAsTexture();
               
              
                imgData = screenCapture.EncodeToJPG();

                // 发送图像数据
                pushSocket.TrySendFrame(imgData);
        
                Destroy(screenCapture);
                
            }
            yield return null;
            //yield return new WaitForSeconds(0.01f);
        }
    }

    public void send_test()
    {
        Debug.Log("wtf???");
    }

   

    private void OnGUI()
    {
        /*GUI.DrawTexture(new Rect(0, 0, width, height), tex);*/
    }
    /*void Start() {
        StartCoroutine(MyCoroutineFunction());
    }

    IEnumerator MyCoroutineFunction() {
        while (true)
        {
            Debug.Log("Coroutine started");

            yield return new WaitForSeconds(1);   
            
            Debug.Log("Coroutine ended");
        }
  

       
    }*/
}
