using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGetStarScript : MonoBehaviour {

	public bool isPlayer = true;
	private int starNumber = 0;

	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		StarScript star = otherCollider.gameObject.GetComponent<StarScript> ();
        if (star != null) 
		{
			if(star.isPlayer == isPlayer)
			{
				Destroy (star.gameObject);
				starNumber++;
			}
		}
    }

	public int GetStarNumber()
	{
		return starNumber;
	}
}
