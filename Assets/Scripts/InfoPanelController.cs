using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using TMPro;

public class InfoPanelController : MonoBehaviour
{
	public Text infoText;
	public UnityEngine.UI.Image infoImage;
	public Button backButton;
	public Button helpButton;
	public Image close;

	private string nameCharacter;
	private string informationCharacter;


	// Start is called before the first frame update
	void Start()
	{
		
		
	}

	public void SetInformation(string info)
	{
		this.informationCharacter = info;
	}

	public void SetCharacterName(string nombreAnimal)
	{
		this.nameCharacter = nombreAnimal;
	}

	private IEnumerator InitPanel(string character)
	{


		yield return new WaitForSeconds(0.5f);

		if (character != null) {
			this.infoText.text = this.informationCharacter;
		}
		



	}

	public void OffPanel()
	{
		infoText.gameObject.SetActive(false);
		infoImage.gameObject.SetActive(false);
		backButton.gameObject.SetActive(false);
		close.gameObject.SetActive(false);
		close.gameObject.SetActive(true);

	}

	public void OnPanel()
	{
		StartCoroutine(InitPanel(nameCharacter));
		
		//SoundSystem.soundEffect.Personaje(nombreAnimal);
		infoText.gameObject.SetActive(true);
		infoImage.gameObject.SetActive(true);
		backButton.gameObject.SetActive(true);
	
		helpButton.enabled = false;

	
	}

}