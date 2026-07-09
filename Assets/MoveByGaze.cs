using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//全画面でゲーム起動をしている前提で作成しています。

public class MoveByGaze : MonoBehaviour
{
    public TETConnect TC;
    public float mFactor=20.0f;
    float Gx, Gy;
    float Sx, Sy;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sx = 1.0f*Screen.width;
        Sy = 1.0f*Screen.height;
    }


    void onJump(){
        Debug.Log( "QUIT");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TC.TET.values.frame.avg.x);
        float Fx = TC.TET.values.frame.avg.x;
        float Fy = TC.TET.values.frame.avg.y;
        Gx = mFactor*(Fx/Sx - 0.5f);
        Gy = -1.0f*mFactor*(Fy/Sy -0.5f);
        rb.position = new Vector3( Gx, Gy, 0.0f);
        //Debug.Log(Fx+" "+ Fy+" - "+Gx + " " + Gy);
    }
}
