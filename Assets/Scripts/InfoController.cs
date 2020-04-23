using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class InfoController : MonoBehaviour
{
	public Text infoText;
	public UnityEngine.UI.Image infoImage;
	public Button backButton;

	







	private Dictionary<string, string> infoAnimales;
	private string nombreAnimal;


	// Start is called before the first frame update
	void Start()
	{

		infoAnimales = new Dictionary<string, string>();
		InitAnimales();
		

	}



	public void SetNombreAnimal(string nombreAnimal)
	{
		this.nombreAnimal = nombreAnimal;
	}
	private void InitAnimales()
	{

		infoAnimales.Add("Panda", "A ___ eats bamboo.");
		infoAnimales.Add("Fox", "A ___ has a bushy tail.");

		infoAnimales.Add("Lion", "A ___ can roar.");
		infoAnimales.Add("Duck", "A ___ can quack.");

		infoAnimales.Add("Rabbit", "A ___ can burrow.");
		infoAnimales.Add("Lizard", "A ___ can run.");
	}


	private IEnumerator InitPanel(string nombreAnimal)
	{

		yield return new WaitForSeconds(0.5f);

		if (nombreAnimal != null) {
			if (infoAnimales.TryGetValue(nombreAnimal, out string info))
			{
				infoText.text = info;
				
			}
			else
			{
				infoText.text = "Ninguna información que mostrar";
			}
		}
		



	}

	public void OnDisablePanel()
	{
		infoText.gameObject.SetActive(false);
		infoImage.gameObject.SetActive(false);
		backButton.gameObject.SetActive(false);
	}

	public void OnEnabledPanel()
	{
		StartCoroutine(InitPanel(nombreAnimal));
		
		SoundSystem.soundEffect.Personaje(nombreAnimal);
		infoText.gameObject.SetActive(true);
		infoImage.gameObject.SetActive(true);
		backButton.gameObject.SetActive(true);

	}

}