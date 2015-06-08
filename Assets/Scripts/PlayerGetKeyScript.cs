using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGetKeyScript : MonoBehaviour {

	//控制声音，sylvia
	public GameObject objPrefabInstantSource;//文章中叫obje
	public GameObject musicInstant_eatkey = null;//文章中叫obj

	public static bool key = false;


	void Start () {
		key = false;
		musicInstant_eatkey = GameObject.FindGameObjectWithTag ("eatkey");
		if (musicInstant_eatkey == null) {
			musicInstant_eatkey = (GameObject)Instantiate (objPrefabInstantSource);
		}
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		KeyScript star = otherCollider.gameObject.GetComponent<KeyScript> ();
        if (star != null)
		{
			Destroy (star.gameObject);
			key = true;
		}
		//控制声音
		musicInstant_eatkey.audio.Play ();

    }
}
