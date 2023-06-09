using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 20;//動く速さ

    public Text scoreText;//スコアのUI
    public Text winText;//リザルトのUI

    private Rigidbody rb;//Rididbody
    private int score;//スコア
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        //UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Rigidbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //その収集アイテムを非表示にします。
            other.gameObject.SetActive(false);

            //スコアを加算します
            score = score + 1;

            //UIの表示を更新します
            SetCountText ();
        }
    }

    //UIの表示を更新する
    void SetCountText()
    {
        //スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        //すべての収集アイテムを獲得した場合
        if (score >= 7)
        {
            //リザルトの表示を更新
            winText.text = "You Win!";
        }
    }
}
