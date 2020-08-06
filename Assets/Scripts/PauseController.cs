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

	Canvas canvasPause;

	public Slider MusicSliderVolume;
	public Slider EfectSliderVolume;

	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot play;

	public AudioMixer masterMixer;

	public GameObject panel;

    void Start()
    {
		canvasPause = GetComponent<Canvas>();
		canvasPause.enabled = false;
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



	public void Pausa() {
		//Habilita o deshabilita si el canvas esta habilitado
		//canvasPause.enabled = !canvasPause.enabled;
//		canvasPause.gameObject.SetActive(true);
        canvasPause.enabled = false;
		Debug.LogError("Estoy pausando el tiempo");
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		paused.TransitionTo(0.01f);
	}



	public void Play() {
		 canvasPause.enabled = true;
		//canvasPause.gameObject.SetActive(false);
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		SaveState();
		play.TransitionTo(0.01f);
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
