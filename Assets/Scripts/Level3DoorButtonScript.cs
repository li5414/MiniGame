using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level3DoorButtonScript : MonoBehaviour {
	public GameObject buttonPressed;
	public GameObject door;
    private int count = 0;

	// Use this for initialization
	void Start () {
		buttonPressed.renderer.enabled = false;
	}

	public void PressButton()
	{
        count++;
		gameObject.renderer.enabled = false;
		buttonPressed.renderer.enabled = true;
		OpenDoor ();
	}

	public void UnpressButton()
	{
        if (--count > 0)
            return;
		gameObject.renderer.enabled = true;
		buttonPressed.renderer.enabled = false;
		CloseDoor ();
	}

	void OpenDoor()
	{
		door.transform.position = new Vector3(-2.8f, 1.76f, -5f);
	}

	void CloseDoor()
	{
		door.transform.position = new Vector3(-2.8f, 0.6f, -5f);
	}
}
