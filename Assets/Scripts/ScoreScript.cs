using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public Text score; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string text = "您的得分：" + PassScript.time;
		score.text = text;
		score.fontStyle = FontStyle.Normal;
		score.fontSize = 38;
		//TODO 排行榜
	}
}
