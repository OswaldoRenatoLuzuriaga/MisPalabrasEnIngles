using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaController : MonoBehaviour
{

	public string escena;
	public string url;

	public void Jugar()
	{
	
		SceneManager.LoadScene(escena);
		
	}



	public void IrGuiaDeUsuario()

	{
		Application.OpenURL(url);
	}


}
