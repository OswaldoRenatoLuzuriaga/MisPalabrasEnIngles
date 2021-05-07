using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System;
using UnityEngine.Networking;
using System.Text;

public class TimerController : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	[Header("Timer")]
	public TextMeshProUGUI segundero;
	public float tiempoActual;
	public Image healthBar;
	public Button help1;
	public Image close;
	public Image panel;

	#endregion


	#region PRIVATE_VARIABLES
	public float timer = 120f;
	private bool isButtonHelp;
	private Animator anim;
	private float peso;
	#endregion


	[Header("Panel Game Over")]
	public Canvas canvas;

	[Header("Score")]
	public TextMeshProUGUI score;
	public TextMeshProUGUI scoreTotal;

	[Header("Paused")]
	public AudioMixerSnapshot paused;


	private const string URL = "https://animals-c205c.firebaseio.com/";
	#region UNITY_MONOBEHAVIOUR_METHODS
	// Start is called before the first frame update
	void Start()
	{
		canvas.enabled = false;
		isButtonHelp = false;
		tiempoActual = 0;
		ActualizarSlider();
		anim = GetComponent<Animator>();
		peso = 30;

	}

	
	void Update()
	{
		//Actualizamos el tiempo 120 segundos menos el tiempo transcurrido
		timer -= Time.deltaTime;
		segundero.text = " " + timer.ToString("f0");
		//Actualizamos la barra de salud
		tiempoActual += Time.deltaTime / 120;
		ActualizarSlider();
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
		GameObject panelDeOpciones = GameObject.FindGameObjectWithTag("GestorPreguntas");
		score.text = "Aciertos: " + panelDeOpciones.GetComponent<OptionController>().getScore();
	

		int record;
	    Int32.TryParse(PlayerPrefs.GetString("RecordTotal"), out record);

		int puntosActuales = panelDeOpciones.GetComponent<OptionController>().getScore();

	
		Debug.Log("-----Los Puntos actuales son " + score.text.ToString() + "El record es " + record);
		

		//Si los puntos actuales son mayores lo actualizamos
		if(puntosActuales > record)
        {
			scoreTotal.text = "Récord de aciertos: " +  puntosActuales;
			PlayerPrefs.SetString("RecordTotal", Convert.ToString(puntosActuales));
			StartCoroutine(PutUser());
		
		}
        else
        {
			scoreTotal.text = "Récord de aciertos: " + record;
			
		}
		
		
		canvas.enabled = true;

}


	public void Play()
    {

		SceneManager.LoadScene("GamePlay");
	}

	public void Home()
    {
		SceneManager.LoadScene("Portada");
	}




	IEnumerator PutUser()
	{

		User player = new User();
		player._score = PlayerPrefs.GetString("ScoreJugador");
		player._name = PlayerPrefs.GetString("NombreJugador");
		player._record = PlayerPrefs.GetString("RecordTotal");
		player._id = PlayerPrefs.GetString("Id_Player");
		player._email = PlayerPrefs.GetString("email");



		byte[] myData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(player));

		using (UnityWebRequest www = UnityWebRequest.Put(URL + "/users/" + PlayerPrefs.GetString("Id_Player") + ".json", myData))
		{
			yield return www.SendWebRequest();

			

			if (www.isNetworkError)
			{
				Debug.Log("Error al enviar el usuario " + www.error);
			}
			else
			{
				Debug.Log("Upload complete!");
			}
		}
	}



	public void GameOver() {
		StartCoroutine(LanzarGameOver());
		
		segundero.text = "" + 0;
		
	}



	private void ActualizarSlider()
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

			ActualizarSlider();
		}


	}


	#endregion


}
