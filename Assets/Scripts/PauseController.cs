using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseController : MonoBehaviour
{

	Canvas canvas;
    private Button button;

	public Slider MusicSliderVolume;
	public Slider EfectSliderVolume;

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
	public void LoadState() {
		MusicSliderVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
		EfectSliderVolume.value = PlayerPrefs.GetFloat("EffectVolume", 0f);

	}

	//Guardamos los valores configurados de volumen
	public void SaveState() {
		PlayerPrefs.SetFloat("MusicVolume", MusicSliderVolume.value);
		PlayerPrefs.SetFloat("EffectVolume", EfectSliderVolume.value);
	}




/*Para poder utilizarlo el boton que llame al metodo tiene 
tiene que tener el compomente canvas group, que nos permitira
cambiar el alpha a todos los elementos que hay en en el canvas, para el canvas tiene 
que estar activado así como todos sus hijo este no aparecera hasta que no se pulse 
el botón*/


	public void Pausa() {
		//Habilita o deshabilita si el canvas esta habilitado
		if(!canvas.enabled){
           canvas.enabled = true;
		   //Detenemos el juego si esta deshabilitado
		    Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		    paused.TransitionTo(0.01f);
	}
		}
		

		





	public void Play() {
	

	  if(canvas.enabled){
        canvas.enabled = false;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		SaveState();
		play.TransitionTo(0.01f);
	  }
		
	}




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



	//Regulan el volumen de los efectos

	public void SetFXVolumen(float volumen) {

		masterMixer.SetFloat("EffectVolumen", volumen);

	}


	//Regulamos el volumen de la musica de fondo
	public void SetMusicVolumen(float volumen)
	{
		//Llamamos a la variable referenciada del mixer master "MusicVolumen"
		masterMixer.SetFloat("MusicVolumen", volumen);

	}


}
