using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTouchLevel5SwitchScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		Level5SwitchScript switchs = otherCollider.gameObject.GetComponent<Level5SwitchScript> ();
	
        if (switchs != null) 
		{
			//float start = GetPosition (9);
			//float start = 4f - 9 * CameraScript.height - 0.2f;
			//float end =  4f - 9 * CameraScript.height + 2f;
			switchs.ChangeSwitch();
		}
	}
}
