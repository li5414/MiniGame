﻿using UnityEngine;
using System.Collections;

public class replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void change()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
