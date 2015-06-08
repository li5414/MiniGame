using System;

namespace Msdk
{
	namespace Consts
	{
		/// <summary>
		/// unity与java端通信用JsonKey
		/// </summary>
		public class JsonKeyConst
		{
			public const string RET_FLAG = "Flag"; 
			public const string RET_DESC = "Desc"; 
			public const string RET_PLATFORM = "Platform"; 

			/** 以下与公告数据Json有关 **/

			// 平台给应用分配的唯一id，登陆前如果双平台则使用手Q｜微信组合的appid字符串
			public const string APP_ID = "appid";
			// 用户在应用的唯一帐号，没有获取到为空
			public const string OPEN_ID = "openid";
			// 消息id, 不可重复
			public const string NOTICE_ID = "msgid";
			// 公告标题
			public const string NOTICE_TITLE = "title";
			// 消息内容
			public const string NOTICE_CONTENT = "msgContent";
			// 公告场景，所属公告栏，有开始游戏公告栏等
			public const string NOTICE_SCENE = "scene";
			// 公告类型 0:弹出公告;1:滚动公告;其它无效
			public const string NOTICE_TYPE = "noticeType";
			//公告内容类型，0:文本内容；1:图片内容；2:网页内容，不填写的话默认为文本内容
			public const string NOTICE_CONTENT_TYPE = "contentType";
			// 有效开始时间，使用标准时间戳格式
			public const string START_TIME = "beginTime";
			// 有效结束时间，使用标准时间戳格式
			public const string END_TIME = "endTime";
			public const string UPDATE_TIME = "updateTime";
			// 公告详情跳转URL
			public const string NOTICE_URL = "msgUrl";
			// 公告list
			public const string NOTICE_LIST = "list";	
		
			// 游戏支持屏幕类型，1:横屏；2:竖屏；0:横屏竖屏均支持
			public const string SCREEN_DIR = "screenDir";		
			// 公告图片Vector
			public const string NOTICE_PIC_LIST = "picUrlList";
			// 图片URL
			public const string PIC_URL = "picUrl";
			// 图片hash值
			public const string PIC_HASH = "hashValue";		

            //网页公告的URL
            public const string NOTICE_CONTENT_WEB_URL = "contentUrl";

		}
	}
}

