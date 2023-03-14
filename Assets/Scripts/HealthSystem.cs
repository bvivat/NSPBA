using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	public Animator anim;
	public bool isAlive = true;
	public Rigidbody2D rigi;
	public int vie = 1;
	// Start is called before the first frame update
	public virtual void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isAlive)
		{
			Destroy(gameObject, 3);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			OnShot();
		}
		if (vie <= 0)
		{
			OnDeath();
		}
	}
	public virtual void OnShot()
	{
		vie--;
	}
	public virtual void OnDeath()
	{
		transform.gameObject.tag = "Untagged";
		rigi.isKinematic = true;
		Destroy(GetComponent<PolygonCollider2D>());
		Destroy(transform.GetChild(0).transform.gameObject);
		
		//Destroy(gameObject);
	}

}
