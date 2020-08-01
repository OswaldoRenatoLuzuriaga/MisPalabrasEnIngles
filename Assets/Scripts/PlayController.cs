using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour
{

	public string escena;

      void OnMouseDown()
	{
		SceneManager.LoadScene(escena);
	}



}
