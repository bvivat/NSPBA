using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool clicked = false;
	public bool pointerDown=false;

	public TirPlayer weapon;

	public Image fireBtn;
	public Image reloadPlaceHolder;
	public Sprite fireBtnImg;
	public Sprite reloadBtnImg;
	private float reloadSpeed = 2;


	// Start is called before the first frame update
	void Start()
	{
		if (weapon != null)
		{
			weapon.SetTouchControls(this);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("Down !");
	}

	void Update()
	{
		if (fireBtn.fillAmount < 1)
		{
			fireBtn.fillAmount += 1.0f / reloadSpeed * Time.deltaTime;
		}
		if (pointerDown)
		{
			if (!weapon.IsAuto())
			{
				pointerDown = false;
			}
			weapon.shot();
		}
		
	}

	public void doClick()
	{
		clicked = true;
	}

	public bool isClicked()
	{
		return clicked;
	}


	public void setClicked(bool state)
	{
		clicked = state;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pointerDown = false;
	}

	public void startReloadImg()
	{
		fireBtn.sprite = reloadBtnImg;
		reloadPlaceHolder.enabled = true;
		fireBtn.fillAmount = 0;
	}
	public void endReloadImg()
	{
		reloadPlaceHolder.enabled = false;
		fireBtn.sprite = fireBtnImg;
	}
	public void setReloadSpeed(float reloadSpeed)
	{
		this.reloadSpeed = reloadSpeed;
	}

	public void setWeapon(TirPlayer weapon)
	{
		this.weapon = weapon;
		this.weapon.SetTouchControls(this);
	}
}
