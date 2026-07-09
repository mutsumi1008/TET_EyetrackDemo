using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//取得値->座標返還->位置合わせはきっちりとはできていません
//いくつかあるオブジェクトは、画面内座標値の目安として設置しています

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


    void OnClose(){
        //Escキー Binded
        Debug.Log( "QUIT");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TC.TET.values.frame.avg.x);
        //
        //TET client returns gaze position based on display coordinates
        float Fx = TC.TET.values.frame.avg.x;
        float Fy = TC.TET.values.frame.avg.y;
        Gx = mFactor*(Fx/Sx - 0.5f);
        Gy = -1.0f*mFactor*(Fy/Sy -0.5f);
        rb.position = new Vector3( Gx, Gy, 0.0f);
        //Debug.Log(Fx+" "+ Fy+" - "+Gx + " " + Gy);
    }
}
