using UnityEngine;
using System.Collections;
using System.Threading;

public class icescript : MonoBehaviour
{
		public static bool isPressBuyButton = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Animator anim = gameObject.GetComponent<Animator> ();
				if ((PlayerScript.numOfBrothers < 4) && !isPressBuyButton) {
						//冰块闪烁
						anim.SetBool ("Isless", true);
				} else if (PlayerScript.numOfBrothers > 3) {
						isPressBuyButton = false;
				}

				if (PlayerScript.isBrotherLess) {
						//冰块变大并还原
						transform.localScale = new Vector3 (2, 2, 2);
						Thread delay = new Thread (Wait);
						delay.Start ();
				} else {
						
						transform.localScale = new Vector3 (1, 1, 1);
				}
				if (isPressBuyButton) {
						//取消闪烁
						anim.SetBool ("Isless", false);
				}
		}
		
		void Wait ()
		{    
				Thread.Sleep (200);
				PlayerScript.isBrotherLess = false;
		}

}
