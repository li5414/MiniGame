using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStepLevel3DoorButtonScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		Level3DoorButtonScript button = otherCollider.gameObject.GetComponent<Level3DoorButtonScript> ();

        if (button != null) 
		{
			//float start = GetPosition (9);
			//float start = 4f - 9 * CameraScript.height - 0.2f;
			//float end =  4f - 9 * CameraScript.height + 2f;
			button.PressButton();
		}
	}

	void OnTriggerExit2D(Collider2D otherCollider)
	{
		Level3DoorButtonScript button = otherCollider.gameObject.GetComponent<Level3DoorButtonScript> ();
		if (button != null) 
		{
			button.UnpressButton();
		}
	}
}
