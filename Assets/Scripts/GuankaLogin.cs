using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Msdk;

public class GuankaLogin : MonoBehaviour {
	public static float start_time = 0.0f;
	public Text name;
	public Image head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		name.text = msdk.username;
		StartCoroutine ("downloadRoutine");
	}

	public void change(int level)
	{
        CameraScript.GameLevel = level-1;
		Application.LoadLevel ("scene"+level);
		start_time = Time.time;
	}

	void OnRelationNotify(string jsonRet)
	{
		Debug.Log ("OnRelationNotify=" + jsonRet);
		RelationRet ret = RelationRet.ParseJson (jsonRet);
		if (ret == null) {
			return;
		}
		msdk.username = ret.persons[0].nickName;
		msdk.imgurl_small = ret.persons [0].pictureSmall;
		msdk.imgurl_middle = ret.persons [0].pictureMiddle;
		msdk.imgurl_large = ret.persons [0].pictureLarge;
	}

	IEnumerator downloadRoutine ()
	{
		string url = msdk.imgurl_middle;
		if (null != url) {
			WWW www = new WWW (url);
			yield return www;
			if (string.IsNullOrEmpty (www.error)) {
				string contentType = www.responseHeaders ["CONTENT-TYPE"];
				var contents = contentType.Split ('/');
				if (contents [0] == "image") {
					if (contents [1].ToLower () == "png" || contents [1].ToLower () == "jpeg") {
						Texture2D t = www.texture;
						Sprite s = null;
						if (t != null)
							s = Sprite.Create (t, new Rect (0, 0, t.width, t.height), new Vector2 (0.5f, 0.5f));
						if (s != null)
							head.sprite = s;
					}
				}
			}
		}
	}
}
