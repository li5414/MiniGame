using UnityEngine;
using System.Collections;
using System.Threading;

public class BombBoxScript: MonoBehaviour
{
		//public Sprite[] sprites;
		//private SpriteRenderer sprite;
		private float speed, walkSpeed, rushSpeed;
		private float leftLimit, rightLimit;
		private int direction;
		private Vector2 movement;
		private float heightDiff = CameraScript.height - 0.1f;

		//控制声音，sylvia
		public GameObject musicInstant_seemonster = null;//文章中叫obj
		public GameObject musicInstant_monster1 = null;//文章中叫obj
		//private GameObject hero;
		private bool isBig = false;
		private bool isDestroy = false;
		private bool isCollision = false;
		private GameObject obj;
		// Use this for initialization
		void Start ()
		{
				direction = -1;
				speed = walkSpeed = 1f;
				rushSpeed = 4f;

				//sprite = this.GetComponent<SpriteRenderer> ();
				//sprite.sprite = sprites [0];
				transform.localScale = new Vector3 (-1, 1, 1);
				movement = new Vector2 (walkSpeed * direction, 0);
				musicInstant_seemonster = GameObject.FindGameObjectWithTag ("seemonster");
				musicInstant_monster1 = GameObject.FindGameObjectWithTag ("monster1");
		}
	
		// Update is called once per frame
		void Update ()
		{

				/*if (isBig) {
						gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
						Thread delay = new Thread (Wait2);
						delay.Start ();
						isBig = false;
				}*/
				if (isDestroy) {
						Destroy (obj);
						Destroy (gameObject);
						isDestroy = false;
						isCollision = false;
				}
				//冲向英雄盒子后，方向及速度不再改变
				if (speed > walkSpeed)
						return;
				//看到英雄盒子
				if (IsLookAtObjects ()) {
						//控制声音
						musicInstant_seemonster.audio.Play ();
						speed = rushSpeed;
						//direction = hero.transform.position.x < this.transform.position.x ? -1 : 1;
				} else {
						if (transform.position.x < leftLimit) {
								direction = 1;
								//sprite.sprite = sprites[1];
								transform.localScale = new Vector3 (1, 1, 1);
						} else if (transform.position.x > rightLimit) {
								direction = -1;
								//sprite.sprite = sprites[0];
								transform.localScale = new Vector3 (-1, 1, 1);
						}
				}
		}

		void FixedUpdate ()
		{
				Vector3 pos = new Vector3 ();
				pos.x = transform.position.x + direction * speed * Time.deltaTime;
				pos.y = transform.position.y;
				pos.z = 0;
				transform.position = pos;
		}

		void OnDestroy ()
		{
				if (obj != null) {
						Destroy (obj);		
				}
		}
	
		float GetPosition (int col)
		{
				return col * CameraScript.width - 6f;
		}

		bool IsLookAtObjects ()
		{
				GameObject hero = GameObject.FindWithTag ("Player");

				if (hero != null && hero.active && CanAttackObj (hero) == true) {
						return true;
				}
		
				foreach (BoxWithTimer obj in PlayerScript.produceList) {
						if (CanAttackObj (obj.box) == true) {
								return true;
						}
				}
				return false;
		}

		bool CanAttackObj (GameObject obj)
		{
		
				if ((this.transform.position.x - obj.transform.position.x) * direction > 0)
						return false;
				return Mathf.Abs (this.transform.position.y - obj.transform.position.y) < heightDiff;
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				GameObject hero = GameObject.FindWithTag ("Player");
				GameObject hitObj = collision.collider.gameObject;

				if ((hero == hitObj) && !isCollision) {
						//控制声音
						musicInstant_monster1.audio.Play ();
						PlayerScript.playBombAnimation (true);
						Thread delay = new Thread (Wait);
						delay.Start ();
						//Destroy(hitObj);
						Destroy (gameObject);
						return;
				}

				foreach (BoxWithTimer bwt in PlayerScript.produceList) {
						if ((bwt.box == hitObj) && !isCollision) {
								//控制声音
								musicInstant_monster1.audio.Play ();
								PlayerScript.produceList.Remove (bwt);
								PlayerScript.numOfBrothers -= 1;
								PlayerScript.isBrotherLess = true;
								hitObj.GetComponent<Animator> ().SetBool ("IsIceBomb", true);
								isCollision = true;
								obj = hitObj;
								//Destroy (hitObj);
								gameObject.GetComponent<Animator> ().SetBool ("IsBoxBomb", true);
								Thread delay = new Thread (Wait1);
								delay.Start ();
								return;
						}
				}
		}

		void Wait ()
		{    
				Thread.Sleep (1500);
				CameraScript.isBomb = true;
		}
	
		void Wait1 ()
		{
				Thread.Sleep (500);
				//isBig = true;
				isDestroy = true;
		}
	
		/*void Wait2 ()
		{
				Thread.Sleep (100);
				isDestroy = true;
		}*/
		public void SetLeftLimit (int left)
		{
				leftLimit = GetPosition (left);
		}
	
		public void SetRightLimit (int right)
		{
				rightLimit = GetPosition (right);
		}

}