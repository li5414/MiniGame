using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTouchSwitchScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		SwitchScript switchs = otherCollider.gameObject.GetComponent<SwitchScript> ();
	
        if (switchs != 	null){
			switchs.ChangeSwitch();
		}
	}
}
