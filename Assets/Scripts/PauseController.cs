using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseController : MonoBehaviour
{

	Canvas canvas;
  

	[Header("Slider")]
	public Slider MusicSliderVolume;
	public Slider EfectSliderVolume;

	[Header("Instancias de los mezcladores")]
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot play;

	public AudioMixer masterMixer;



	

    void Start()
    {
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		LoadState();
	}


	//Cargamos los valores que teniamos configurados
	private void LoadState() {
		MusicSliderVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
		EfectSliderVolume.value = PlayerPrefs.GetFloat("EffectVolume", 0f);

	}

	//Guardamos los valores configurados de volumen
	private void SaveState() {
		PlayerPrefs.SetFloat("MusicVolume", MusicSliderVolume.value);
		PlayerPrefs.SetFloat("EffectVolume", EfectSliderVolume.value);
	}




/*Para poder utilizar el boton que llame a este método
tiene que tener el compomente canvas group, que nos permitira
cambiar el alpha a todos los elementos que hay en en el canvas, por lo que el canvas tiene 
que estar activado así como todos sus hijos este no aparecera hasta que no se pulse 
el botón*/


	public void Pausa() {
		//Habilita o deshabilita si el canvas esta habilitado
		if(!canvas.enabled){
           canvas.enabled = true;
		   //Detenemos el juego si esta deshabilitado
		    Time.timeScale = 0;
			//Velocidad que se estableceran los valores de la instancia
		    paused.TransitionTo(0.01f);
	
		}
     }
		

		



	//Habilitamos la escena para seguir jugando.
	public void Play() {
	

	  if(canvas.enabled){
        canvas.enabled = false;
		Time.timeScale = 1;
		SaveState();
		//Velocidad que se estableceran los valores de la instancia
		play.TransitionTo(0.01f);
	  }
		
	}


	//Salimos de la aplicación

	public void OnApplicationQuit()
	{
	
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		SaveState();
#else
        Application.Quit();
		SaveState();
#endif

	}



	//Regulamos el volumen de los efectos de sonido que llegan del slider efecto de sonido

	public void SetFXVolumen(float volumen) {

		masterMixer.SetFloat("EffectVolumen", volumen);

	}

	//Regulamos el volumen de la musica de fondo que llegan del slider musica
	public void SetMusicVolumen(float volumen)
	{
		//Llamamos a la variable referenciada del mixer master "MusicVolumen"
		masterMixer.SetFloat("MusicVolumen", volumen);

	}



}
