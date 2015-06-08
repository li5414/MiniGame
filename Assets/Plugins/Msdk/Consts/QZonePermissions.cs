using UnityEngine;
using System.Collections;

namespace Msdk
{
	namespace Consts
	{
		/// <summary>
		/// QZONE权限 ，QZONE登录的时候调用 
		/// </summary>
		public class QZonePermissions {
			public const int eOPEN_NONE = 0;
			public const int eOPEN_PERMISSION_GET_USER_INFO = 0x2;
			public const int eOPEN_PERMISSION_GET_SIMPLE_USER_INFO = 0x4;
			public const int eOPEN_PERMISSION_ADD_ALBUM = 0x8;
			public const int eOPEN_PERMISSION_ADD_IDOL = 0x10;
			public const int eOPEN_PERMISSION_ADD_ONE_BLOG = 0x20;
			public const int eOPEN_PERMISSION_ADD_PIC_T = 0x40;
			public const int eOPEN_PERMISSION_ADD_SHARE = 0x80;
			public const int eOPEN_PERMISSION_ADD_TOPIC = 0x100;
			public const int eOPEN_PERMISSION_CHECK_PAGE_FANS = 0x200;
			public const int eOPEN_PERMISSION_DEL_IDOL = 0x400;
			public const int eOPEN_PERMISSION_DEL_T = 0x800;
			public const int eOPEN_PERMISSION_GET_FANSLIST = 0x1000;
			public const int eOPEN_PERMISSION_GET_IDOLLIST = 0x2000;
			public const int eOPEN_PERMISSION_GET_INFO = 0x4000;
			public const int eOPEN_PERMISSION_GET_OTHER_INFO = 0x8000;
			public const int eOPEN_PERMISSION_GET_REPOST_LIST = 0x10000;
			public const int eOPEN_PERMISSION_LIST_ALBUM = 0x20000;
			public const int eOPEN_PERMISSION_UPLOAD_PIC = 0x40000;
			public const int eOPEN_PERMISSION_GET_VIP_INFO = 0x80000;
			public const int eOPEN_PERMISSION_GET_VIP_RICH_INFO = 0x100000;
			public const int eOPEN_PERMISSION_GET_INTIMATE_FRIENDS_WEIBO = 0x200000;
			public const int eOPEN_PERMISSION_MATCH_NICK_TIPS_WEIBO = 0x400000;
			public const int eOPEN_PERMISSION_GET_APP_FRIENDS = 0x800000;
			public const int eOPEN_ALL = 0xffffff;
		}
	}
}
