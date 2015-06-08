using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Msdk;
using Msdk.Consts;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using LitJson;
using com.tencent.bugly.unity3d;
using UnityEngine.UI;

public class msdk : MonoBehaviour {
	public static string username;
	private string openid;
	private int platform;
	public static bool flag = false;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Start()");
		// 打开bugly上报
		//InitBugly ();
		// 自动登录
		if (Application.platform == RuntimePlatform.Android) {
			Debug.Log ("使用本地票据登录");
			WGPlatform.Instance.WGLoginWithLocalInfo ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void InitBugly() 
	{
		// 开启SDK的调式开关        
		Bugly.EnableLog (true);
		// 设置C#堆栈日志捕获的级别，默认为Exception，可以选择为Assert、Error等
		Bugly.RegisterHandler (LogSeverity.Exception);
		
		// 如果你已经在Unity项目导出的Android或iOS工程中进行了SDK的初始化，则只需调用此方法完成C#堆栈捕获功能的开启
		Bugly.EnableExceptionHandler();
	}*/

	public void loginQQ(){
		if (Application.platform == RuntimePlatform.Android) {
			Debug.Log ("QQ登录");
			WGPlatform.Instance.WGLoginQQ ();
		} else {
			Application.LoadLevel("guanka");
		}
	}
	
	public void loginWX(){
		if (Application.platform == RuntimePlatform.Android) {
			Debug.Log ("微信登录");
			WGPlatform.Instance.WGLoginWX ();
		} else {
			Application.LoadLevel("guanka");
		}
	}

	/// <summary>
	///  登陆回调
	/// </summary>
	/// <param name="jsonRet">Json ret.</param>
	void OnLoginNotify(string jsonRet)
	{
		Debug.Log ("OnLoginNotify=" + jsonRet);
		LoginRet ret = LoginRet.ParseJson (jsonRet);
		if (ret == null) {
			//登陆失败
			return;
		}
		/*
		 *  loginRet.platform表示当前的授权平台, 值类型为ePlatform, 可能值为ePlatform_QQ, ePlatform_Weixin
	 	 *     loginRet.flag值表示返回状态, 可能值(eFlag枚举)如下：
		 *       eFlag_Succ: 返回成功, 游戏接收到此flag以后直接读取LoginRet结构体中的票据进行游戏授权流程.
		 *       eFlag_QQ_NoAcessToken: 手Q授权失败, 游戏接收到此flag以后引导用户去重新授权(重试)即可.
		 *       eFlag_QQ_UserCancel: 用户在授权过程中
		 *       eFlag_QQ_LoginFail: 手Q授权失败, 游戏接收到此flag以后引导用户去重新授权(重试)即可.
		 *       eFlag_QQ_NetworkErr: 手Q授权过程中出现网络错误, 游戏接收到此flag以后引导用户去重新授权(重试)即可.
		 *     loginRet.token是一个List<TokenRet>, 其中存放的TokenRet有type和value, 通过遍历Vector判断type来读取需要的票据. type(TokenType)类型定义如下:
		 *       eToken_QQ_Access,
		 *       eToken_QQ_Pay,
		 *       eToken_WX_Access,
		 *       eToken_WX_Refresh
		 */

		switch (ret.flag)
		{
		case CallbackFlag.eFlag_Succ:
			flag = true;
			Application.LoadLevel("guanka");
			openid = ret.open_id;
			// 登陆成功, 可以读取各种票据				
			platform = ret.platform;
			if(EPlatform.ePlatform_Weixin == platform)
			{
				//微信登陆成功
				WGPlatform.Instance.WGQueryMyWXInfo();
			}else if(EPlatform.ePlatform_QQ == platform)
			{
				//QQ登陆成功
				WGPlatform.Instance.WGQueryMyQQInfo();
			}else if(EPlatform.ePlatform_QQHall == platform)
			{
				//大厅登陆成功
			}
			break;
			// 游戏逻辑，对登陆失败情况分别进行处理
		case CallbackFlag.eFlag_Local_Invalid:
			// 自动登录失败, 需要重新授权, 包含本地票据过期, 刷新失败登所有错误
			break;
		case CallbackFlag.eFlag_WX_UserCancel:
		case CallbackFlag.eFlag_WX_NotInstall:
		case CallbackFlag.eFlag_WX_NotSupportApi:
		case CallbackFlag.eFlag_WX_LoginFail:
		default:
			break;
		}
	}

	void OnRelationNotify(string jsonRet)
	{
		Debug.Log ("OnRelationNotify=" + jsonRet);
		RelationRet ret = RelationRet.ParseJson (jsonRet);
		if (ret == null) {
			return;
		}
		username = ret.persons[0].nickName;
	}
}
