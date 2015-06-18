using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCountdown : MonoBehaviour
{
	//限定时间秒
	private float fixedTime = 100.0f;
	private float nowTime;

	public Text time;
	public Text num;

	// Use this for initialization
	void Start()
	{
		nowTime = Time.time;
		if (nowTime - GuankaLogin.start_time >= fixedTime)
		{
			Application.LoadLevel("fail");
		}
		else
		{
			InvokeRepeating("CountDown", 0, 1);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		num.text = "" + PlayerScript.numOfBrothers;
	}

	void CountDown()
	{
		time.text = "倒计时：" + fixedTime + "s";
		fixedTime -= 1;
		if (fixedTime < 0)
		{
			Application.LoadLevel("fail");
		}
	}

	public void setPressBuyButton(bool setPress){
		icescript.isPressBuyButton = setPress;
	}
}