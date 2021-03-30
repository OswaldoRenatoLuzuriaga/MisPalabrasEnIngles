using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using Proyecto26;
public class TimerController : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public TextMeshProUGUI segundero;
	public float tiempoActual;
	public Image healthBar;
	public Button help1;
	
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


	[Header("Panel Game Over")]
	public Canvas canvas;
	public TextMeshProUGUI score;
	public TextMeshProUGUI scoreTotal;
	public AudioMixerSnapshot paused;


	#region UNITY_MONOBEHAVIOUR_METHODS
	// Start is called before the first frame update
	void Start()
	{
		canvas.enabled = false;
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


	private IEnumerator GetUserDatabase(string id)
	{

		yield return new WaitForSeconds(20f);
		Debug.Log("https://animals-c205c.firebaseio.com/users/" + id + ".json");
		RestClient.Get("https://animals-c205c.firebaseio.com/users/" + id + ".json").Then((response) =>
		{

			
			Debug.Log("El jugador de firebase es ---------> " + response.StatusCode+ response);
			


		}).Catch(err => { Debug.Log("Error al descargar el usuario"); });

	}

	private IEnumerator LanzarGameOver() {
	
	
		yield return new WaitForSeconds(3f);
		enabled = true;
		GameObject panelDeOpciones = GameObject.FindGameObjectWithTag("GestorPreguntas");
		score.text = panelDeOpciones.GetComponent<OptionController>().getScore();
		
		canvas.enabled = true;
		
		//SceneManager.LoadScene("GameOver");
	}
	private void GameOver() {
		StartCoroutine(LanzarGameOver());
		
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
