using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
        /// <summary>
        ///  拉起游戏的回调对象
        /// </summary>
        public class WakeupRet: CallbackRet
        {       
                /** 传递的openid */
                public string open_id = ""; 
                /** 对应微信消息中的mediaTagName */
                public string media_tag_name = ""; 
                /** 扩展消息,唤醒游戏时带给游戏 */
                public string messageExt = "";  
                /** 语言     目前只有微信5.1以上用，手Q不用 */
                public string lang = "";            
                /** 国家     目前只有微信5.1以上用，手Q不用 */
                public string country = "";        
                
                public string Open_Id
                { 
                    get{return open_id;} 
                    set{ open_id = value;}
                }
                public string Media_tag_name 
                { 
                    get{return media_tag_name ;} 
                    set{ media_tag_name  = value;}
                }
                public string MessageExt
                { 
                    get{return messageExt;} 
                    set{ messageExt = value;}
                }
                public string Lang
                { 
                    get{return lang;} 
                    set{ lang = value;}
                }
                public string Country
                { 
                    get{return country;} 
                    set{ country = value;}
                }                               
                public override string ToString()
                {
                    string str = base.ToString();
                    str += "open_id: " + open_id + ";";
                    str += "media_tag_name: " + media_tag_name + ";";
                    return str;
                }              
                public List<KVPair> extInfo = new List<KVPair>();
                 public List<KVPair> ExtInfo
                { 
                    get{return extInfo;} 
                    set{  extInfo = value;}
                }			
                
                public WakeupRet ()
                {
                }

                /// <summary>
                /// 解析json串，返回一个 WakeupRet，若解析失败返回null.
                /// </summary>
                /// <returns>The json.</returns>
                /// <param name="json">Json.</param>
                public static  WakeupRet ParseJson(string json)
                {                
                    try{                                
                        WakeupRet ret = JsonMapper.ToObject<WakeupRet>(json);                    
                        return ret;  
                    }catch (Exception ex)
                    {
                        Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
                    }
                    return null;
                }  
                
               
	    }

}

