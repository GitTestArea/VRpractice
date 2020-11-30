using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWord : MonoBehaviour
{
    private const float BlinkingInterval = 0.5f; // ※Accepted、Deniedの時の数字表示点滅間隔
    public NumberPaneController[] NumberPaneControllers; // ※ゲート前面にある4枚の数字表示板、インスペクタ上で割り当てておく
    public string PasswordString; // パスワード文字列、インスペクタ上で決めておく
    private string playersAnswer; // 入力されたパスワード候補文字列
    private float time; // ※数字表示板点滅のための時間格納用変数
    public GameObject Target;   //パスワードが正解したら的とボールを出現させる
   

    // 箱とボールの衝突発生時に箱で発生するOnEnterNumberに対応して、これを実行するようインスペクタで設定しておく
    public void EnterDigit(string character)
    {
        this.playersAnswer += character; // characterには入力された文字が渡されるので、これをplayersAnswerに連結する
        Debug.Log("Password : " + this.playersAnswer);
        this.UpdateDisplay(); // ※playersAnswerを書き換えたので、ゲート前面の数字表示板を更新する
        if (this.playersAnswer.Length >= this.PasswordString.Length)
        {
            if (this.playersAnswer == this.PasswordString)
            {
                Debug.Log("Accepted!");
                Target.SetActive(true);

            }
            else
            {
                Debug.Log("Denied!");
            }
            this.playersAnswer = "";
        }
    }

    // ※ゲート前面数字板表示を一斉に変えるためのメソッド...アニメーター上のステートにStateMachineBehaviourが仕掛けてあり、そこで使用している
    public void ResetDisplay(string character)
    {
        this.time = 0.0f;
        if (character == null)
        {
            this.UpdateDisplay();
        }
        else
        {
            var paneCount = this.NumberPaneControllers.Length;
            var characterIndex = NumberPaneController.GetIndexForCharacter(character[0]);
            for (var i = 0; i < paneCount; i++)
            {
                var pane = this.NumberPaneControllers[i];
                if (pane == null)
                {
                    continue;
                }

                pane.CharacterIndex = characterIndex;
            }
        }
    }

    // ※ゲート前面数字板の点灯状態を変えるためのメソッド...Accepted・Denied時の点滅エフェクト用
    private void InvertLit()
    {
        var paneCount = this.NumberPaneControllers.Length;
        for (var i = 0; i < paneCount; i++)
        {
            var pane = this.NumberPaneControllers[i];
            if (pane == null)
            {
                continue;
            }

            pane.Lit = !pane.Lit;
        }
    }

    private void Start()
    {
        this.playersAnswer = "";
        this.UpdateDisplay();
        
    }

    private void Update()
    {
     
    }

    // ※現在のplayersAnswerに合わせて数字板の表示を切り替えるメソッド
    private void UpdateDisplay()
    {
        var paneCount = this.NumberPaneControllers.Length;
        var answerLength = string.IsNullOrEmpty(this.playersAnswer) ? 0 : this.playersAnswer.Length;
        for (var i = 0; i < paneCount; i++)
        {
            var pane = this.NumberPaneControllers[i];
            if (pane == null)
            {
                continue;
            }

            pane.CharacterIndex =
                NumberPaneController.GetIndexForCharacter(i < answerLength ? this.playersAnswer[i] : '?');
            pane.Lit = false;
        }
    }
}
