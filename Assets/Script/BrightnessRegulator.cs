﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発行速度
    private int speed = 10;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		if(tag == "smallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if(tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        } else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.degree >= 0)
        {
            Color emissionColor = this.defaultColor *
                                    (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad)
                                     * this.magEmission);

            //エミッションに色を限定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
    }
}
