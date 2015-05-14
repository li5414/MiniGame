using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float force_move = 5;
	public Vector2 speed = new Vector2 (0.2f, 0.2f);
	
	private Animator anim;
	private WeaponScript weapon;
	private Rigidbody2D rig2D;
	
	void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		weapon = gameObject.GetComponent<WeaponScript> ();
		rig2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		
		if (inputX > 0.05f) {//朝向右方向
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (inputX < -0.05f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		
		anim.SetFloat ("horizontal", Mathf.Abs (inputX));
		
		if (Input.GetKey ("up")) 
		{
			transform .position += new Vector3 (0, 0.01f, 0);
			weapon.Attack (false);
		}
		
		// 5 - Move the game object
		rig2D.velocity = new Vector2 (inputX * force_move, 0);
	}
}