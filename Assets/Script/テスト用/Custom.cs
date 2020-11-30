using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom :OVRGrabbable
{

    public float rotAngle = 2.0f;

    private float time; //経過時間カウント用



    private void Start()
    {
        time = 0.0f;    //経過時間初期化 
    }

    void Update()
    {
        //Quaternion rot = this.transform.rotation;
        //Debug.Log(rot);

        //float x = rot.eulerAngles.x;
        //Debug.Log(x);
    }
    
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);


        //Rotation();
        

        Debug.Log("つかんだ");
    }

    public void Rotation()
    {
        //経過時間のカウント
        time += Time.deltaTime;

        //3秒後に実行
        if (time >= 3.0f)
        {
            //transform.Rotate(rotAngle, 0f, 0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
    
    }

}

