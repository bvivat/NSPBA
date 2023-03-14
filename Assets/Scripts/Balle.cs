using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    Rigidbody2D rb;
    PolygonCollider2D col;
    bool estTourne=false;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.localScale.x < 0)
        {
            estTourne = true;
        }
        transform.parent = null;

        rb = transform.gameObject.AddComponent<Rigidbody2D>();
        rb.mass = 0;
        rb.gravityScale = 0;
        rb.drag = 0;
        rb.angularDrag = 0;
        if (estTourne)
        {
            rb.velocity = new Vector2(-75, 0);
        }
        else
        {
            rb.velocity = new Vector2(75, 0);
        }

        col = transform.gameObject.AddComponent<PolygonCollider2D>();
        col.isTrigger = true;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Changer en non trigger et désactiver collisions autres que avec ennemis ou sol ? (dans la matrice)
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Trap")
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }

    }
}
