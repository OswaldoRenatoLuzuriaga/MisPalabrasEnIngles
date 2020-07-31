using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using TMPro;
public class OptionController: MonoBehaviour
{
	
	public TextMeshProUGUI score;

	public  Button button1;
	public  Button button2;
	public Button button3;

	public Text nombre1;
	public Text nombre2;
	public Text nombre3;

    public Image fail1;
    public Image fail2;
    public Image fail3;

	private List<string> animales;
    private int  puntos;
	private string nombreCorrecto = "";


	#region UNITY_MONOBEHAVIOUR_METHODS



	void Start()
    {
		puntos = 0;
		animales = new List<string>();
	
	}

	#endregion


	private void ActualizaPuntos() {
	  
		puntos++;
		score.text = "Score: "+ puntos;
    }


	public string GetNombreAnimal()
	{
		return this.nombreCorrecto;
	}


	private IEnumerator AddNombre(string nombreAnimal) {




		yield return new WaitForSeconds(0.2f);

		//Inicializo una lista de animales auxiliar para trabajar con ella
		nombreCorrecto = nombreAnimal;
	

		if (animales.Contains(nombreAnimal)) animales.Remove(nombreAnimal);

		//Buscamos 3 posiciones aleatorias al tener ya en nombre del target
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


	private void InicializarNombres() {

		    animales.Add("Panda");
			animales.Add("Fox");
			animales.Add("Sheep");
			animales.Add("Elephant");
			animales.Add("Chicken");
			animales.Add("Monkey");
			animales.Add("Tiger");
			animales.Add("Duckling");
			animales.Add("Lizard");
			animales.Add("Penguin");


		//yield return new WaitForSeconds(0.1f);


	}


    private  void Activar(Button button, Image image ){
		//Desactivamos el button
		Color colorButton = button.GetComponent<Image>().color;
        colorButton.a += 1;
		
        button.GetComponent<Image>().color = colorButton;
        button.enabled = true;

		//Desactivamos la imagen de error

		Color colorImage = image.color;
        colorImage.a -= 1;
        image.color = colorImage;
	}




    private  void Desactivar(Button button, Image image, Text text){
		//Desactivamos el button
	
		
		if(button.enabled){
		Color colorButton = button.GetComponent<Image>().color;
		colorButton.a -= (float)0.7;
		button.GetComponent<Image>().color = colorButton;
		button.enabled = false;
		}

		//Activamos la imagen de error

		Color colorImage = image.color;
        colorImage.a += 1;
        image.color = colorImage;

		//Desactivamos el texto
         text.enabled = false;

	}





    private bool isSuccess(Button button){

     
		if(button.Equals(button1)){
           return (nombreCorrecto.Equals(nombre1.text))?true:false;
		}else if(button.Equals(button2)){
           return (nombreCorrecto.Equals(nombre2.text))?true:false;
		}else if(button.Equals(button3)){
           return (nombreCorrecto.Equals(nombre3.text))?true:false;
		}
		return false;
	}

	private void failure(){
		 SoundSystem.soundEffect.Error();
		 Desactivar(this.button3, this.fail3,this.nombre3);
		 Desactivar(this.button2, this.fail2,this.nombre2);
		 Desactivar(this.button1, this.fail1,this.nombre1);
		 /*
		if(button.Equals(button1)){
            Desactivar(this.button3, this.fail3,this.nombre3);
			Desactivar(this.button2, this.fail2,this.nombre2);
		}else if(button.Equals(button2)){
             Desactivar(this.button3, this.fail3,this.nombre3);
		     Desactivar(this.button1, this.fail1,this.nombre1);
		}else if(button.Equals(button3)){
            Desactivar(this.button2, this.fail2,this.nombre2);
		    Desactivar(this.button1, this.fail1,this.nombre1);
		}*/
	}


	public void onClick (Button button){

		if (isSuccess(button))
		{
			ActualizaPuntos();
			SoundSystem.soundEffect.Coin();	
		}
		else {
			failure();
		}
	}




	//Inicializamos los butones que esten desactivados
	#region PUBLIC_ METHOD
	public void InitBotones(string nombreAnimal) {
		InicializarNombres();
		StartCoroutine(AddNombre(nombreAnimal));

	    
	/*
		if (!button1.gameObject.activeInHierarchy)
		{
			button1.gameObject.SetActive(true);
		}
		if (!button2.gameObject.activeInHierarchy)
		{
			button2.gameObject.SetActive(true);
		}
	    if (!button3.gameObject.activeInHierarchy)
		{
			button3.gameObject.SetActive(true);
		}*/

		

		
	}




		#endregion

	}
