using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxWithTimer
{
		public GameObject box;
		public float aliveTime;

		public BoxWithTimer (GameObject obj)
		{
				box = obj;
				aliveTime = PlayerScript.ALIVE_TIME;
		}
}

public class PlayerScript : MonoBehaviour
{

		//控制音乐,sylvialu
		public GameObject objPrefabInstantSource;
		public static GameObject musicInstant_iceadd = null;
		public static GameObject musicInstant_icedelete = null;
		public static GameObject musicInstant_walk = null;
		public float force_move = 5;
		public Vector2 speed = new Vector2 (6f, 6f);
		//private Animator anim;
		private Rigidbody2D rig2D;
		public bool left = false;
		public bool right = false;
		public bool up = false;
		public bool down = false;
		public bool key = false;
		public const int MAX_BROTHERS_NUM = 7;
		public static LinkedList<BoxWithTimer> produceList = new LinkedList<BoxWithTimer> ();//为方便删除任意一个对象，改用双向链表
		private static Queue collectQueue = new Queue ();
		private int numOfBrothers;                        //当前拥有的盒子数量
		public static float ALIVE_TIME = 5f;              //盒子的最长存活时间

		private static Vector3 posBeyondScreen = new Vector3 (-100f, -100f, -100f);
		private float lastPosY; //上一帧的Y坐标
		private float lastVelocity;
		private static Animator anim;

		//音乐控制代码，sylvia
		void Start ()
		{
				musicInstant_iceadd = GameObject.FindGameObjectWithTag ("iceadd");
				musicInstant_icedelete = GameObject.FindGameObjectWithTag ("icedelete");
				musicInstant_walk = GameObject.FindGameObjectWithTag ("walk");
				if (musicInstant_iceadd == null) {
						musicInstant_iceadd = (GameObject)Instantiate (objPrefabInstantSource);
				}
				if (musicInstant_icedelete == null) {
						musicInstant_icedelete = (GameObject)Instantiate (objPrefabInstantSource);
				}
				anim = this.GetComponent<Animator> ();
		}
	
		void Awake ()
		{
				rig2D = gameObject.GetComponent<Rigidbody2D> ();

				numOfBrothers = 6;

				for (int i = 0; i < numOfBrothers; i++) {
						GameObject box = Instantiate (Resources.Load ("PlayerShot")) as GameObject;
						box.SetActive (false);

						collectQueue.Enqueue (new BoxWithTimer (box));
				}
				Time.timeScale = 1;
		}

		void OnDestroy ()
		{
				foreach (BoxWithTimer bwt in produceList) {
						Destroy (bwt.box);
				}
				produceList.Clear ();

				while (collectQueue.Count > 0) {
						BoxWithTimer bwt = (BoxWithTimer)collectQueue.Dequeue ();
						Destroy (bwt.box);
				}
        
		}
    
		public void SetLeft (bool value)
		{
				musicInstant_walk.audio.Play ();
				left = value;
				right = false;
				up = false;
				down = false;
		}
	
		public void SetRight (bool value)
		{
				musicInstant_walk.audio.Play ();
				right = value;
				left = false;
				up = false;
				down = false;
		}

		public void SetUp (bool value)
		{
				up = value;
				down = false;
				left = false;
				right = false;
		}

		public void SetDown (bool value)
		{
				down = value;
				up = false;
				left = false;
				right = false;
		}

		// Update is called once per frame
		void Update ()
		{
        
				foreach (BoxWithTimer bwt in produceList) {
						bwt.aliveTime -= Time.deltaTime;
				}
				while (produceList.Count > 0) {
						BoxWithTimer bwt = produceList.First.Value;
						if (bwt.aliveTime > 0)
								break;
						DestroyOneBox ();      //时间到，消去
				}
        
        
		}

		void FixedUpdate ()
		{   
				float inputX = 0;
				float deltaY = this.transform.position.y - lastPosY;
				if (deltaY > -0.005f && deltaY < 0.005f) {//正常波动
						if (left)
								inputX -= 1.5f;
						if (right)
								inputX += 1.5f;

						if (inputX > 0.05f) {
								//朝向右方向
								transform.localScale = new Vector3 (1, 1, 1);
								transform.position += new Vector3 (0.01f, 0, 0);
						} else if (inputX < -0.05f) {
								transform.localScale = new Vector3 (-1, 1, 1);
								transform.position += new Vector3 (-0.01f, 0, 0);
						}
						rig2D.velocity = new Vector2 (inputX * force_move, rig2D.velocity.y);
				} else
						rig2D.velocity = new Vector2 (lastVelocity, rig2D.velocity.y);

				lastPosY = this.transform.position.y;
        
				lastVelocity = rig2D.velocity.x;

                if (up && CameraScript.IsUpBlank(GameObject.Find("Player")))
                {
						ProduceOneBox ();
						up = false;
				}

				if (down) {
						DestroyOneBox ();
						down = false;
				}
		
		
		}

		void SetPosition (GameObject obj)
		{
				Vector3 pos = transform.position;
				Vector3 newPos = pos + new Vector3 (0, 0.4f, 0);
		
				this.transform.position = newPos;
				obj.transform.position = pos;
		}
 
		//生产一个盒子
		void ProduceOneBox ()
		{
				if (collectQueue.Count > 0) {
						BoxWithTimer bwt = collectQueue.Dequeue () as BoxWithTimer;
						bwt.box.SetActive (false);
						SetPosition (bwt.box);//设盒子坐标
						bwt.box.SetActive (true);

						produceList.AddLast (bwt);//放入链表尾部
						bwt.aliveTime = ALIVE_TIME;//重置存活时间
				} else if (produceList.Count > 0) { //回收队列为空
						DestroyOneBox ();//则先消去一个盒子，再生产出来
				}
				//控制声音
				musicInstant_iceadd.audio.Play ();

		}
 
		//消去一个盒子
		public static void DestroyOneBox ()
		{
				if (produceList.Count > 0) {
						BoxWithTimer bwt = produceList.First.Value;
						MoveToBeyondScreen (bwt.box);//移出屏幕
            
						//bwt.box.SetActive(false);
						bwt.box.transform.localRotation = Quaternion.Euler (0, 0, 0);

						produceList.RemoveFirst ();//移除链表第一个节点
						collectQueue.Enqueue (bwt);//放入回收队列
				}
				//控制声音
				musicInstant_icedelete.audio.Play ();

		}

		static void MoveToBeyondScreen (GameObject obj)
		{
				obj.transform.position = posBeyondScreen;
		}

		public static void playBombAnimation (bool isBomb)
		{
				if (isBomb && (anim != null)) {
						anim.SetBool ("IsBomb", isBomb);
				} 
		}
}