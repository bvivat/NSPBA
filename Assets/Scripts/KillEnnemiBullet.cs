using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemiBullet : HealthSystem
{

	public override void OnDeath()
	{
		base.OnDeath();
		anim.SetBool("isShot", true);
		Debug.Log("Killed By Bullet !");
	}
}
