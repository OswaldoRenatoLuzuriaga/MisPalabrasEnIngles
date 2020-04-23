using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaController : MonoBehaviour
{

	public string escena;

	public void Jugar()
	{
	
		SceneManager.LoadScene(escena);
	}

}
