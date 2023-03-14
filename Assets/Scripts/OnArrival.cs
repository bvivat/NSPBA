using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnArrival : MonoBehaviour
{
	public PolygonCollider2D colider;
	public GameObject[] objToShow = new GameObject[1];
	void Start()
	{
		colider = GetComponent<PolygonCollider2D>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Sol")
		{
			DoArrivalThings();
		}
	}

	private void DoArrivalThings()
	{
		foreach (GameObject item in objToShow)
		{
			item.SetActive(true);
		}

	}
}
