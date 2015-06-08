using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour
{
	public int whatmusic;
	public GameObject objPrefabInstantSource;
	public GameObject musicInstant_prepare;
	public GameObject musicInstant_playing1;
	public GameObject musicInstant_playing2;
	public static int play0 = 1;
	
	void Start ()
	{
		musicInstant_prepare = GameObject.FindGameObjectWithTag ("prepare");
		musicInstant_playing1 = GameObject.FindGameObjectWithTag ("playing1");
		musicInstant_playing2 = GameObject.FindGameObjectWithTag ("playing2");
		if (musicInstant_prepare == null) {
			musicInstant_prepare = (GameObject)Instantiate (objPrefabInstantSource);
		}
		music ();
	}
	
	void music ()
	{
		if (whatmusic == 0 && play0 == 1) {
			musicInstant_prepare .audio .Play ();
			musicInstant_playing1 .audio.Pause ();
			musicInstant_playing2 .audio.Pause ();
			play0 = 0;
		} else if (whatmusic == 1) {
			musicInstant_playing1 .audio .Play ();
			musicInstant_prepare .audio.Pause ();
			musicInstant_playing2 .audio.Pause ();
			play0 = 1;
		} else if (whatmusic == 2) {
			musicInstant_playing2 .audio .Play ();
			musicInstant_prepare .audio.Pause ();
			musicInstant_playing1 .audio.Pause ();
			play0 = 1;
		}
	}
	
	public void pause ()
	{
		musicInstant_prepare.audio.Pause ();
		musicInstant_playing1 .audio.Pause ();
		musicInstant_playing2 .audio.Pause ();
	}
	
	public void play ()
	{
		if (whatmusic == 0) {
			musicInstant_prepare .audio .Play ();
		} else if (whatmusic == 1) {
			musicInstant_playing1 .audio .Play ();
		} else if (whatmusic == 2) {
			musicInstant_playing2 .audio .Play ();
		}
	}
}