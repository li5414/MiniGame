using UnityEngine;
using System.Collections;

public class AngryBoxScript : MonoBehaviour
{
		private float speed, walkSpeed, rushSpeed;
		private float leftLimit, rightLimit;
		private int direction;
		private Vector2 movement;
		private float heightDiff = CameraScript.height - 0.1f;

		//控制声音，sylvia
		public GameObject musicInstant_seemonster = null;//文章中叫obj

		//private GameObject hero;

		// Use this for initialization
		void Start ()
		{
				direction = -1;
				speed = walkSpeed = 1f;
				rushSpeed = 4f;

				transform.localScale = new Vector3 (-1, 1, 1);
				movement = new Vector2 (walkSpeed * direction, 0);
				musicInstant_seemonster = GameObject.FindGameObjectWithTag ("seemonster");
		}
	
		// Update is called once per frame
		void Update ()
		{
				//冲向英雄盒子后，方向及速度不再改变
				if (speed > walkSpeed)
						return;
				//看到英雄盒子
				if (IsLookAtObjects ()) {
						speed = rushSpeed;
						//direction = hero.transform.position.x < this.transform.position.x ? -1 : 1;
				} else {
						if (transform.position.x < leftLimit) {
								direction = 1;
								transform.localScale = new Vector3 (1, 1, 1);
						} else if (transform.position.x > rightLimit) {
								direction = -1;
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

		void OnCollisionEnter2D (Collision2D collision)
		{
		}

		float GetPosition (int col)
		{
				return col * CameraScript.width - 6f;
		}

		bool IsLookAtObjects ()
		{
				GameObject hero = GameObject.FindWithTag ("Player");

				if (hero != null && hero.active && CanAttackObj (hero) == true) {
						//控制声音
						musicInstant_seemonster.audio.Play ();
						return true;
				}

				if (PlayerScript.produceList.Count > 0) {
						foreach (BoxWithTimer obj in PlayerScript.produceList) {
								if (CanAttackObj (obj.box) == true) {
										//控制声音
										musicInstant_seemonster.audio.Play ();
										return true;
								}
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

		public void SetLeftLimit (int left)
		{
				leftLimit = GetPosition (left);
		}

		public void SetRightLimit (int right)
		{
				rightLimit = GetPosition (right);
		}
}