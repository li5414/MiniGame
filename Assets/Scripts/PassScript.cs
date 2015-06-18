using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class PassScript : MonoBehaviour {
	public static string time = "";
	
	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D( Collider2D other ){
		float endtime = Time.time;
		float gametime = endtime - GuankaLogin.start_time;
		float value = 5000 - 20*gametime;

		//超时或者没有钥匙，跳转至失败结算页
		if ((value < 0.0f) || (PlayerGetKeyScript.key == false)) {
			Application.LoadLevel("fail");	
		}else//过关，跳转到成功结算页
		{
			int scoreint = (int)value;
			string scorevalue = scoreint + "";
			time = scorevalue;
			//TODO 将分数上传至服务器
			Application.LoadLevel ("success");
			PlayerGetKeyScript.key = false;
			//过关之后解锁下一关
			CameraScript.locked[CameraScript.GameLevel+1] = 1;
			StreamWriter sw;
			string path = Application.persistentDataPath;
			string fileName = "Lock.txt";
			FileInfo t = new FileInfo(path+"//"+fileName);
			if(t.Exists)
			{
				File.Delete (path+"//"+fileName);
			}
			sw = t.CreateText();
			for(int i = 0; i < 6; i++)
			{
				sw.WriteLine(CameraScript.locked[i].ToString());
			}
			sw.Close ();
			sw.Dispose ();
		}
	}
}
