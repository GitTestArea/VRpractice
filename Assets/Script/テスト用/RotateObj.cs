using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotAngle = 2.0f;

    private float time; //経過時間カウント用

    private void Start()
    {
        time = 0.0f;    //経過時間初期化 
    }

    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        //経過時間のカウント
        time += Time.deltaTime;

        //3秒後に実行
        if (time >= 3.0f)
        {
            transform.Rotate(rotAngle, 0f, 0f);
        }

    }
}
