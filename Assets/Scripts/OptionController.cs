using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using TMPro;

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
	
	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS



	void Start()
    {
		puntos = 0;
		animales = new List<string>();
		score.text = "Aciertos: " + puntos;

		playerName.text = PlayerPrefs.GetString("NombreJugador");
		escaneados = new Dictionary<string, bool>();
		
	}

	#endregion



	#region PRIVATE_METHOD
	private void UpdateScore() {
	  
		puntos++;
		score.text = "Aciertos: "+ puntos;
	
		
		
	}


	/**
	 * Recibe el nombre del personaje  y 
	 * lo añade de forma aleatoria a cada boton 
	 * para evitar posicionar la opción correcta siempre
	 * el la misma posición
	 */
	private IEnumerator AddOptionName(string nombreAnimal) {
		yield return new WaitForSeconds(0.2f);
		nombreCorrecto = nombreAnimal;
		//Borramos el nombre del personaje de la lista de personajes para evitar
		//inyectarlo en los botones
		if (animales.Contains(nombreAnimal)) animales.Remove(nombreAnimal);

		//Buscamos 3 posiciones aleatorias al tener ya el nombre del target
		int x = Random.Range(0, animales.Count);
		int y = Random.Range(0, animales.Count);
		int z = Random.Range(0, animales.Count);

		//Generamos un número aleatoria para evitar generar siempre la misma opción
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


	private void InitialiOptions() {

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
			animales.Add("dog");
			animales.Add("shark");
			animales.Add("bat");
			animales.Add("hyena");
			animales.Add("pig");
			animales.Add("lemur");
			animales.Add("hawk");
			animales.Add("sloth");
			animales.Add("cat");
			animales.Add("ibex");
			animales.Add("cow");
			animales.Add("frog");
			animales.Add("wolf");
			animales.Add("bear");
		    animales.Add("rabbit");
	}


	/*
	 * Desactivamos un boton regulando su nivel de transparencia
	 * activamos ademas la señal informativa de error y borramos 
	 * las opciones incorrectas
	 */
    private IEnumerator  OffButton(Button button, Image image, Text text){
		
		yield return new WaitForSeconds(0.1f);
	
	     
		Color colorButton = button.GetComponent<Image>().color;
		colorButton.a = (float)0.7;
		button.GetComponent<Image>().color = colorButton;
		button.enabled = false;
		
		 image.gameObject.SetActive(true);
       

		//Desactivamos el texto
         text.enabled = false;

	}

	/*
	 * Activamos los botones deshabilitados
	 *  regulando el valor de su transparencia
	 */

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


	/**
	 * Lanzamos el cartel y reiniciamos el reconocimiento en la nube
	 */
	private IEnumerator  NextCard(){
		yield return new WaitForSeconds(0.5f);
		GameObject reco = GameObject.FindGameObjectWithTag("CloudRecognition");
		reco.GetComponent<SimpleCloudRecoEventHandler>().RestartScannig();
		panel.gameObject.SetActive(true);
		
		
	    
	}

	
	/*
	 * Indica si alguna de las tres opciones son 
	 * validas
	 */

    private bool IsValid(Button button){


		if(button.Equals(button1)){
           return (nombreCorrecto.Equals(nombre1.text))?true:false;
		}else if(button.Equals(button2)){
           return (nombreCorrecto.Equals(nombre2.text))?true:false;
		}else if(button.Equals(button3)){
           return (nombreCorrecto.Equals(nombre3.text))?true:false;
		}
		return false;
	}

	/*
	 * Marca y deshabilita los botones incorrectos y 
	 * deshabilita el boton correcto para evitar sumar puntos
	 */

	private void MarkWrong(Button button){

		if(button.Equals(button1)){
			//Se desactiva el botón de la opción correcta para evitar seguir sumando puntos
			 button1.enabled = false;
		
			//Se llama a la coroutine para deshabilitar los botones incorrecto y activar la señal de opción incorrecta
			 StartCoroutine(OffButton(this.button3, this.fail3,this.nombre3));
			 StartCoroutine(OffButton(this.button2, this.fail2,this.nombre2));
        
		}else if(button.Equals(button2)){
			  button2.enabled = false;
          
			 StartCoroutine(OffButton(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButton(this.button3, this.fail3,this.nombre3));
			
		}else if(button.Equals(button3)){
			 button3.enabled = false;
			 StartCoroutine(OffButton(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButton(this.button2, this.fail2,this.nombre2));
		
	    }
		
	
	}



#endregion


    #region PUBLIC_ METHOD
    public void OnClick (Button button){

		if (IsValid(button))
		{
			
			 EfectosDeSonido._efectosDeSonido.Coin();	
			 UpdateScore();
			 MarkWrong(button);
			 StartCoroutine( NextCard());
		}
		else {
			 EfectosDeSonido._efectosDeSonido.Error();
		     
			 StartCoroutine(OffButton(this.button1, this.fail1,this.nombre1));
			 StartCoroutine(OffButton(this.button2, this.fail2,this.nombre2));
			 StartCoroutine(OffButton(this.button3, this.fail3,this.nombre3));
			 StartCoroutine(NextCard());
			 
		}
	}

	public int getScore()
	{
		return  puntos;
	}

	public int GetPuntos()
	{
		return this.puntos;
	}
	public string GetAnimalName()
	{
		return this.nombreCorrecto;
	}


	/**
	 * Inicializamos los tres botones. Si se escanea la misma carta se
	 * activa un panel para pasar a una siguiente carta.
	 */
	public void InitOptions(string nombreAnimal) {
		
		if(escaneados.ContainsKey(nombreAnimal))
        {
			StartCoroutine(NextCard());

		}
        else
        {
			escaneados.Add(nombreAnimal, true);
			InitialiOptions();

			//Desactivo el panel
			panel.gameObject.SetActive(false);

			//Inicializamos los botones con el nombre de todas las opciones
			StartCoroutine(AddOptionName(nombreAnimal));

			StartCoroutine(OnButtom(this.button3, this.fail3, this.nombre3));
			StartCoroutine(OnButtom(this.button2, this.fail2, this.nombre2));
			StartCoroutine(OnButtom(this.button1, this.fail1, this.nombre1));
		}
			
	}





	#endregion

}
