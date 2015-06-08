using System;

namespace Msdk
{
	namespace Consts
	{
		public class CallbackFlag
		{
				public const int eFlag_Succ = 0;
				/** QQ&QZone login fail and can't get accesstoken */
				public const int eFlag_QQ_NoAcessToken = 1000; 
				/** QQ&QZone user has cancelled login process */
				public const int eFlag_QQ_UserCancel = 1001; 
				
			/** QQ&QZone login fail (tencentDidNotLogin) */
				public const int eFlag_QQ_LoginFail = 1002; 
			/** QQ&QZone networkErr */
				public const int eFlag_QQ_NetworkErr = 1003; 
			/** QQ is not install */
				public const int eFlag_QQ_NotInstall = 1004;
			/** QQ don't support open api */
				public const int eFlag_QQ_NotSupportApi = 1005; 
			/** QQ&QZone networkErr */
				public const int eFlag_QQ_AccessTokenExpired = 1006; 
			/** pay token 过期 时间  */
				public const int eFlag_QQ_PayTokenExpired = 1007; 
				
			/** Weixin is not installed */
				public const int eFlag_WX_NotInstall = 2000; 
			/** Weixin don't support api */
				public const int eFlag_WX_NotSupportApi = 2001; 
			/** Weixin user has cancelled */
				public const int eFlag_WX_UserCancel = 2002; 
			/** Weixin User has denys */
				public const int eFlag_WX_UserDeny = 2003; 
				public const int eFlag_WX_LoginFail = 2004; 
			/** Weixin 刷新票据成功 */
				public const int eFlag_WX_RefreshTokenSucc = 2005; 
			/** Weixin 刷新票据失败 */
				public const int eFlag_WX_RefreshTokenFail = 2006; 
			/** Weixin accessToken过期, 尝试用refreshtoken刷新票据中 */
				public const int eFlag_WX_AccessTokenExpired = 2007; 
			/** Weixin refresh也过期 */
				public const int eFlag_WX_RefreshTokenExpired = 2008; 
				
				public const int eFlag_Error = -1;

			/** 自动登录失败, 需要重新授权, 包含本地票据过期, 刷新失败登所有错误 */
				public const int eFlag_Local_Invalid = -2; 

				/** 不在白名单 */
				public const int eFlag_NotInWhiteList = -3; 
			/** 需要引导用户开启定位服务 */
				public const int eFlag_LbsNeedOpenLocationService = -4; 
			/** 定位失败	 */
				public const int eFlag_LbsLocateFail = -5;

				/* 快速登陆相关返回值 */
			/**需要进入登陆页 */
				public const int eFlag_NeedLogin = 3001;
			/**使用URL登陆成功 */
				public const int eFlag_UrlLogin = 3002;
			/**需要弹出异帐号提示 */
				public const int eFlag_NeedSelectAccount = 3003; 
			/**通过URL将票据刷新 */
				public const int eFlag_AccountRefresh = 3004; 
		}		
	}
		
}

