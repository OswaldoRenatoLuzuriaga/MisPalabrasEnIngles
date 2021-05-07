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
	public Button helpButton;
	public Image close;
	public GameObject panelInfo;
	
	private string nameCharacter;
	private string informationCharacter;


	// Start is called before the first frame update
	void Start()
	{
		panelInfo.SetActive(false);
		this.nameCharacter = "";
		this.informationCharacter = "";
	}


  


    public void SetInformation(string info)
	{
		this.informationCharacter = info;
	}

	public void SetCharacterName(string _nameCharacter)
	{
		this.nameCharacter = _nameCharacter;
	}



	public void OffPanel()
	{	
		panelInfo.SetActive(false);
		close.gameObject.SetActive(false);
		close.gameObject.SetActive(true);
	}

	public void OnPanel()
	{
		
		panelInfo.SetActive(true);

		if (this.nameCharacter != null)
		{
			infoText.text = this.informationCharacter;
		}
		else
		{
			infoText.text = "Carta no escaneada, Acerca el teléfono a tu carta";
		}
		helpButton.enabled = false;	
	
	}

}