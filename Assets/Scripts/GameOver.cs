using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.CodeDom;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
	


	public void Play()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void Menu() {
		SceneManager.LoadScene("Portada");
	}

}