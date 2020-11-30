using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    //アクティブでないオブジェクトは参照できないのでインスペクタからオブジェクトを登録する
    public GameObject BallObj;
    Vector3 ResetPos;
    

    // Start is called before the first frame update
    void Start()
    {
        //ボールの最初の位置を保存する
        ResetPos =BallObj.transform.position;
        //Debug.Log(ResetPos);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        //もし衝突したオブジェクトの名前がBallだったら
        //床に衝突したら元の位置にボールを戻す
        //この条件をつけたらボールが復活した際にちょっと動くようになったが謎
        if(other.gameObject.name == "Ball")
        {
            Debug.Log("衝突");
            BallObj.transform.position = ResetPos;
        }
            
        
    }
}
