using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;
using System.Collections;

namespace  Msdk
{
		/// <summary>
		/// 纯数据公告.
		/// </summary>
		public class NoticeInfo
		{									
            public string mNoticeId; // 公告id           
			public string mAppId ; // appid           
            public string mOpenId; // 用户open_id           
			public string mNoticeUrl ; // 公告跳转链接            
			public int mNoticeType ; // 公告展示类型，滚动弹出           
			public string mNoticeScene ; // 公告展示的场景，管理端后台配置           
            public string mNoticeStartTime; // 公告有效期开始时间           
			public string mNoticeEndTime ; // 公告有效期结束时间           
			public string mNoticeUpdateTime ; // 公告更新时间            
            public int mNoticeContentType;// 公告内容类型，eMSG_NOTICETYPE            
			
			//文本公告特殊字段
			public string mNoticeTitle ; // 公告标题            
            public string mNoticeContent;// 公告内容           
			
			//图片公告特殊字段
			public string mNoticeHImgUrl ;           
			public string mNoticeHImgHash ;            
			public string mNoticeVImgUrl ;           
			public string mNoticeVImgHash ;
            //网页公告特殊字段
            public string mNoticeContentWebUrl; 
			
			public List<NoticePic> mNoticePics = new List<NoticePic>();

            /* 以下方法是为了能使用LitJson的自动将Json映射为Object方法 */
            public string updateTime 
            { 
                get{return mNoticeUpdateTime;} 
                set{  mNoticeUpdateTime = value;}
            }
            public string title
            { 
                get{return mNoticeTitle;} 
                set{ mNoticeTitle = value;}
            }
            public int contentType
            { 
                get{return mNoticeContentType;} 
                set{ mNoticeContentType = value;}
            }
            public string endTime
            { 
                get{return mNoticeId;} 
                set{  mNoticeId = value;}
            }
            public string beginTime 
            { 
                get{return mNoticeStartTime;} 
                set{  mNoticeStartTime = value;}
            }
            public string scene
            { 
                get{return mNoticeScene;} 
                set{mNoticeScene = value;}
            }
            public int noticeType 
            { 
                get{return mNoticeType;} 
                set{ mNoticeType = value;}
            }
            public string msgUrl 
            { 
                get{return mNoticeUrl;} 
                set{mNoticeUrl = value;}
            }
            public string contentUrl
            { 
                get{return mNoticeContentWebUrl;} 
                set{ mNoticeContentWebUrl = value;}
            }
            public string appid 
            { 
                get{return mAppId;} 
                set{mAppId = value;}
            }
            public string msgid 
            { 
                get{return mNoticeId;} 
                set{mNoticeId = value;}
            }
            public string openid
            { 
                get{return mOpenId;} 
                set{mOpenId = value;}
            }
            public string msgContent
            { 
                get{return mNoticeContent;} 
                set{ mNoticeContent = value;}
            }
            public List<NoticePic> picUrlList
            { 
                get{return mNoticePics;} 
                set{ mNoticePics = value;}
            }
			
            public NoticeInfo list{ get; set;}
			          

			public NoticeInfo ()
			{
			}

        public override string ToString()
        {
            string noticePics = "";
            if (mNoticePics.Count > 0) {
                for(int i = 0; i < mNoticePics.Count; i++){
                    noticePics += mNoticePics[i].ToString() + ";";
                }
            }
            return "NoticeId:" + mNoticeId
                + "NoticeContentType:" + mNoticeContentType
                    + "; NoticeTitle: " + mNoticeTitle
                    + "; NoticeContent: " + mNoticeContent
                    + "; NoticePic: " + noticePics;
                
        }
              

        public static  List<NoticeInfo> ParseJson(string json){
            Debug.Log ("len:"+json.Length+"NoticeInfo:" + json);
            try{
                JsonData datas = JsonMapper.ToObject(json); 
                if(datas[JsonKeyConst.NOTICE_LIST].IsArray){
                    NoticeInfoList noticeList = JsonMapper.ToObject<NoticeInfoList>(json);
                    return noticeList.list;
                }
            }catch (Exception ex)
            {
                Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
            }
            return null;
        }               		
	}

    /// <summary>
    /// 方便解析json的类
    /// </summary>
    public class NoticeInfoList
    {
        public List<NoticeInfo> list { get; set; }
        public NoticeInfoList ()
        {
        }
    }      
}

