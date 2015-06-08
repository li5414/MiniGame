using System;
using System.Collections.Generic;
using Msdk.Consts;
using LitJson;
using UnityEngine;
using System.Text;

namespace  Msdk
{
		public class PersonInfo
		{
			public string nickName = "";
			public string openId = "";
			public string gender = "";
			public string pictureSmall = "";
			public string pictureMiddle = "";
			public string pictureLarge = "";
			public string province = "";
			public string city = "";
			public string gpsCity = "";
			
			public float distance = 0;
			public bool isFriend = false;
			public long timestamp = 0;
			
			public string lang = "";
			public string country = "";
			
            public string NickName
            { 
                get{return nickName;} 
                set{  nickName = value;}
            }
            public string OpenId
            { 
                get{return openId;} 
                set{  openId = value;}
            }
            public string Gender
            { 
                get{return gender;} 
                set{  gender = value;}
            }
            public string PictureSmall
            { 
                get{return pictureSmall;} 
                set{  pictureSmall = value;}
            }
            public string PictureMiddle
            { 
                get{return pictureMiddle;} 
                set{  pictureMiddle = value;}
            }
            public string PictureLarge
            { 
                get{return pictureLarge;} 
                set{  pictureLarge = value;}
            }
            public string Province
            { 
                get{return province;} 
                set{  province = value;}
            }
            public string City
            { 
                get{return city;} 
                set{  city = value;}
            }
            public string GpsCity
            { 
                get{return gpsCity;} 
                set{  gpsCity = value;}
            }
            public string Distance
            { 
                get{return distance.ToString();} 
                set{  distance = float.Parse(value);}
            }
            public bool IsFriend
            { 
                get{return isFriend;} 
                set{  isFriend = value;}
            }
            public string Timestamp
            { 
                get{return timestamp.ToString();} 
                set{  timestamp = long.Parse(value);}
            }
            public string Lang
            { 
                get{return lang;} 
                set{  lang = value;}
            }
            public string Country
            { 
                get{return country;} 
                set{  country = value;}
            }
			public PersonInfo() {
				
			}
			
			public PersonInfo(string nickName, string openId, string gender,
			                  string pictureSmall, string pictureMiddle, string pictureLarge,
		                  string provice, string city): base()
			{
				this.nickName = nickName;
				this.openId = openId;
				this.gender = gender;
				this.pictureSmall = pictureSmall;
				this.pictureMiddle = pictureMiddle;
				this.pictureLarge = pictureLarge;
				this.province = provice;
				this.city = city;
			}
			
			public PersonInfo(string nickName, string openId, string gender,
			                  string pictureSmall, string pictureMiddle, string pictureLarge,
			                  string provice, string city, string gpsCity, string lang, string country) : base()
			{
				this.nickName = nickName;
				this.openId = openId;
				this.gender = gender;
				this.pictureSmall = pictureSmall;
				this.pictureMiddle = pictureMiddle;
				this.pictureLarge = pictureLarge;
				this.province = provice;
				this.city = city;
				this.gpsCity = gpsCity;
				this.lang = lang;
				this.country = country;
			}
			
			public PersonInfo(string nickName, string openId, string gender,
			                  string pictureSmall, string pictureMiddle, string pictureLarge,
			                  string province, string city, float distance, bool isFriend,
			                  long timestamp) : base()
			{
				this.nickName = nickName;
				this.openId = openId;
				this.gender = gender;
				this.pictureSmall = pictureSmall;
				this.pictureMiddle = pictureMiddle;
				this.pictureLarge = pictureLarge;
				this.province = province;
				this.city = city;
				this.distance = distance;
				this.isFriend = isFriend;
				this.timestamp = timestamp;
			}
			
			public PersonInfo(string nickName, string openId, string gender,
			                  string pictureSmall, string pictureMiddle, string pictureLarge,
			                  string province, string city, string lang, string country):base(){		
				this.nickName = nickName;
				this.openId = openId;
				this.gender = gender;
				this.pictureSmall = pictureSmall;
				this.pictureMiddle = pictureMiddle;
				this.pictureLarge = pictureLarge;
				this.province = province;
				this.city = city;
				this.lang = lang;
				this.country = country;
			}
						
			public override string ToString() {
				string str = "";
				str += "nickName: " + nickName + "; ";
				str += "openId: " + openId + "; ";
				str += "gender: " + gender + "; ";
				str += "pictureSmall: " + pictureSmall + "; ";
				str += "pictureMiddle: " + pictureMiddle + "; ";
				str += "pictureLarge: " + pictureLarge + "; ";
				str += "provice: " + province + "; ";
				str += "city: " + city + "; ";
				str += "distance: " + distance + "; ";
				str += "isFriend: " + isFriend + "; ";
				str += "timestamp: " + timestamp + "; ";
				str += "lang: " + lang + "; ";
				str += "country: " + country + "; ";
				return str;
			}
		}
}

