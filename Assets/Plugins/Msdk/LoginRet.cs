using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{                
        
        /// <summary>
        /// 登陆回调对象
        /// </summary>
        public class LoginRet: CallbackRet
        {
                public string open_id = "";                       
                public string user_id = "";
                public string pf = "";
                public string pf_key = "";
                
                public string Open_id 
                { 
                    get{return open_id;} 
                    set{  open_id = value;}
                }
                public string User_id
                { 
                    get{return user_id;} 
                    set{  user_id = value;}
                }
                public string Pf 
                { 
                    get{return pf;} 
                    set{  pf = value;}
                }
                public string Pf_key 
                { 
                    get{return pf_key;} 
                    set{  pf_key = value;}
                }            
                public List<TokenRet> token = new List<TokenRet>();                        
                public List<TokenRet> Token
                { 
                    get{return token;} 
                    set{  token = value;}
                }    
                public override System.String ToString ()
                {
                    return ToLog ();
                }
                public string ToLog() 
                {
                    StringBuilder msg = new StringBuilder();
                    msg.AppendLine("***********************LoginInfo***********************");
                    msg.AppendLine("desc: " + this.desc);
                    msg.AppendLine("open_id: " + this.open_id);
                    msg.AppendLine("pf: " + this.pf);
                    msg.AppendLine("pf_key: " + this.pf_key);
                    msg.AppendLine("user_id: " + this.user_id);
                    msg.AppendLine("flag: " + "" + this.flag);
                    msg.AppendLine("platform: " + "" + this.platform);
                    for (int i = 0; i < this.token.Count; i++) {
                        string type = "";
                        switch (this.token[i].type) {
                        case TokenType.eToken_QQ_Access:
                            type = "eToken_QQ_Access";
                            break;
                        case TokenType.eToken_QQ_Pay:
                            type = "eToken_QQ_Pay";
                            break;
                        case TokenType.eToken_WX_Access:
                            type = "eToken_WX_Access";
                            break;
                        case TokenType.eToken_WX_Code:
                            type = "eToken_WX_Code";
                            break;
                        case TokenType.eToken_WX_Refresh:
                            type = "eToken_WX_Refresh";
                            break;
                        default:
                            type = "errorType";
                            break;
                        }
                        msg.AppendLine(type + ":" + this.token[i].value);
                        msg.AppendLine(type + ":" + this.token[i].expiration);
                    }
                    msg.AppendLine("***********************LoginInfo***********************");
                    Debug.Log(msg.ToString());
                    return msg.ToString ();
                }
                
                public string GetTokenByType(int type) {
                    for (int i = 0; i < this.token.Count; i++) {
                        if (this.token[i].type == type) {
                            return this.token[i].value;
                        }
                    }
                    return "";
                }
                
                public string GetAccessToken() {
                    int plat = this.platform;
                    string accessToken = "";
                    if (plat == WeGame.QQPLATID || plat == WeGame.QQHALL) {
                        accessToken = this.GetTokenByType(TokenType.eToken_QQ_Access);
                    } else if (plat == WeGame.WXPLATID) {
                        accessToken = this.GetTokenByType(TokenType.eToken_WX_Access);
                    }
                    return accessToken;
                    
                }
                public long GetTokenExpireByType(int type) {
                    for (int i = 0; i < this.token.Count; i++) {
                        if (this.token[i].type == type) {
                            return this.token[i].expiration;
                        }
                    }
                    return 0;
                }
                /// <summary>
                /// 解析json串，返回一个LoginRet，若解析失败返回null.
                /// </summary>
                /// <returns>The json.</returns>
                /// <param name="json">Json.</param>
                public static LoginRet ParseJson(string json){                
                        try{                                                   
                                 LoginRet ret = JsonMapper.ToObject<LoginRet>(json);                    
                                 return ret;                                  
                            }catch (Exception ex)
                            {
                                Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
                            }
                            return null;
           
                }    
       
                public LoginRet ()
                {
                }
                      
        }

       
}

