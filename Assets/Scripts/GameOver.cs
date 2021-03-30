
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Net.Http;

using System.Collections;

using UnityEngine.UI;
using System.Threading;
using System.IO;
using TMPro;
using Proyecto26;
public class GameOver : MonoBehaviour
{
	
	public TextMeshProUGUI score;
	//public TextMeshProUGUI record;
	private HttpClient _httpClient;


	public void Star() {

	    _httpClient = new HttpClient();
	
	
		Debug.Log("El estado final es:-> " + EstadoController.GetScore());
		this.score.text = EstadoController.GetScore();
		/*if(this.record.text != this.score.text)
        {
			this.record.text = EstadoController.GetRecord();
        }
        else
        {
			this.record.text = EstadoController.GetScore();
		}*/
	
	}

	
	private async void GetUser()
    {
	  var httpResponse = await _httpClient.GetAsync("https://animals-c205c.firebaseio.com/users/3QhZJ7YGe9dubbSjBSoYnS7BINn1.json");

		if(httpResponse.IsSuccessStatusCode)
        {
			var content = await httpResponse.Content.ReadAsStringAsync();
			User user = JsonUtility.FromJson<User>(content);
			Debug.Log(user);
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