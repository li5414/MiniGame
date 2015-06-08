using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPassScript : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		PassScript pass = otherCollider.gameObject.GetComponent<PassScript> ();
        if (pass != null) 
		{
			//PlayerGetKeyScript myKey = gameObject.GetComponent<PlayerGetKeyScript>();
			if(PlayerGetKeyScript.key)
			{
				//删去主角
				Destroy (gameObject);
				//场景暂停
				Time.timeScale = 0;
				//弹出结算界面
				//var passtransform = Instantiate(Resources.Load ("Wall") ) as Transform;
				// Assign position
				//passtransform.position = new Vector3 (0, 0, 0);
			}
		}
    }
}
