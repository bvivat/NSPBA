using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
	public GameObject loot;
	public GameObject player;
	public override void DoInteraction()
	{
		GameObject lootInstance = Instantiate(loot, player.transform);
		//lootInstance.transform.position = new Vector3(1.2f, -0.21f, -2);
		player.transform.Find("Gun")?.gameObject.SetActive(false);
		player.transform.Find("controls/actionButton")?.GetComponent<ActionButtons>().setWeapon(lootInstance.GetComponent<TirPlayer>());
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
