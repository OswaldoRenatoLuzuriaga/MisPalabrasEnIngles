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
	//public UnityEngine.UI.Image infoImage;
	//public Button backButton;
	public Button helpButton;
	public Image close;

	public GameObject panelInfo;
	
	private string nameCharacter;
	


	// Start is called before the first frame update
	void Start()
	{
		panelInfo.SetActive(false);
	}


  


    public void SetInformation(string info)
	{
		//this.informationCharacter = info;
	}

	public void SetCharacterName(string nombreAnimal)
	{
		this.nameCharacter = nombreAnimal;
	}

	private void InitPanel(string character)
	{



		Debug.Log(PlayerPrefs.GetString("descripcionPersonaje"));
		if (character != null) {
			infoText.text = PlayerPrefs.GetString("descripcionPersonaje");
        }
        else
        {
			infoText.text = "Acerca el teléfono a tu carta";
        }
	
	}

	public void OffPanel()
	{
	
		
		panelInfo.SetActive(false);
		close.gameObject.SetActive(false);
		close.gameObject.SetActive(true);
	}

	public void OnPanel()
	{
		//StartCoroutine(InitPanel(nameCharacter));

		
		panelInfo.SetActive(true);

		if (PlayerPrefs.GetString("nombrePersonaje") != null)
		{
			infoText.text = PlayerPrefs.GetString("descripcionPersonaje");
		}
		else
		{
			infoText.text = "Acerca el teléfono a tu carta";
		}

		//InitPanel(PlayerPrefs.GetString("nombrePersonaje"));
		//SoundSystem.soundEffect.Personaje(nombreAnimal);
		/*infoText.gameObject.SetActive(true);
		infoImage.gameObject.SetActive(true);
		backButton.gameObject.SetActive(true);*/

		helpButton.enabled = false;
		
	
	}

}