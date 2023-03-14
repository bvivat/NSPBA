using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouvementsPlayer : MonoBehaviour
{
	// Start is called before the first frame update
	public Rigidbody2D rb2D;
	public bool toucheSol = false;
	private float scaleX;
	public int hauteurSaut = 1000;
	public int nbSauts = 2;
	public float vitesse;
	private int sautsRestants;
	public bool toucheMurG = false;
	public bool toucheMurD = false;
	public LayerMask Layer;
	private Vector2 pos;

	public Joystick joystick;

	void Start()
	{
		scaleX = transform.localScale.x;

	}

	// Update is called once per frame
	void Update()
	{
		pos = new Vector2(transform.localPosition.x, transform.localPosition.y);

		//Envoi de plusieurs rayons à gauche et à droite du joueur pour vérifier si il est en contact avec un mur, pour l'empécher de continuer d'avancer.
		RaycastHit2D left1Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y + 0.8f), Vector2.left, 1f, Layer);
		RaycastHit2D right1Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y + 0.8f), Vector2.right, 1f, Layer);
		RaycastHit2D left2Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y - 0.8f), Vector2.left, 1f, Layer);
		RaycastHit2D right2Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y - 0.8f), Vector2.right, 1f, Layer);

		//Affichage des rayons créés plus tot sur l'interface graphique du mode développeur pour des fins de débugage.
		Debug.DrawRay(new Vector2(pos.x, pos.y + 0.8f), Vector2.right);
		Debug.DrawRay(new Vector2(pos.x, pos.y + 0.8f), Vector2.left);
		Debug.DrawRay(new Vector2(pos.x, pos.y - 0.8f), Vector2.right);
		Debug.DrawRay(new Vector2(pos.x, pos.y - 0.8f), Vector2.left);

		toucheMurD = right1Wall.collider != null || right2Wall.collider != null;
		toucheMurG = left1Wall.collider != null || left2Wall.collider != null;

		//Execution de diverses commandes du joueur en fonction des touches pressées
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump();
		}

		if ((Input.GetKey(KeyCode.D) || joystick.Horizontal > 0) && !toucheMurD)
		{

			transform.Translate(new Vector2(vitesse, 0));
			transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z); //retourner ou non le personnage
		}

		if ((Input.GetKey(KeyCode.Q) || joystick.Horizontal < 0) && !toucheMurG)
		{

			transform.Translate(new Vector2(-vitesse, 0));
			transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0;
		}

	}

	public void jump()
	{
		if (sautsRestants > 0)
		{
			sautsRestants--;
			rb2D.AddForce(new Vector2(0, hauteurSaut));
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		toucheSol = true;
		sautsRestants = nbSauts;
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		toucheSol = false;
	}
}
