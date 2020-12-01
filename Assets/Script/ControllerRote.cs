using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRote : MonoBehaviour
{
    public Transform target;
    //Update内で処理をするためのbool
    private bool isGrabble;
    private float offsetAngle;
    //回転したときの条件を一度だけ実行するフラグ
    private int Stage;
    //箱が開くアニメーション用
    private Animator anim;

    private void Start()
    {
        offsetAngle = transform.rotation.eulerAngles.x;
        //回転した時に一回だけ処理するためのもの
        Stage = 0;
      
       
   }

    // Update is called once per frame
    void Update()
    {
        if(isGrabble == true && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            //RightHandAnchorというゲームオブジェクトを見つける
            GameObject gameObj = GameObject.Find("RightHandAnchor");

            //ゲームオブジェクトの名前を取得する
            //Debug.Log(other.gameObject.name);

            //RightHandAnchorのZ軸のRotationを取得する
            float ro = (int)gameObj.transform.localEulerAngles.z;
            transform.localRotation = Quaternion.Euler(x: -ro -offsetAngle, y: 0, z: 0);
            //Debug.Log(ro + "です");

            if((360 - ro) > 90.0f && Stage == 0)
            {
                Stage = 1;
                Debug.Log("回転");
                GameObject open = GameObject.Find("lid");
                //Debug.Log(open);
                anim = open.GetComponent<Animator>();
                anim.SetBool("LidOpne", true);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //当たったゲームオブジェクトのタグがPlayerかつ右コントローラーの中指のトリガーを押しているとき
        if (other.gameObject.tag == "Player" && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            isGrabble = true;    
            //マテリアルの色を変更する
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrabble = false;
        offsetAngle = transform.rotation.eulerAngles.x;
    }

}
