using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortadaController : MonoBehaviour
{

	private Rigidbody rbd;
	private float downForce = 20000f;

	private void Awake()
	{
		rbd = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		
	}
	public void LanzarJuego() {

		Application.LoadLevel("GamePlay");
	}
}
