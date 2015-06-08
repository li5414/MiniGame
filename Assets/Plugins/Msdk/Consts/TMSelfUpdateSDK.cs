using System;
namespace Msdk
{
	namespace Consts
	{
		public class TMSelfUpdateSDKUpdateInfo
		{
			public const int STATUS_OK = 0; 
			public const int STATUS_CHECKUPDATE_FAILURE = 1; 
			public const int STATUS_CHECKUPDATE_RESPONSE_IS_NULL = 2;

			public const int UpdateMethod_NoUpdate = 0; 
			public const int UpdateMethod_Normal = 1; 
			public const int UpdateMethod_ByPatch = 2; 
		}

		public class TMAssistantDownloadSDKTaskState
		{
			public const int DownloadSDKTaskState_WAITING = 1;
			public const int DownloadSDKTaskState_DOWNLOADING = 2;
			public const int DownloadSDKTaskState_SUCCEED = 4;
			public const int DownloadSDKTaskState_PAUSED = 3;
			public const int DownloadSDKTaskState_FAILED = 5;
			public const int DownloadSDKTaskState_DELETE = 6;
		}
	}
}

