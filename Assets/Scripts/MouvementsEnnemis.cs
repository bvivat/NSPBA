using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementsEnnemis : MonoBehaviour
{
	public bool toucheVide;
	public bool toucheMur;
	public bool toucheSol;
	private int direction = 1;
	private int old = 1;
	private Vector2 pos;
	public LayerMask Layer;
	public float wallPosY;
	public float wallSize;
	public float voidPosX;
	public float voidPosY;
	public float voidSize;
	public float vitesse;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		pos = new Vector2(transform.localPosition.x, transform.localPosition.y);
		//Envoi de plusieurs rayons à gauche et à droite de l'ennemi pour vérifier si il est en contact avec un mur ou proche d'un rebord, pour alors se retourner.
		RaycastHit2D left1Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y + wallPosY), Vector2.left, wallSize, Layer);
		RaycastHit2D right1Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y + wallPosY), Vector2.right, wallSize, Layer);

		RaycastHit2D left2Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y - wallPosY), Vector2.left, wallSize, Layer);
		RaycastHit2D right2Wall = Physics2D.Raycast(new Vector2(pos.x, pos.y - wallPosY), Vector2.right, wallSize, Layer);

		RaycastHit2D void1 = Physics2D.Raycast(new Vector2(pos.x - voidPosX, pos.y - voidPosY), Vector2.down, voidSize, Layer);
		RaycastHit2D void2 = Physics2D.Raycast(new Vector2(pos.x + voidPosX, pos.y - voidPosY), Vector2.down, voidSize, Layer);

		//Affichage des rayons créés plus tot sur l'interface graphique du mode développeur pour des fins de débugage.
		Debug.DrawRay(new Vector2(pos.x, pos.y + wallPosY), Vector2.right * wallSize);
		Debug.DrawRay(new Vector2(pos.x, pos.y + wallPosY), Vector2.left * wallSize);
		Debug.DrawRay(new Vector2(pos.x, pos.y - wallPosY), Vector2.right * wallSize);
		Debug.DrawRay(new Vector2(pos.x, pos.y - wallPosY), Vector2.left * wallSize);
		Debug.DrawRay(new Vector2(pos.x - voidPosX, pos.y - voidPosY), Vector2.down * voidSize);
		Debug.DrawRay(new Vector2(pos.x + voidPosX, pos.y - voidPosY), Vector2.down * voidSize);

		toucheSol = void1.collider != null || void2.collider != null;
		if (toucheSol)
		{
			toucheMur = right1Wall.collider != null || right2Wall.collider != null || left1Wall.collider != null || left2Wall.collider != null;
			toucheVide = void1.collider == null || void2.collider == null;

			if (toucheMur || toucheVide)
			{
				direction *= -1;
				float scaleX = transform.localScale.x;
				transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
			}
			//Applique une force à l'ennemi pour qu'il avance
			transform.Translate(new Vector2(vitesse * direction, 0));
		}

	}
}
