using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemis : MonoBehaviour
{

    public Animator anim;
    public bool isAlive=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
			//Si l'ennemi n'est plus en vie, le détruit.
            Destroy(transform.parent.gameObject);
        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			//Actions effectuées lors de l'entrée en contact du joueur avec la tête de l'ennemi
            transform.parent.tag = "Untagged";
            anim.SetBool("isDead", true); //Lance l'animation liée à la mort de l'enemi
        }
      
    }
}

