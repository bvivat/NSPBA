using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class KillPlayer : MonoBehaviour
{
    public GameObject gameOverPanel;
	public GameObject WinPanel;
	public AudioSource mort;
	public AudioSource win;

	// Start is called before the first frame update
	void Start()
    {
        gameOverPanel.SetActive(false);
		WinPanel.SetActive(false);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "ennemis" || collision.gameObject.tag == "MapLimite")
        {
			//Actions effectuées lors de l'entrée en collision du joueur avec le vide ou un ennemi
			mort.Play();
            transform.GetChild(0).parent = null;
            gameOverPanel.SetActive(true);
            Destroy(gameObject);
		}

		if (collision.gameObject.tag=="Maison")
		{
			//Actions effectuées lors de l'entrée en collision du joueur avec la maison
			win.Play();
			transform.GetChild(0).parent = null;
			WinPanel.SetActive(true);
			Destroy(gameObject);
		}

    }
}
