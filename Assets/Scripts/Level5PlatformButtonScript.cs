using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level5PlatformButtonScript : MonoBehaviour {
	public GameObject Platform1;
	public GameObject Platform2;
	public GameObject ButtonPressed;
    private int count = 0;

	// Use this for initialization
	void Start () {
		ButtonPressed.renderer.enabled = false;
	}

	public void PressButton()
	{
        count++;
		gameObject.renderer.enabled = false;
		ButtonPressed.renderer.enabled = true;
		PlatformMoveOut ();
	}

	public void UnpressButton()
	{
        if (--count > 0)
            return;
		gameObject.renderer.enabled = true;
		ButtonPressed.renderer.enabled = false;
		PlatformMoveIn();
	}

	void PlatformMoveOut()
	{
		Platform1.transform.position = new Vector3(1.53f, 1.4f, -3f);
		Platform2.transform.position = new Vector3(0.4f, 1.4f, -3f);
	}

	void PlatformMoveIn()
	{
		Platform1.transform.position = new Vector3(2.85f, 1.4f, -3f);
		Platform2.transform.position = new Vector3(-0.87f, 1.4f, -3f);
	}
}
