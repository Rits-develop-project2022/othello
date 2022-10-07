using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TimeAlert : MonoBehaviour
{
    public float totalTime;
    public Text text;
	int seconds;
    static float x;
    // Start is called before the first frame update
    void Start()
    {
        x = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        x -= Time.deltaTime;
		seconds = (int)x;
		text.text= seconds.ToString();
    }
    public void Reset_Time()
    {
        x = totalTime;
    }
}
