using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeScript : MonoBehaviour {

	public GameObject objPrefabInstantSource;//文章中叫obje
	public GameObject musicInstant_ci = null;//文章中叫obj
	// Use this for initialization
	void Start () {
		musicInstant_ci = GameObject.FindGameObjectWithTag ("ci");
		if (musicInstant_ci == null) {
			musicInstant_ci = (GameObject)Instantiate (objPrefabInstantSource);
		}
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
		GameObject hero = GameObject.FindWithTag ("Player");
		GameObject hitObj = collision.collider.gameObject;
		musicInstant_ci.audio.volume = 100;
		musicInstant_ci.audio.Play ();

		if (hero == hitObj) 
		{
			Destroy(hitObj);
			Destroy (gameObject);
			//主角被尖刺扎死，游戏失败，跳转到失败结算页
			Application.LoadLevel ("fail");
			return;
		}
        //从produceList中删除并销毁
        foreach (BoxWithTimer bwt in PlayerScript.produceList)
        {
            if (bwt.box == hitObj)
            {
                PlayerScript.produceList.Remove(bwt);
                break;
            }
        }
        Destroy(hitObj);
    }
}
