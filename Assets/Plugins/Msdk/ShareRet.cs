using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		/// <summary>
		/// 分享回调对象
		/// </summary>
		public class ShareRet: CallbackRet
		{
				public string extInfo = "";
                public string ExtInfo
                { 
                    get{return extInfo;} 
                    set{ extInfo = value;}
                }
				public ShareRet ()
				{
				}
                /// <summary>
                /// 解析json串，返回一个ShareRet，若解析失败返回null.
                /// </summary>
                /// <returns>The json.</returns>
                /// <param name="json">Json.</param>
                public static ShareRet ParseJson(string json){                
                    try{                   
                        ShareRet ret = JsonMapper.ToObject<ShareRet>(json);                    
                        return ret;                    
                    }catch (Exception ex)
                    {
                        Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
                    }
                    return null;
                }            
				/*
				public bool ParseJson(string json)
				{
					Debug.Log (json);
					try
					{					
						JsonData datas = JsonMapper.ToObject(json);					
						this.flag = (int)datas[JsonKeyConst.RET_FLAG];
						this.desc = (string)datas[JsonKeyConst.RET_DESC];
						this.platform = (int)datas[JsonKeyConst.RET_PLATFORM];				
						this.extInfo = (string)datas["extInfo"];						
						return true;
					} catch (Exception ex) 
					{
						Debug.Log(ex.Message+"\n"+ex.StackTrace);
					}
					return false;
				}
                */
				public override string ToString()
				{
					return base.ToString() 
						+ "; extInfo: " + extInfo;
				}
	}
}

