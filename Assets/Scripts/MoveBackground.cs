using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    //public Rigidbody2D rb2D;
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
			//déplace le background en même temps que le joueur, pour donner une sensation de 3D
            transform.localPosition = new Vector3(player.transform.localPosition.x / 2, player.transform.localPosition.y/1.2f, transform.localPosition.z);
        }
         
     
    }

}
