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
			//Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			myPanel.parent = target.transform;
			/*myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
			myModelTrf.localRotation = Quaternion.identity;
			myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
			myModelTrf.gameObject.active = true;*/
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