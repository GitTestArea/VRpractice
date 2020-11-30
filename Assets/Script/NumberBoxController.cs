using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 数字入力のためのカスタムイベント
[Serializable]
public class NumberBoxEvent : UnityEvent<string>
{
}

public class NumberBoxController : MonoBehaviour
{
    public string Character; // 箱が表す数字、インスペクタで箱ごとに設定しておく
    public NumberBoxEvent OnEnterNumber; // 衝突時にこのイベントを発生させる
    private NumberPaneController numberPaneController; // ※箱の見た目が同じだと画面上で区別が付かないので、子オブジェクトとして数字表示板を持たせた

    // 衝突発生時に物理シミュレーションエンジンによって自動的に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // ボールには「Player」タグを付けておき、ボールとの衝突だけに応答する（箱同士や地面・壁との衝突があっても何もしない）
        {
            this.numberPaneController.Lit = true; // ※数字表示板を点灯させて衝突したことを分かりやすくした
            this.OnEnterNumber.Invoke(this.Character); // Characterを引数にして数字入力イベントを起こす
            Debug.Log(Character);
        }
    }

    // 衝突終了時に物理シミュレーションエンジンによって自動的に呼び出される
    private void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            this.numberPaneController.Lit = false; // ※ボールが箱から離れたら数字表示板を消灯する
        }
    }

    private void Start()
    {
        if (this.OnEnterNumber == null)
        {
            this.OnEnterNumber = new NumberBoxEvent();
        }
        if (this.numberPaneController == null)
        {
            this.numberPaneController = this.GetComponentInChildren<NumberPaneController>();
        }
        this.numberPaneController.CharacterIndex =
            NumberPaneController.GetIndexForCharacter(string.IsNullOrEmpty(this.Character) ? ' ' : this.Character[0]);
        this.numberPaneController.Lit = false;
    }

    private void Update()
    {
      
    }
}
