using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public static SoundSystem soundEffect;
	public AudioSource audioSource;
	public AudioClip audioTimer;
	public AudioClip audioExplosion;
	public AudioClip audioCoin;
	public AudioClip audioError;
	public AudioClip audioPanda;
	public AudioClip audioFox;


	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS
	private void Awake()
	{
		if (SoundSystem.soundEffect == null) {

			SoundSystem.soundEffect = this;
		}else if (SoundSystem.soundEffect != this){

			Destroy(this);
		}
	}
	#endregion

	#region PRIVATE_METHODS
	private void OnDestroy()
	{
		if (SoundSystem.soundEffect == null)
		{

			SoundSystem.soundEffect = null;
		}
		
	}
	#endregion

	#region PUBLIC_METHODS
	public void Timer() {
		PlayAudioClip(audioTimer);
	}

	public void Coin()
	{
		PlayAudioClip(audioCoin);
	}

	public void Error()
	{
		PlayAudioClip(audioError);
	}


	public void Explosion()
	{
		PlayAudioClip(audioExplosion);
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




	public void PlayAudioClip(AudioClip audioClip) {

		audioSource.clip = audioClip;
		audioSource.Play();
	}

	#endregion
}
