using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
	public GameObject player;
	public GameObject[] interactables = new GameObject[1];
	public float seuilDetection;
	private Image imgBtn;
	private Button btn;
	private bool active=false;

	public GameObject interactWith = null;

	public Interactable interactableObj;
	// Start is called before the first frame update
	void Start()
	{
		imgBtn = GetComponent<Image>();
		btn = GetComponent<Button>();
		disableBtn();
	}

	// Update is called once per frame
	void Update()
	{
		active = false;
		foreach (GameObject item in interactables)
		{
			if (  Mathf.Abs( player.transform.position.x - item.transform.position.x) <= seuilDetection && Mathf.Abs(player.transform.position.y - item.transform.position.y) <= seuilDetection)
			{
				active = true;
				enableBtn();
				break;
			}
		}
		if (active==false)
		{
			disableBtn();
		}

	}
	private void enableBtn()
	{
		imgBtn.enabled = true;
		btn.enabled = true;
	}
	private void disableBtn()
	{
		imgBtn.enabled = false;
		btn.enabled = false;
	}

	public void DoInteraction()
	{
		float closest = seuilDetection;
		interactWith=null;
		foreach (GameObject item in interactables)
		{
			float xDist = Mathf.Abs(player.transform.position.x - item.transform.position.x);
			float yDist = Mathf.Abs(player.transform.position.y - item.transform.position.y);
			if (xDist <= seuilDetection && yDist <= seuilDetection)
			{
				if (xDist < closest)
				{
					closest = xDist;
					interactWith = item;
				}
				if (yDist < closest)
				{
					closest = yDist;
					interactWith = item;
				}
			}
		}
		if (interactWith != null)
		{
			interactWith.GetComponent<Interactable>().DoInteraction();
			
		}
		
	}
}
