using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class BombController: MonoBehaviour
{
	#region PRIVATE_VARIABLES
	

    //Variable de Fuerza de caida
    private float downForce = 20000f;
    private bool useHelp;


    //Componentes de la bomba
    private Animator anim;
    private Rigidbody2D rb2d;
    private Image bombImage;
    #endregion

    #region PUBLIC_VARIABLES
    //Boton de ayuda
    public Image addHelp;
    public Image closeHelp;
	public Button button1;
	public Button button2;
	public Button button3;

	public Text optionText1;
	public Text optionText2;
	public Text optionText3;
	#endregion

	#region UNITY_MONOBEHAVIOUR_METHODS
	private void Awake()
    {
        //Inicializamos las referencias de los componentes
       
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bombImage = GetComponent<Image>();
        useHelp = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Lanzamos la granada, anulando los constrains y estableciendo la velocidad de caida
        if (useHelp)
        {
           
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.down * downForce);
            useHelp = false;

        }
    }
	#endregion

	#region PRIVATE_METHODS
	private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DesactivarBomba());
        anim.SetTrigger("Explosion");
        SoundSystem.sonido.PlayAudioExplosion();
      /*  anim.SetBool("Exit", true);
        SoundSystem.sonido.PlayAudioExplosion();*/
        
        StartCoroutine(FadeButton());

       
    }

    private IEnumerator DesactivarBomba()
	{

        yield return new WaitForSeconds(0.4f);
        Color c = bombImage.color;
        c.a -= 1;
        bombImage.color = c;



    }

    private IEnumerator ActivarBomba()
	{
        yield return new WaitForSeconds(0.1f);
        Color c = bombImage.color;
        c.a += 1;
        bombImage.color = c;

    }

     private IEnumerator FadeButton()
      {


          yield return new WaitForSeconds(0.4f);

          GameObject gestor = GameObject.FindGameObjectWithTag("GestorJuego");
          string nombreCorrecto= gestor.GetComponent<OptionController>().GetNombreAnimal();


          if (nombreCorrecto != null)
          {
			
              if (nombreCorrecto == optionText1.text)
              {
                  button1.gameObject.SetActive(false);
              }
              else if (nombreCorrecto.Equals(optionText2.text))
              {

                  button2.gameObject.SetActive(false);

              }
              else if (nombreCorrecto.Equals(optionText3.text))
              {

                  button3.gameObject.SetActive(false);

              }

          }



      }



    #endregion

    #region PUBLIC_MTHODS


    public void LanzarBomba()
    {
        StartCoroutine(ActivarBomba());
        useHelp = true;
        addHelp.enabled = false;
        closeHelp.enabled = true;
     
        
    }
	#endregion

}
