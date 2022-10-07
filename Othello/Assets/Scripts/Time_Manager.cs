using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Time_Manager : MonoBehaviour {
	public Text timerText;

	public float totalTime;
	int seconds;
    static float x;

	// Use this for initialization
	void Start () {
		x = totalTime;
	}

	// Update is called once per frame
	void Update () {
		x -= Time.deltaTime;
		seconds = (int)x;
		timerText.text= seconds.ToString();


	}
    public void Reset_Time()
    {
        x = totalTime;
    }
}