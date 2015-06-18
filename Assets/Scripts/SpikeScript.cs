using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class SpikeScript : MonoBehaviour
{

		public GameObject objPrefabInstantSource;//文章中叫obje
		public GameObject musicInstant_ci = null;//文章中叫obj\

		GameObject obj = null;
		// Use this for initialization
		void Start ()
		{
				musicInstant_ci = GameObject.FindGameObjectWithTag ("ci");
				if (musicInstant_ci == null) {
						musicInstant_ci = (GameObject)Instantiate (objPrefabInstantSource);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				GameObject hero = GameObject.FindWithTag ("Player");
				GameObject hitObj = collision.collider.gameObject;
				musicInstant_ci.audio.volume = 100;
				musicInstant_ci.audio.Play ();

				if (hero == hitObj) {
						PlayerScript.isBig = true;
						StartCoroutine ("wait");
						return;
				}
				//从produceList中删除并销毁
				foreach (BoxWithTimer bwt in PlayerScript.produceList) {
						if (bwt.box == hitObj) {
								PlayerScript.produceList.Remove (bwt);
								PlayerScript.numOfBrothers -= 1;
								PlayerScript.isBrotherLess = true;
								Destroy (hitObj);
								break;
						}
				}
				if (hitObj != null) {
						obj = hitObj;
						hitObj.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
						StartCoroutine ("wait1");
				}
		}

		IEnumerator wait ()
		{
				yield return new WaitForSeconds (0.2f);
				GameObject hero = GameObject.FindWithTag ("Player");
				Destroy (hero);
				Destroy (gameObject);
				//主角被尖刺扎死，游戏失败，跳转到失败结算页
				Application.LoadLevel ("fail");
		}

		IEnumerator wait1 ()
		{
				yield return new WaitForSeconds (0.3f);
				if (obj != null) {
						Destroy (obj);
				}
		}
}
