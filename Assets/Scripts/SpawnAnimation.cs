using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnAnimation : MonoBehaviour
{

	Tween[] tweens = new Tween[2];
	void Start()
	{
		DOTween.Init();
		DOTween.defaultAutoPlay = AutoPlay.None;
		tweens[0] = transform.DOMoveY(-15, 3,false).SetAutoKill(false);
		tweens[1] = transform.DOMoveY(1, 0.5f,false).SetAutoKill(false);
		//tweens[2] = transform.DOPunchPosition(new Vector3(0, 1, 0), 1, 5, 0).SetAutoKill(false);
		DOTween.defaultAutoPlay = AutoPlay.All;
		StartCoroutine("PlayCoroutine");
	}

	public void playBackward()
	{

		StartCoroutine("BackwardsCoroutine");
	}

	IEnumerator PlayCoroutine()
	{
		for (int i = tweens.Length - 1; i >= 0; i--)
		{
			tweens[i].Play();
			yield return tweens[i].WaitForCompletion();
		}

	}
	IEnumerator BackwardsCoroutine()
	{
		foreach (Tween t in tweens)
		{
			t.PlayBackwards();
			yield return t.WaitForRewind();
		}

	}



	// Update is called once per frame
	void Update()
	{

	}
}
