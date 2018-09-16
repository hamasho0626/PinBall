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

	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		//左矢印キーを押したとき左のフリッパーを動かす
        //コンポーネントさせるのだから対照のタグが条件に該当するのかを調べている
        //SetAngleもコンポーネントして対象を限定させているのだからいちいち調べずとも
        //書き換えるだけですむ
        
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

    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
