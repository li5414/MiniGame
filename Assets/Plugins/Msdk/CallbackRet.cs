using System;

namespace  Msdk
{
		public abstract class CallbackRet
		{
				public int flag = -1;
				public string desc = "";
				public int platform = 0;
				
                /* 以下方法是为了能使用LitJson的自动将Json映射为Object方法 */
                public int Flag 
                { 
                    get{return flag;} 
                    set{  flag = value;}
                }
                public string Desc 
                { 
                    get{return desc;} 
                    set{  desc = value;}
                }
                public int Platform 
                { 
                    get{return platform;} 
                    set{  platform = value;}
                }

				public CallbackRet(int platform, int flag, string desc) {
					this.platform = platform;
					this.flag = flag;
					this.desc = desc;
				}
				public CallbackRet ()
				{
				}
								
				public override string ToString(){
					string str = "flag: " + flag + ";";
					str += "desc: " + desc + ";";
					str += "platform: " + platform + ";";
					return str;
				}
		}
}

