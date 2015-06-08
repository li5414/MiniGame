using System;
namespace Msdk
{
	namespace Consts
	{
		public class ErrorCodeFlag
		{
			public const int SDK_SUCCESS = 0;
			/** 有可能解析json获取不到ret值，这个时候返回的是-1，SafeJSONObject */
			public const int SDK_ERROR_NO_RET_VALUE = -1; 
			/** 用户取消 */
			public const int SDK_ERROR_USER_CANCEL = 1000; 
			/** 返回参数解析json异常  */
			public const int SDK_ERROR_JSON_VALUES = 1001;
			/** 返回参数为null */
			public const int SDK_ERROR_NETWORK_RETURN_NULL = 1002;
			/** 回调QQ onError函数  */
			public const int SDK_ERROR_QQ_NETWORK = 1003;
			/** 对应微信错误ERR_AUTH_DENIED  */
			public const int SDK_ERROR_WX_AUTH_DENIED = 1004;
			/** 对应微信错误登录失败 */
			public const int SDK_ERROR_WX_LOGIN_FAIL = 1005;
			/** 传入参数为空 */
			public const int SDK_ERROR_HTTP_PARAMS = 1006;
			
			/** <!--异常类错误分析--> */
			/** Unknown Exception */
			public const int SDK_ERROR_OTHER_ERROR = 3000;
			/** http连接超时 */
			public const int SDK_ERROR_HTTP_TIME_OUT = 3001;
			/** IllegalStateException */
			public const int SDK_ERROR_ILLEGAL_STATE = 3002;
			/** IOException */
			public const int SDK_ERROR_IO_EXCEPTION = 3003;
			/** IllegalArgumentException */
			public const int SDK_ERROR_ILLEGAL_ARGUMENT = 3004;
			/** SocketException */
			public const int SDK_ERROR_SOCKET_EXCEPTION = 3005;
			/** ClientProtocolException */
			public const int SDK_ERROR_CPROTOCOL_EXCEPTION = 3006;
			/** Unknow host网络不通时会出现此错误 */
			public const int SDK_ERROR_UNKNOWN_HOST = 3007;
			/** socket连接超时 */
			public const int SDK_ERROR_SOCKET_TIME_OUT = 3008;
		}
	}
}

