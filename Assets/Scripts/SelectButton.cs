using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
	//Actions effectuées lors du click sur les flèches sur le menu
	public void RightButton()
	{
		
		if (MenuButton.Scene!= SceneManager.sceneCountInBuildSettings-2)
		{
			MenuButton.Scene++;
			string pathToScene = SceneUtility.GetScenePathByBuildIndex(MenuButton.Scene);
			GetComponentInParent<Text>().text = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
		}
	}

	public void LeftButton()
	{
		if (MenuButton.Scene != 2)
		{
			MenuButton.Scene--;
			string pathToScene = SceneUtility.GetScenePathByBuildIndex(MenuButton.Scene);
			GetComponentInParent<Text>().text = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
		}
	}
}
