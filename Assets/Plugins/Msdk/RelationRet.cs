using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		public class RelationRet : CallbackRet
		{
			public List<PersonInfo> persons = new List<PersonInfo>();
            public List<PersonInfo> Persons { 
                get{return persons;} 
                set{ persons = value;}
            }
            /// <summary>
            /// 解析json串，返回一个RelationRet，若解析失败返回null.
            /// </summary>
            /// <returns>The json.</returns>
            /// <param name="json">Json.</param>
            public static RelationRet ParseJson(string json){                
                try{                   
                    RelationRet ret = JsonMapper.ToObject<RelationRet>(json);                    
                    return ret;    
                }catch (Exception ex)
                {
                    Debug.Log("errro:"+ex.Message+"\n"+ex.StackTrace);
                }
                return null;
            }               
            public override string ToString() {
                String str = "";
                if (this != null && this.persons != null) {
                    str = base.ToString();
                    str = str + "friends(num): " + this.persons.Count + ";";
                } else {
                    str = "friends(num): 0;";
                }
                return str;
            }

            public RelationRet(){
            }
              
            
		}
}

