using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(Renderer))]
public class NumberPaneController : MonoBehaviour
{
    private const int CellsPerRow = 8;
    private const int LitStateOffset = 2;
    private const int Row = 4;
    private static readonly Vector2 CellSize = new Vector2(1.0f / CellsPerRow, 1.0f / Row);

    private static readonly char[] Characters =
    {
        ' ',
        '?',
        'v',
        'x',
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9'
    };

    // 表示するべき文字を表すインデックス
    // 当初の予定では、表示をアニメーションクリップ上で操作しようとしたため、intではなくfloatになっています
    // アニメーションクリップからの操作はできたのですが、別の不具合が発生してこの方式は中止しました
    public float CharacterIndex;

    // 点灯状態を表すブール値
    public bool Lit;

    private float currentCharacterIndex;
    private bool currentLit;
    private bool inited;
    private Material material;

    // 文字からインデックスを求めるために用意したメソッド
    public static int GetIndexForCharacter(char character)
    {
        return Math.Max(Array.IndexOf(Characters, character), 0);
    }

    // マテリアルのmainTextureOffsetをCharacterIndexに応じた位置にずらして見た目を変えるメソッド
    public void UpdateMaterial()
    {
        if (this.inited)
        {
            var index = Math.Min(Math.Max(Mathf.RoundToInt(this.CharacterIndex), 0), Characters.Length - 1);
            var u = index % CellsPerRow;
            var v = (Row - 1 - (index / CellsPerRow)) + (this.Lit ? LitStateOffset : 0);
            this.material.mainTextureOffset = new Vector2(u * CellSize.x, v * CellSize.y);
            this.currentCharacterIndex = this.CharacterIndex;
            this.currentLit = this.Lit;
        }
    }

    // Start内でUV座標を1文字分の大きさに小さくした四角形メッシュを作り、元々のQuadメッシュと差し替える
    private void Start()
    {
        this.material = this.GetComponent<Renderer>().material;
        var meshFilter = this.GetComponent<MeshFilter>();
        var mesh = new Mesh();
        meshFilter.mesh = mesh;
        var vertices = new[]
        {
            new Vector3(-0.5f, -0.5f, 0.0f),
            new Vector3(0.5f, -0.5f, 0.0f),
            new Vector3(-0.5f, 0.5f, 0.0f),
            new Vector3(0.5f, 0.5f, 0.0f)
        };
        var triangles = new[] { 0, 2, 1, 3, 1, 2 };
        var normals = new[]
        {
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f)
        };
        var uv = new[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(CellSize.x, 0.0f),
            new Vector2(0.0f, CellSize.y),
            CellSize
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;
        this.inited = true;
        this.UpdateMaterial();
    }

    // Update内でCharacterIndexやLitに変化があったかチェックし、変化があればUpdateMaterialで表示を更新する
    private void Update()
    {
        if ((this.currentCharacterIndex != this.CharacterIndex) || (this.currentLit != this.Lit))
        {
            this.UpdateMaterial();
        }
    }
}