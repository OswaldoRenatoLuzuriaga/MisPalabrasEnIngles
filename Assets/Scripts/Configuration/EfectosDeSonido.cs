using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	
	public static EfectosDeSonido _efectosDeSonido;

	[Header("Audio source de los efectos de sonido")]
	public AudioSource audioSource;

	[Header("Efectos de sonido")]
	public AudioClip audioTimer;
	public AudioClip audioExplosion;
	public AudioClip audioCoin;
	public AudioClip audioError;
	


	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS
	private void Awake()
	{
		if (EfectosDeSonido._efectosDeSonido == null) {

			EfectosDeSonido._efectosDeSonido = this;
		}else if (EfectosDeSonido._efectosDeSonido != this){

			Destroy(this);
		}
	}
	#endregion

	#region PRIVATE_METHODS
	private void OnDestroy()
	{
		if (EfectosDeSonido._efectosDeSonido == null)
		{

			EfectosDeSonido._efectosDeSonido = null;
		}
		
	}
	#endregion

	#region PUBLIC_METHODS
	public void Timer() {
		PlayAudio(audioTimer);
	}

	public void Coin()
	{
		PlayAudio(audioCoin);
	}

	public void Error()
	{
		PlayAudio(audioError);
	}


	public void Explosion()
	{
		PlayAudio(audioExplosion);
	}



	public void PlayAudio(AudioClip audioClip) {

		audioSource.clip = audioClip;
		audioSource.Play();
	}

	#endregion
}
