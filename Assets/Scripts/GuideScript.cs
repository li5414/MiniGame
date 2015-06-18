using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerPrefs.HasKey("GuidePlayed") || PlayerPrefs.GetString ("GuidePlayed", "no").Equals ("no")) {
			obj.SetActive(true);
			PlayerPrefs.SetString("GuidePlayed", "yes");
		} else if (PlayerPrefs.GetString ("GuidePlayed", "no").Equals ("yes")) {
			obj.SetActive(false);
		}
	}
}
