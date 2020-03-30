using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public static SoundSystem sonido;
	public AudioSource audioSource;
	public AudioClip audioClipTimer;
	public AudioClip audioClipExplosion;
	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS
	private void Awake()
	{
		if (SoundSystem.sonido == null) {

			SoundSystem.sonido = this;
		}else if (SoundSystem.sonido != this){

			Destroy(this);
		}
	}
	#endregion

	#region PRIVATE_METHODS
	private void OnDestroy()
	{
		if (SoundSystem.sonido == null)
		{

			SoundSystem.sonido = null;
		}
		
	}
	#endregion

	#region PUBLIC_METHODS
	public void PlayAudioTimer() {
		PlayAudioClip(audioClipTimer);
	}


	public void PlayAudioExplosion()
	{
		PlayAudioClip(audioClipExplosion);
	}


	public void PlayAudioClip(AudioClip audioClip) {

		audioSource.clip = audioClip;
		audioSource.Play();
	}

	#endregion
}
