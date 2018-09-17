using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //追加課題はここに書き込む可能性あり

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosz = -7.5f;
    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    

	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.z < this.visiblePosz)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}
}
