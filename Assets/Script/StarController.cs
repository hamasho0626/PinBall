using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private float rotSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
        //毎フレームごとにY軸を中心に1度回転(回転する角度は変数rotSpeedで制御)
        this.transform.Rotate(0, this.rotSpeed, 0);
	}
}
