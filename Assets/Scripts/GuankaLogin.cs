using UnityEngine;
using System.Collections;

public class GuankaLogin : MonoBehaviour {
	public static float start_time = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void change(int level)
	{
        CameraScript.GameLevel = level-1;
		Application.LoadLevel ("scene"+level);
		start_time = Time.time;
	}
}
