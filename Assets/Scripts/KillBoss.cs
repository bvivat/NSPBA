using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KillBoss : HealthSystem
{
	Slider healthBar;
	public Rigidbody2D bloc;
	SpriteRenderer sr;
	public AudioSource audioStart;
	public AudioSource audioStop;
	public AudioSource audioRestart;

	public SpawnAnimation spawn;


	public override void Start()
	{
		base.Start();
		healthBar = GetComponentInChildren<Slider>(true);
		healthBar.value = vie;
		sr = GetComponent<SpriteRenderer>();
	}
	public override void OnShot()
	{
		base.OnShot();
		healthBar.value = vie;

	}
	public override void OnDeath()
	{
		base.OnDeath();

		GetComponent<Animator>().enabled = false;
		StartCoroutine("SomeCoroutine");
		//transform.DOMoveY(10, 2);
		//transform.DOShakePosition(5, new Vector3(5, 5, 5));
		//anim.SetBool("isShot", true);
		Debug.Log("Killed By Bullet !");
		
	}
	IEnumerator SomeCoroutine()
	{
		Tween myTween = transform.DOMoveY(10, 1);
		yield return myTween.WaitForCompletion();
	
		transform.DOShakePosition(2, new Vector3(5, 5, 5));
		sr.DOColor(Color.red,2);
		audioStop.Stop();
		audioStart.Play();
		yield return new WaitForSeconds(audioStart.clip.length-1);
		bloc.gravityScale = -1.2f;
		spawn.playBackward();
		yield return transform.DOMoveY(-40, 2).WaitForCompletion();
		Destroy(this);
		audioRestart.Play();
		
	}
}
