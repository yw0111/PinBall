using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点の関数を宣言するテキスト
    private int score;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //得点記録を始める
        score = 0;

    }

    // 当たった場合の得点
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("CollisionEnter");
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score = score + 5;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score = score + 10;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score = score + 7;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.score = score + 15;
        }
    }
    //得点を表示する
    public Text scoreText;
    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        // 追加：得点を表示する関数を呼び出す
        SetScoreText();

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}