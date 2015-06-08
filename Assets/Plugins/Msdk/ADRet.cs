using System;
using Msdk.Consts;
using LitJson;
using System.Text;
using UnityEngine;

namespace  Msdk
{
		public class ADRet
		{
				public string viewTag = "";
				public int scene;

				public ADRet ()
				{
				}

				public string ViewTag 
				{ 
					get{return viewTag;} 
					set{  viewTag = value;}
				}

				public int Scene 
				{ 
					get{return scene;} 
					set{  scene = value;}
				}

				public override System.String ToString ()
				{
					StringBuilder msg = new StringBuilder();
					msg.AppendLine("***********************LoginInfo***********************");
					msg.AppendLine("viewTag: " + this.viewTag);
					msg.AppendLine("scene: " + this.scene);
					msg.AppendLine("***********************LoginInfo***********************");
					Debug.Log(msg.ToString());
					return msg.ToString ();
				}

				/// <summary>
				/// 解析json串，返回一个ADRet，若解析失败返回null.
				/// </summary>
				/// <returns>The json.</returns>
				/// <param name="json">Json.</param>
				public static ADRet ParseJson(string json){                
					try{                                                   
						ADRet ret = JsonMapper.ToObject<ADRet>(json);                    
						return ret;                                  
					}catch (Exception ex)
					{
						Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
					}
					return null;		
				}  

		}
}

