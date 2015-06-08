using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStepLevel5PlatfomButtonScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		Level5PlatformButtonScript button = otherCollider.gameObject.GetComponent<Level5PlatformButtonScript> ();

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
		Level5PlatformButtonScript button = otherCollider.gameObject.GetComponent<Level5PlatformButtonScript> ();
		if (button != null) 
		{
			button.UnpressButton();
		}
	}
}
