using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoController : MonoBehaviour
{
	public static EstadoController estadoJuego;
	public int PuntuacionMaxima;

	private void Awake()
	{
		if (estadoJuego == null)
		{
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(estadoJuego != this){
			
			Destroy(gameObject);
		}
	}
	
}



