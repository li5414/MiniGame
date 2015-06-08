using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		public class LocationRet : CallbackRet
		{
				public double longitude;
				public double latitude;

                public double Longitude
                { 
                    get{return longitude;} 
                    set{  longitude = value;}
                }
                public double Latitude
                { 
                    get{return latitude;} 
                    set{ latitude = value;}
                }
				public LocationRet ()
				{
				}
                
                /// <summary>
                /// 解析json串，返回一个LocationRet，若解析失败返回null.
                /// </summary>
                /// <returns>The json.</returns>
                /// <param name="json">Json.</param>
                public static LocationRet ParseJson(string json){                
                    try{                   
                        LocationRet ret = JsonMapper.ToObject<LocationRet>(json);                    
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
						this.longitude = (double)datas["longitude"];
						this.latitude = (double)datas["latitude"];
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
					+ "; longitude: " + longitude
					+ "; latitude: " + latitude;
				}
		}
}

