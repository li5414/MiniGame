using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Locked_Script : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
				//Debug .Log (CameraScript .locked [CameraScript.GameLevel + 1]);

				GameObject la = GameObject.FindWithTag ("1");
				GameObject lb = GameObject.FindWithTag ("2");
				GameObject lc = GameObject.FindWithTag ("3");
				GameObject ld = GameObject.FindWithTag ("4");
				GameObject le = GameObject.FindWithTag ("5");

				string path = Application.persistentDataPath;
				//Debug .Log (Application .persistentDataPath);

				string fileName = "Lock.txt";
				FileInfo t = new FileInfo(path + "//" + fileName);
				if(t.Exists)
				{
					StreamReader sr = null;
					sr = File.OpenText(path+"//"+fileName);
					string line;
					ArrayList arrlist = new ArrayList();
					while((line = sr.ReadLine()) != null)
					{
						arrlist.Add(line);
					}
					sr.Close();
					sr.Dispose();
			
					int pos = 0;
					foreach(string str in arrlist)
					{
						CameraScript.locked[pos] = Convert.ToInt32(str);
						pos++;
					}
				}

				int i = 0;
				for (i=5; i>0; i--) {
						if (CameraScript.locked [i] == 1) {
								break;
						}
				}
				switch (i) {
				case 1:
						la.SetActive (false);
						break;
				case 2:
						la.SetActive (false);
						lb.SetActive (false);
						break;
				case 3:
						la.SetActive (false);
						lb.SetActive (false);
						lc.SetActive (false);
						break;
				case 4:
						la.SetActive (false);
						lb.SetActive (false);
						lc.SetActive (false);
						ld.SetActive (false);
						break;
				case 5:
						la.SetActive (false);
						lb.SetActive (false);
						lc.SetActive (false);
						ld.SetActive (false);
						le.SetActive (false);
						break;
				default :
						break;
				}
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
}
