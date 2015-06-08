using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {
	
   public void Change()
	{
		Application.LoadLevel ("login");
	}
}
