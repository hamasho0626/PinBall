using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //最初の傾き
    private float defaultAngle = 20;

    //はじいたときの傾き
    private float flickAngle = -20;

    //画面の横幅を取得し、半分にする
    int WideDispSize = Screen.width / 2;

	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

        //以下、スマートフォン用の操作スクリプトです

        //タッチされたものがあるか（０ではないか）を判別する
        if (Input.touchCount > 0)
        {
            //複数のタッチがある場合はそれらを順に出力する
            foreach (Touch touch in Input.touches)
            {
                //タッチの種類を判別する
                if (touch.phase == TouchPhase.Began)
                {
                    //タッチされた場所に応じて左右どちらのフリッパーを動かすか決める
                    if (touch.position.x <= WideDispSize && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        
                    }

                    if (touch.position.x >= WideDispSize && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                }
                //タッチの種類を判別する
                else if (touch.phase == TouchPhase.Ended)
                {
                    //タップされていた場所に応じて左右どちらのフリッパーを元の位置に戻すかを決める
                    if (touch.position.x <= WideDispSize && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (touch.position.x >= WideDispSize && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
        

        //以下、PC操作用のスクリプトです

        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押したとき右のフリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //左矢印キーを押したとき左フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //右矢印キーを押したとき右フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
	}

    //フリッパーに引数によって決められた動きをさせる関数
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
