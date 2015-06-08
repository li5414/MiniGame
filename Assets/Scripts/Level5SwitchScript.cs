using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level5SwitchScript : MonoBehaviour {
	public GameObject Platform;
	public GameObject SwitchAfter;

	// Use this for initialization
	void Start () {
		SwitchAfter.renderer.enabled = false;
	}

	public void ChangeSwitch()
	{
		gameObject.renderer.enabled = false;
		SwitchAfter.renderer.enabled = true;
		PlatformMoveOut ();
	}

	void PlatformMoveOut()
	{
		Platform.transform.position = new Vector3(-2.2f, 0.18f, -5f);
	}
}
