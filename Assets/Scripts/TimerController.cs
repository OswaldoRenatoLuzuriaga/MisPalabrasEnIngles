using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public TextMeshProUGUI segundero;
	public float tiempoActual;
	public Image healthBar;
	public Button ayuda1;
	
	public Image close;

	public Image panel;
	private float peso;

	public GameObject camaraGameOver;
	#endregion


	#region PRIVATE_VARIABLES
	private float timer = 120f;
	private bool isButtonHelp;
	private Animator anim;
	#endregion


	#region UNITY_MONOBEHAVIOUR_METHODS
	// Start is called before the first frame update
	void Start()
	{

		isButtonHelp = false;
		tiempoActual = 0;
		ActualizarTiempo();
		anim = GetComponent<Animator>();
		peso = 30;

	}

	
	void Update()
	{
		//Actualizamos el tiempo
		timer -= Time.deltaTime;

		segundero.text = " " + timer.ToString("f0");

		//Actualizamos la barra de salud
		tiempoActual += Time.deltaTime / 120;
		ActualizarTiempo();

		if (timer <= 0) {
			enabled = false;
			GameOver();
			
		}
		if (timer <= 11 && timer > 0)
		{
			Vibrar();
		}


		
		StartCoroutine(DisableButton());

	}


	#endregion

	#region PRIVATE_METHODS
	private void Vibrar() {
		anim.SetTrigger("Timer");
	}

	private IEnumerator LanzarGameOver() {
		yield return new WaitForSeconds(3f);
		enabled = true;
		SceneManager.LoadScene("GameOver");
	}
	private void GameOver() {
		StartCoroutine(LanzarGameOver());
		SoundSystem.soundEffect.Timer();
		segundero.text = "" + 0;
		
	}



	private void ActualizarTiempo()
	{
		healthBar.fillAmount = tiempoActual;

	}
	
	
	
	private IEnumerator DisableButton()
	{

		yield return new WaitForSeconds(0.1f);

		//Desabilitamos el boton de ayuda si este ya ha sido usado
		if (isButtonHelp)
		{
			close.gameObject.SetActive(true);
		
		}

	}

	#endregion

	#region PUBLIC_METHODS


	public void AddTiempo() {

		if (this.timer <= 90 && !isButtonHelp)
		{
			this.timer += peso;
			isButtonHelp = true;
			tiempoActual -= (peso / 120);
			ActualizarTiempo();
		}


	}


	#endregion


}
