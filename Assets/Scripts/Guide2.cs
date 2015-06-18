using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Guide2 : MonoBehaviour
{
	public int onceguide;
	public int[] once = {0,0,0,0,0,0};
	GameObject m_obj;

	// Use this for initialization
	void Start ()
	{
		
		m_obj = GameObject.FindWithTag("guide2");
		
		string path = Application.persistentDataPath;
		//Debug .Log (Application .persistentDataPath);
		
		string fileName = "Guide2.txt";
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
				once[pos] = Convert.ToInt32(str);
				pos++;
			}

			if(once[0] == 1)
				m_obj.SetActive (false);
		}
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void change()
	{
		m_obj.SetActive (false);
		onceguide = 1;
		
		StreamWriter sw;
		string path = Application.persistentDataPath;
		//Debug .Log (Application .persistentDataPath);
		
		string fileName = "Guide2.txt";
		FileInfo t = new FileInfo (path + "//" + fileName);
		if (t.Exists) {
			File.Delete (path + "//" + fileName);
		}
		sw = t.CreateText ();
		
		sw.WriteLine (onceguide.ToString ());
		
		sw.Close ();
		sw.Dispose ();
	}
}