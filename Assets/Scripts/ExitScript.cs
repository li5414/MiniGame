using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Msdk;

public class ExitScript : MonoBehaviour
{
		public GameObject alertdialog;
		// Use this for initialization
		void Start ()
		{
				alertdialog.SetActive (false);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown (KeyCode.Escape))) {
						//弹窗，让玩家确认是否退出
						alertdialog.SetActive (true);
				}
		}

		public void IsQuit (bool quit)
		{
				if (quit) {
						Application.Quit ();
				} else {
						//弹窗消失
						alertdialog.SetActive (false);
				}
		}

	public void logout(){
		if (Application.platform == RuntimePlatform.Android && msdk.flag == true) {
			Debug.Log ("登出");
			WGPlatform.Instance.WGLogout ();
			msdk.flag = false;
		}
		Application.LoadLevel("login");
	}
}
