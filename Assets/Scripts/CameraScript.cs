using UnityEngine;
using System.Collections;
using System;

public class CameraScript : MonoBehaviour {
	private const int WIDTH = 35;
	private const int HEIGHT = 20;

	private int angryCount = 0;
	private int bombCount = 0;

	public static float width = 0.4f;
	public static float height = 0.4f;
    public static int GameLevel = 5; //当前关数,从0开始算
	public static int[] locked = {1,0,0,0,0,0};//关卡解锁情况

    public const int TOTAL_LEVELS = 6;
    public static GameObject Player = null;

	public static bool isBomb = false;

	public static GameObject musicInstant_fall = null;//music

	//需配置
	private int[] angryNumber = new int[TOTAL_LEVELS]{0, 1, 2, 3, 4, 0}; //从首关开始，共包含多少敌人
	private int[] bombNumber = new int[TOTAL_LEVELS]{0, 0, 0, 3, 6, 0}; //同上

	//需配置
	private const int ANGRYNUM = 4; //总愤怒盒子个数
	private const int BOMBNUM = 6; //总炸弹敌人个数
	
	//需配置
	private int[,] angryArray = new int[ANGRYNUM, 2]{
		{18, 27},
		{17, 27},
		{7, 14},
		{11, 18}
	};

	//需配置
	private int[,] bombArray = new int[BOMBNUM, 2]{
		{15, 22},
		{24, 30},
		{24, 30},
		{9, 15},
		{24, 29},
		{0, 5}
	};

	//需配置
	//0表示背景，1标识墙体，2表示主角，3表示盒子兄弟，4表示传送门，5表示愤怒敌人,6表示右尖刺,7表示左尖刺，8表示炸弹敌人,9表示钥匙
	private static int[,,] map = new int[5, HEIGHT, WIDTH]{
		{//第1关
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,2,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}
		},
		{//第2关
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,9,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,1,1,1,1},
			{1,1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,7,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}
		},
		{//第3关
			{1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,1,1,1},
			{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,6,1,1,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,0,9,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}
		},
		{//第4关
			{1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,1},
			{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,8,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,2,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,9,0,1},
			{0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
			{0,0,7,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
			{0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1}
		},
		{//第5关
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,9,0,1},
			{1,7,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
			{1,7,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1},
			{1,7,0,0,0,0,2,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1}
		}
	};

	private GameObject[,] gameObjects;

	// Use this for initialization
	void Awake () {
        

		//width = height = 0.35f;
		gameObjects = new GameObject[HEIGHT, WIDTH];

		for(int row = 0;row < HEIGHT; row++)
		{
			for(int col = 0; col < WIDTH; col++)
			{
				switch (map[GameLevel, row, col])
				{
				case 1:
					gameObjects[row, col] = Instantiate(Resources.Load ("Wall") ) as GameObject;
					SetPosition(row,col,gameObjects[row, col]);
					break;
				case 2:
					Player = GameObject.Find("Player");
					SetPlayerPosition(row, col, Player);
					break;
				case 4:
					gameObjects[row, col] = Instantiate(Resources.Load ("Pass")) as GameObject;
					SetDoorPosition(row,col,gameObjects[row, col]);
					break;
				case 5:
					gameObjects[row, col] = Instantiate(Resources.Load ("AngryBox")) as GameObject;
					AngryBoxScript myAngry = gameObjects[row, col].GetComponent<AngryBoxScript>();

					int i = angryNumber[GameLevel - 1];
					int acount = i + angryCount;

					myAngry.SetLeftLimit(angryArray[acount, 0]);
					myAngry.SetRightLimit(angryArray[acount, 1]);

					angryCount++;
					
					SetPosition(row, col, gameObjects[row, col]);
					break;
                case 6:
                    gameObjects[row, col] = Instantiate(Resources.Load ("SpikeRight")) as GameObject;
                    SetPosition(row, col, gameObjects[row, col]);
                    break;
				case 7:
					gameObjects[row, col] = Instantiate(Resources.Load ("SpikeLeft")) as GameObject;
					SetPosition(row, col, gameObjects[row, col]);
					break;
				case 8:
					if(GameLevel == 4)
					{
						gameObjects[row, col] = Instantiate (Resources.Load ("BombBox")) as GameObject;
						BombBoxScript myBomb = gameObjects[row, col].GetComponent<BombBoxScript>();
					
						int j = bombNumber[GameLevel - 1];
						int bcount = j + bombCount;

						myBomb.SetLeftLimit(bombArray[bcount, 0]);
						myBomb.SetRightLimit(bombArray[bcount, 1]);
					
						bombCount++;
					}
					else
					{
						gameObjects[row, col] = Instantiate (Resources.Load ("BombBoxLevel5")) as GameObject;
						BombBoxLevel5Script myBomb = gameObjects[row, col].GetComponent<BombBoxLevel5Script>();
						
						int j = bombNumber[GameLevel - 1];
						int bcount = j + bombCount;
						
						myBomb.SetLeftLimit(bombArray[bcount, 0]);
						myBomb.SetRightLimit(bombArray[bcount, 1]);
						
						bombCount++;
					}
					
					SetPosition(row, col, gameObjects[row, col]);

					break;
				case 9:
					gameObjects[row, col] = Instantiate(Resources.Load ("Key")) as GameObject;
					SetPosition(row, col, gameObjects[row, col]);
					break;
				default: 
					break;
				}
			}
		}
	}


	void Start ()
	{
		musicInstant_fall = GameObject.FindGameObjectWithTag ("monster2");//music
	}

	// Update is called once per frame
	void Update () {
		//世界坐标转变成屏幕坐标
        if (Player != null)
        {
            Vector3 player_position = camera.WorldToScreenPoint(Player.transform.position);
            if (player_position.y < 0f)
            {
				musicInstant_fall.audio.Play ();//music
                //主角掉落深渊，游戏失败，跳转到失败结算页
                Application.LoadLevel("fail");
            }
        }
		//被炸死，游戏失败
		if (isBomb) {
			isBomb = false;
			Application.LoadLevel ("fail");
		}
	}

    

    public static void GetIndex(GameObject obj, out int row, out int col)
    {
        row = Convert.ToInt32((3.8f - obj.transform.position.y) / height);
        col = Convert.ToInt32((6.8f + obj.transform.position.x) / width);
    }
    public static Boolean IsUpBlank(GameObject obj)
    {
        int row, col;
        GetIndex(obj, out row, out col);
        if (row == 0)
            return false;
        switch (map[GameLevel, row - 1, col])
        {
            case 0:
			//Debug .Log ("000");
                return !IsUpPlatform(obj);;
            case 9:
                return true;
            default:
                return false;
        }
    }
    private static Boolean IsUpPlatform(GameObject obj)
    {
        switch (GameLevel)
        {
            case 3:
            case 4:
                GameObject platform = GameObject.Find("Platform");
                return IsRightUnder(obj,platform);
            default:
                return false;
        }
    }
    //obj1正好位于obj2
    private static Boolean IsRightUnder(GameObject obj1,GameObject obj2)
    {
        Vector3 pos = obj1.transform.position + new Vector3(0, height, 0);
        Vector3 pos2 = obj2.transform.position;
        if (!IsBetween(pos.y, pos2.y - height*0.5f, pos2.y + height * 0.5f))
            return false;
        if (!IsBetween(pos.x, pos2.x - width * 1.5f, pos2.x + width * 1.5f))
            return false;
        return true;
    }

    private static Boolean IsBetween(float mid, float small, float big)
    {
        if (mid < small)
            return false;
        if (mid > big)
            return false;
        return true;
    }

	void SetPosition(int row, int col, GameObject obj)
	{
		Vector3 pos = new Vector3();
		pos.x = col*width - 6.8f;
		pos.y = 3.8f - row*height;
		pos.z = 0f;
		obj.transform.position = pos;
	}
	
    void SetPlayerPosition(int row, int col, GameObject obj)
    {
        Vector3 pos = new Vector3();
        pos.x = col * width - 6.8f;
        pos.y = 3.8f - row * height ;//Player比一般盒子高0.2
        pos.z = 0f;
        obj.transform.position = pos;
    }

	void SetDoorPosition(int row, int col, GameObject obj)
	{
		Vector3 pos = new Vector3();
		pos.x = col * width - 6.8f;
		pos.y = 3.8f - row * height + 0.06f;//Player比一般盒子高0.06
		pos.z = 0f;
		obj.transform.position = pos;
	}
}