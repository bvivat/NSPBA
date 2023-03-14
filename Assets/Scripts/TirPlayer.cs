using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TirPlayer : MonoBehaviour
{

    public GameObject balle;

	public float fireRate = 0.1f;
	public float nextFire = 0;
	public int magazineSize = 5;
	public float reloadSpeed = 2;
	public int magazineBulletsLefts = 5;
	
	public bool isAuto;
	private ActionButtons btn;

   
    // Update is called once per frame
    void Update()
    {
	
		if (Input.GetKeyDown(KeyCode.M))
		{
			shot();
		}
    }

	public void shot()
	{
		if (transform.childCount == 0 && Time.time > nextFire && magazineBulletsLefts > 0)
		{
			Instantiate(balle, transform);
			GetComponent<AudioSource>().Play();
			nextFire = Time.time + fireRate;
			magazineBulletsLefts--;
			if (magazineBulletsLefts == 0)
			{
				StartCoroutine("Reload");
			}
		} 
		
	}

	IEnumerator Reload()
	{
		btn.setReloadSpeed(reloadSpeed);
		btn.startReloadImg();
		magazineBulletsLefts--; // Put it to -1
		yield return new WaitForSeconds(reloadSpeed);
		magazineBulletsLefts = magazineSize;
		btn.endReloadImg();
		
	}

	public bool IsAuto()
	{
		return isAuto;
	}

	public void SetTouchControls(ActionButtons btn)
	{
		this.btn = btn;
	}

}
