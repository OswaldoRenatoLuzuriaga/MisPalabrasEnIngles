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
	public Image helpAdd;
	public Image helpClose;

	public GameObject camaraGameOver;
	#endregion


	#region PRIVATE_VARIABLES
	private float timeMax = 30f;
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

	}

	
	void Update()
	{
		//Actualizamos el tiempo
		timeMax -= Time.deltaTime;

		segundero.text = " " + timeMax.ToString("f0");

		//Actualizamos la barra de salud
		tiempoActual += Time.deltaTime / 30;
		ActualizarTiempo();

		if (timeMax <= 0) {
			enabled = false;
			GameOver();
			
		}
		if (timeMax <= 11 && timeMax > 0)
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
		SoundSystem.sonido.PlayAudioTimer();
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
			helpAdd.enabled = false;
			helpClose.enabled = true;
		}

	}

	#endregion

	#region PUBLIC_METHODS
	public void AddTiempo() {

		if (this.timeMax <= 20 && !isButtonHelp)
		{
			this.timeMax += 5f;
			isButtonHelp = true;
			tiempoActual -= 0.16f;
			ActualizarTiempo();
		}


	}


	#endregion


}
