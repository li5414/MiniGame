using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		public class KVPair
		{
			public string key = "";
			public string value = "";

            public string Key
            { 
                get{return key;} 
                set{ key = value;}
            }
            public string Value
            { 
                get{return value;} 
                set{ this.value = value;}
            }
		}
}

