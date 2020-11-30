using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    // 変数
    int frameCount;
    float prevTime;
    float fps;
    private Text FPSText;

    // 初期化処理
    void Start()
    {
        // 変数の初期化
        frameCount = 0;
        prevTime = 0.0f;
        //親子関係にある子オブジェクトからTextコンポーネントを取得する
        FPSText = GetComponentInChildren<Text>();
    }

    // 更新処理
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            //Debug.Log(fps);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }

        //Textで表示させる
        FPSText.text = fps.ToString();
    }
}
