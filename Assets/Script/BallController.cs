using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //追加課題はここに書き込む

    //総得点の算出用
    int TotalScore;

    //得点を表示するテキスト
    private GameObject ScoreText;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosz = -7.5f;
    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    

	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");

        TotalScore = 0;
        ScoreUpDate(0);

    }
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.z < this.visiblePosz)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            
        }
	}


    //ボールがオブジェクトに衝突したときにスコアを更新するメソッド
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "LargeStarTag")
        {

            //ここに得点追加の処理を施す

            ScoreUpDate(5);
        }

        if(other.gameObject.tag == "SmallStarTag")
        {
            //ここに得点追加処理を施す

            ScoreUpDate(1);
        }

        if(other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            ScoreUpDate(10);
        }
    }

    void ScoreUpDate( int GetPoint )
    {
        //総得点に獲得点数を足す
        TotalScore += GetPoint;

        //ScoreTextに現在の得点を表示
        string t = TotalScore.ToString();
        this.ScoreText.GetComponent<Text>().text = t;
    }

}
