using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaController : MonoBehaviour
{




	private void Update()
	{
		
	}
	public void LanzarJuego() {

		SceneManager.LoadScene("GamePlay");
	}
}
