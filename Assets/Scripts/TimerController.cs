using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Text contador;
    private Text gameOver;
    public static float tiempoActual;
    public Image healthBar;
    public Button ayuda1;

  
    public Image helpAdd;
    public Image helpClose;
    private Animator anim;
    #endregion


    #region PRIVATE_VARIABLES
    private float timeMax = 30f;
    private bool isButtonHelp;
    
    #endregion


    #region UNITY_MONOBEHAVIOUR_METHODS
    // Start is called before the first frame update
    void Start()
    {
	    contador.text = " " + timeMax;
       // gameOver.enabled = false;
        isButtonHelp = false;
        tiempoActual = 0;
        ActualizarTiempo();
        //ayuda1.gameObject.SetActive(true);

    }
	

	// Update is called once per frame
	void Update()
    {
        //Actualizamos el tiempo
        timeMax -= Time.deltaTime;
        contador.text = " " + timeMax.ToString("f0");
        
        //Actualizamos la barra de salud
        tiempoActual += Time.deltaTime/ 30;
        ActualizarTiempo();

        if (timeMax < 0) {
            contador.text = ""+ 0;
           // gameOver.enabled = true;
        }


       /* if (timeMax <= 10)
        {
            anim.SetTrigger("Vibrar");
        }*/

        StartCoroutine(DisableButton());
     
    }
    #endregion


    #region PRIVATE_METHODS
    private void ActualizarTiempo()
    {
        healthBar.fillAmount = tiempoActual;
    }
    #endregion

    private IEnumerator DisableButton() {

        yield return new WaitForSeconds(0.1f);

        //Desabilitamos el boton de ayuda si este ya ha sido usado
        if (isButtonHelp)
        {
            helpAdd.enabled = false;
            helpClose.enabled = true;
        }

    }
	#region PUBLIC_METHODS
	public void AddTiempo() {

        if (this.timeMax <= 20 && !isButtonHelp)
        {
            this.timeMax += 5f;
            isButtonHelp = true;
            tiempoActual -= 0.16f;
            ActualizarTiempo();
        }
      
       
    }


	#endregion


}
