using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	public static int Scene = 2;
	public void menu()
    {
		Scene = 2;
        SceneManager.LoadScene(0);
    }
}
