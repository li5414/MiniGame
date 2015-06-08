using UnityEngine;
using System.Collections;

public class PauseScript: MonoBehaviour {
	public bool flag = false;
	public static float pause_time = 0.0f;

	public void IfClick()
	{
		if (!flag) 
		{	
			Time.timeScale = 0;
			flag = true;
			pause_time = Time.time;
		}
		else
		{
			Time.timeScale = 1;
			flag = false;
			GuankaLogin.start_time = Time.time - (pause_time - GuankaLogin.start_time);
		}
	}
}
