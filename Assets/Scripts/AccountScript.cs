using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//结算页代码，成功&失败
public class AccountScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//返回
	public void back(){
		Application.LoadLevel ("guanka");
	}
	//下一关
	public void next(){
		CameraScript.GameLevel = CameraScript.GameLevel + 1;
		int level = CameraScript.GameLevel + 1;
		Application.LoadLevel ("scene"+level);
		GuankaLogin.start_time = Time.time;
	}
	//重玩本关
	public void again(){
		int level = CameraScript.GameLevel + 1;
		Application.LoadLevel ("scene"+level);
		GuankaLogin.start_time = Time.time;
	}
}