using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using TMPro;
using Proyecto26;
public class OptionController: MonoBehaviour
{
    #region PUBLIC_VARIABLES
    [Header("Valores de usuario")]
	public TextMeshProUGUI score;
	public TextMeshProUGUI playerName;


	[Header("Botones de opciones")]
	public Button button1;
	public Button button2;
	public Button button3;


	[Header("Nombres")]
	public Text nombre1;
	public Text nombre2;
	public Text nombre3;


	[Header("Errores")]
	public Image fail1;
    public Image fail2;
    public Image fail3;

    public Image panel;
    #endregion


    #region PRIVATE_VARIABLES
    private List<string> animales;
    private int  puntos;
	private string nombreCorrecto = "";
	private Dictionary<string, bool> escaneados;
	private const string URL = "https://animals-c205c.firebaseio.com";
	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS

	private User player;

	void Start()
    {
		puntos = 0;
		animales = new List<string>();
		score.text = "Score: " + puntos;
		///playerName.text = EstadoController.GetNamePlayer();
		playerName.text = PlayerPrefs.GetString("NombreJugador");
		escaneados = new Dictionary<string, bool>();
		
	}

	#endregion



	#region PRIVATE_METHOD
	private void UpdateScore() {
	  
		puntos++;
		score.text = "Score: "+ puntos;
	
		
		
	}


	
	private IEnumerator AddName(string nombreAnimal) {




		yield return new WaitForSeconds(0.2f);

		//Inicializo una lista de animales auxiliar para trabajar con ella
		nombreCorrecto = nombreAnimal;
	

		if (animales.Contains(nombreAnimal)) animales.Remove(nombreAnimal);

		//Buscamos 3 posiciones aleatorias al tener ya el nombre del target
		int x = Random.Range(0, 9);
		int y = Random.Range(0, 9);
		int z = Random.Range(0, 9);


		int pos = Random.Range(1, 4);

		switch (pos)
		{
			case 1:
				nombre1.text = "" + nombreAnimal;
				int noRepetidaY = (y == z) ? Random.Range(0, y) : y;
				nombre2.text = "" + animales[noRepetidaY];
				nombre3.text = "" + animales[z];
				break;
			case 2:
				int noRepetidaZ = (x == z) ? Random.Range(0, z) : z;
				nombre1.text = "" + animales[x];
				nombre2.text = "" + nombreAnimal;
				nombre3.text = "" + animales[noRepetidaZ];
				break;

			case 3:
				int noRepetidaX = (x == y) ? Random.Range(0, x) : x;
				nombre1.text = "" + animales[noRepetidaX];
				nombre2.text = "" + animales[y];
				nombre3.text = "" + nombreAnimal;
				break;


		}
		animales.Clear();

	
	}


	private void Initializename() {

		    animales.Add("panda");
			animales.Add("fox");
			animales.Add("sheep");
			animales.Add("elephant");
			animales.Add("chicken");
			animales.Add("monkey");
			animales.Add("Tiger");
			animales.Add("duck");
			animales.Add("lizard");
			animales.Add("penguin");
			animales.Add("reindeer");
			animales.Add("chimpanzee");
			animales.Add("hermit crab");
			animales.Add("bat");
			animales.Add("hyena");
			animales.Add("pig");
			animales.Add("lemur");
			animales.Add("hawk");
			animales.Add("sloth");
			animales.Add("hippopotamus");


		//yield return new WaitForSeconds(0.1f);


	}



    private IEnumerator  OffButtom(Button button, Image image, Text text){
		
		yield return new WaitForSeconds(0.1f);
	
	     
		Color colorButton = button.GetComponent<Image>().color;
		colorButton.a = (float)0.7;
		button.GetComponent<Image>().color = colorButton;
		button.enabled = false;
		
		 image.gameObject.SetActive(true);
       

		//Desactivamos el texto
         text.enabled = false;

	}



    private IEnumerator OnButtom(Button button, Image image, Text text){
		
	
		
		yield return new WaitForSeconds(0.1f);
		if(!button.enabled){
		Color colorButton = button.GetComponent<Image>().color;
		colorButton.a += (float)0.7;
		button.GetComponent<Image>().color = colorButton;
		button.enabled = true;

		
        image.gameObject.SetActive(false);


        text.enabled = true;
		}
	}


	private IEnumerator  nextCard(){
		yield return new WaitForSeconds(0.5f);
		GameObject reco = GameObject.FindGameObjectWithTag("CloudRecognition");
		reco.GetComponent<SimpleCloudRecoEventHandler>().RestartScannig();
		panel.gameObject.SetActive(true);
		
		
	    
	}

	private void esactivarPanel(){
//        nextCard.gameObject.SetActive(false);
	     panel.gameObject.SetActive(false);
		
	}


    private bool IsSuccess(Button button){


		if(button.Equals(button1)){
           return (nombreCorrecto.Equals(nombre1.text))?true:false;
		}else if(button.Equals(button2)){
           return (nombreCorrecto.Equals(nombre2.text))?true:false;
		}else if(button.Equals(button3)){
           return (nombreCorrecto.Equals(nombre3.text))?true:false;
		}
		return false;
	}


	private void MarkWrong(Button button){

		if(button.Equals(button1)){
			 button1.enabled = false;
		
			 StartCoroutine(OffButtom(this.button3, this.fail3,this.nombre3));
			 StartCoroutine(OffButtom(this.button2, this.fail2,this.nombre2));
        
		}else if(button.Equals(button2)){
			  button2.enabled = false;
          
			 StartCoroutine(OffButtom(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButtom(this.button3, this.fail3,this.nombre3));
			
		}else if(button.Equals(button3)){
			 button3.enabled = false;
			 StartCoroutine(OffButtom(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButtom(this.button2, this.fail2,this.nombre2));
		
	    }
		
	
	}



#endregion


    #region PUBLIC_ METHOD
    public void OnClick (Button button){

		if (IsSuccess(button))
		{
			
			 EfectosDeSonido._efectosDeSonido.Coin();	
			 UpdateScore();
			 MarkWrong(button);
			 StartCoroutine( nextCard());
		
			
		}
		else {
			 EfectosDeSonido._efectosDeSonido.Error();
		     
			 StartCoroutine(OffButtom(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButtom(this.button2, this.fail2,this.nombre2));
			 StartCoroutine(OffButtom(this.button3, this.fail3,this.nombre3));
			 StartCoroutine(nextCard());
			 
		}
	}

	public string getScore()
	{
		return "Score: " + puntos;
	}

	public int GetPuntos()
	{
		return this.puntos;
	}
	public string GetAnimalName()
	{
		return this.nombreCorrecto;
	}


	//Inicializamos los butones que esten desactivados

	public void InitButtom(string nombreAnimal) {
		
		if(escaneados.ContainsKey(nombreAnimal))
        {
			StartCoroutine(nextCard());

		}
        else
        {
			escaneados.Add(nombreAnimal, true);
		    Initializename();
			//Desactivo el panel
			panel.gameObject.SetActive(false);
			StartCoroutine(AddName(nombreAnimal));
			StartCoroutine(OnButtom(this.button3, this.fail3, this.nombre3));
			StartCoroutine(OnButtom(this.button2, this.fail2, this.nombre2));
			StartCoroutine(OnButtom(this.button1, this.fail1, this.nombre1));
		}
			
	}





	#endregion

}
