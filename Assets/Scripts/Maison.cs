using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{
	public Sprite MaisonOuverte;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Player")
		{
			//ouvre la maison au contact du joueur
			GetComponent<SpriteRenderer>().sprite = MaisonOuverte;
		}

	}
}
