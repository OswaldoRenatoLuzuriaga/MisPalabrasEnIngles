using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
	public static SoundEffects sonido;
	public AudioSource audioSource;
	public AudioClip audioClipTimer;
	public AudioClip audioClipExplosion;
	public AudioClip audioPanda;
	public AudioClip audioFox;




	#region UNITY_MONOBEHAVIOUR_METHODS
	private void Awake()
	{
		if (SoundEffects.sonido == null)
		{

			SoundEffects.sonido = this;
		}
		else if (SoundEffects.sonido != this)
		{

			Destroy(this);
		}
	}
	#endregion

	
	private void OnDestroy()
	{
		if (SoundEffects.sonido == null)
		{

			SoundEffects.sonido = null;
		}

	}



	public void Timer()
	{
		PlayAudioClip(audioClipTimer);
	}


	public void Explosion()
	{
		PlayAudioClip(audioClipExplosion);
	}


	public void Personaje(string nombre)
	{

		switch (nombre)
		{

			case "Panda":
				{
					PlayAudioClip(audioPanda);
					break;
				}
			case "Fox":
				{
					PlayAudioClip(audioFox);
					break;
				}

		}
	}




	public void PlayAudioClip(AudioClip audioClip)
	{

		audioSource.clip = audioClip;
		audioSource.Play();
	}



}
