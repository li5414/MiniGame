using UnityEngine;
using System.Collections ;
/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Damage inflicted
	/// </summary>
	//public int damage = 1;
	
	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;
	static public int bo = 5;//可用盒子数

	//IEnumerator wait(float t)
	//{
		//yield return new WaitForSeconds(t);
	//}

	void OnDestroy()
	{
		bo++;
	}

	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy (gameObject, 3);  // 20sec
	}
}