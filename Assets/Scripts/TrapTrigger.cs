using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
	public Rigidbody2D[] rgbdKinematicToDisable = new Rigidbody2D[1];
	public AudioSource audioStart;
	public AudioSource audioStart2;
	public AudioSource audioStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			foreach (Rigidbody2D rgbd in rgbdKinematicToDisable)
			{
				rgbd.isKinematic = false;
			}
			audioStop.Stop();
			audioStart.Play();
			audioStart2.PlayScheduled(AudioSettings.dspTime+audioStart.clip.length);
			Destroy(this);
		}
	}
}
