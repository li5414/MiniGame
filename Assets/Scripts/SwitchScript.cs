using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchScript : MonoBehaviour {
	public GameObject otherObject;
	public GameObject switchAfter;

	// Use this for initialization
	void Start () {
		switchAfter.renderer.enabled = false;
	}
	
	public void ChangeSwitch()
	{
		gameObject.renderer.enabled = false;
		switchAfter.renderer.enabled = true;
		DoSomethingToOtherObject ();
	}
	
	void DoSomethingToOtherObject()
	{
	}
}
