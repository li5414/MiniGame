using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float force_move = 5;
	public Vector2 speed = new Vector2 (0.2f, 0.2f);
	private Animator anim;
	private Vector2 movement;

	void Awake ()
	{
		anim = this.GetComponent<Animator> ();
	}

	void Update ()
	{
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		bool up = Input.GetKey ("up");

	
		if (inputX > 0.05f) {
			rigidbody2D.AddForce (Vector2.right * force_move);
		} else if (inputX < -0.05f) {
			rigidbody2D.AddForce (-Vector2.right * force_move);
		}
		
		//修改朝向
		if (inputX > 0.05f) {//朝向右方向
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (inputX < -0.05f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		
		anim.SetFloat ("horizontal", Mathf.Abs (inputX));

		if (up) {
			transform .position += new Vector3 (0, 0.01f, 0);
		}

		movement = new Vector2 (inputX * force_move, 0);

		// 5 - Shooting
		bool shoot = Input.GetKey ("up");
		//shoot |= Input.GetButtonDown ("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				// false because the player is not an enemy
				weapon.Attack (false);
			}
		}
	}
	
	void FixedUpdate ()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}
}