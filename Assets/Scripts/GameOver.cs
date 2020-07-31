using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.CodeDom;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour target;
	public Transform myPanel;


	void Star() {

		target = GetComponent<TrackableBehaviour>();
		if (target)
		{
			target.RegisterTrackableEventHandler(this);
		}
	}



	public void OnTrackableStateChanged(
	TrackableBehaviour.Status previousStatus,
	TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
	}


	private void OnTrackingFound()
	{
		if (myPanel != null)
		{
		
			myPanel.parent = target.transform;
		
		}
	}



	public void Play()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void Menu() {
		SceneManager.LoadScene("Portada");
	}

}