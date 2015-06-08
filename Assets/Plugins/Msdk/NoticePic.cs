using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		public class NoticePic
		{
                public string mNoticeId;
                public string mPicUrl;
                public int mScreenDir;
                public string mPicHash;

                public string msgid 
                { 
                    get{return mNoticeId;} 
                    set{mNoticeId = value;}
                }
                
                public string picUrl 
                { 
                    get{return mPicUrl;} 
                    set{mPicUrl = value;}
                }

                public string hashValue 
                { 
                    get{return mPicHash;} 
                    set{mPicHash = value;}
                }

                public int screenDir
                { 
                    get{return mScreenDir;} 
                    set{mScreenDir = value;}
                }

				public NoticePic ()
				{
					mScreenDir = eMSDK_SCREENDIR.eMSDK_SCREENDIR_SENSOR;
				}
                
                public override string ToString()
                {
                    string screen = "";
                    if (mScreenDir == eMSDK_SCREENDIR.eMSDK_SCREENDIR_LANDSCAPE) {
                        screen = "LANDSCAPE";
                    } else if (mScreenDir == eMSDK_SCREENDIR.eMSDK_SCREENDIR_PORTRAIT) {
                        screen = "PORTRAIT";
                    } else {
                        screen = "SENSOR";
                    }
                    return "NoticeId:" + mNoticeId
                        + "PicUrl:" + mPicUrl
                        + "; ScreenDir: " + screen
                            + "; PicHash: " + mPicHash;
                }
		}
}

