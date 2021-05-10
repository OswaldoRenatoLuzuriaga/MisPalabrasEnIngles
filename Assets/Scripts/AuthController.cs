
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Text;

public class AuthController : MonoBehaviour
{
    [Header("Escena")]
    public string escena;
    public Image infoPanel;

    //Login variables
    [Header("Login")]
    public GameObject panelLogin;
    public TMP_InputField emailLogin;
    public TMP_InputField passLogin;

    //Register variables
    [Header("Register")]
    public GameObject panelRegister;
    public TMP_InputField userRegister;
    public TMP_InputField emailRegister;
    public TMP_InputField passRegister;
    public Text textError;

    //Firebase variables
    [Header("Firebase")]
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    public DependencyStatus dependencyStatus;

    [Header("Error Panel")]
 
    public User player;
    private const string URL = "https://animals-c205c.firebaseio.com/";

    [Header("URL ayuda")]
    public string url;

    // Start is called before the first frame update
    void Start()
    {
        panelLogin.SetActive(false);
        panelRegister.SetActive(false);
        
        this.player = new User();



    }

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
       {
           dependencyStatus = task.Result;
           if (dependencyStatus == DependencyStatus.Available)
           {
               auth = FirebaseAuth.DefaultInstance;
           }
           else
           {
               Debug.LogError("Could not resolve all dependecies: " + dependencyStatus);
           }
       });


    }


    public void RegisterButton()
    {

        StartCoroutine(Register(emailRegister.text, passRegister.text, userRegister.text));



    }

    
    public string IsLogin()
    {
        return (this.player._name != null) ? this.player._name: "esta vacio";
    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLogin.text, passLogin.text));

    }


    public void LoginButtonFake(string email, string password)
    {
        StartCoroutine(Login(email, password));
    }

    private IEnumerator Login(string email, string password)
    {

        if ( email == "" || password == "")
        {
           
            this.textError.text = "Todos los campos tienen que estar completos";
        }
        else
        {
            this.textError.text = "";


            var registerTask = auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    //Cancelamos la operación registro
                    return;
                }
                if (task.IsFaulted)
                {

                    //Devuelve un excepción si algunos de los campos no estan completos o hay un error en los mismos
                   
                    return;
                }
                
                
                
                user = task.Result;
               
            });
         
           
            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);
            
                this.textError.text = "";
               
            if (user != null)
             {
               StartCoroutine(GetUser());
            }else
            {
                this.textError.text = "¡Error en el campo usuario y/o contraseña, revisalos!";
            }

            


        }
    }

    IEnumerator GetUser()
    {
        infoPanel.gameObject.SetActive(true);
        using (UnityWebRequest www = UnityWebRequest.Get(URL + "/users/" + user.UserId + ".json"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                this.textError.text = "Error al descargar el usuario";
            }
            else
            {
             
                //Obtebemos los resultados
                byte[] results = www.downloadHandler.data;
                //Lo convertimos a un string
                string playerJson = Encoding.Default.GetString(results);
                
                
                //Deserealizamos el json descargado
                User player = JsonUtility.FromJson<User>(playerJson);

               

                SaveStateGame(player);
                infoPanel.gameObject.SetActive(false);

            }
        }
    }

    private void SaveStateGame(User player)
    {

        
        PlayerPrefs.SetString("ScoreJugador", player._score);
        PlayerPrefs.SetString("NombreJugador", player._name);
        PlayerPrefs.SetString("RecordTotal", player._record);
        PlayerPrefs.SetString("Id_Player", player._id);
        PlayerPrefs.SetString("email", player._email);
        Jugar();
       
    }

  
    public IEnumerator Register(string email, string password, string userName)
    {


        if(userName == "" || email == "" || password == "")
        {
            this.textError.text = "Todos los campos tienen que estar completos";
        }
        else
        {

            this.textError.text = "";

            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    return;
                }
                if (task.IsFaulted)
                {
                    return;
                }
                user = task.Result;
            });

         
            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

            if(user!= null)
            {

                this.textError.text = "";
                User newUser = new User(user.UserId, userName, email, "0", "0");

                //Guardamos el estado del juego
                PlayerPrefs.SetString("ScoreJugador", "0");
                PlayerPrefs.SetString("NombreJugador", userName);
                PlayerPrefs.SetString("RecordTotal", "0");
                PlayerPrefs.SetString("Id_Player", player._id);
                /* EstadoController.SetScore("0");
                 EstadoController.SetNamePlayer(userName);
                 EstadoController.SetRecord("0");*/
                //Guardamos en la BBDD
                StartCoroutine(Save(user.UserId, newUser));
                this.textError.text = "Usuario creado correctamente";
                Jugar();
            }
            else
            {
                this.textError.text = "¡Error en el campo usuario y/o contraseña, revisalos!";
            }

        }


    }


    public void Jugar()
    {

        SceneManager.LoadScene(escena);
    }

    IEnumerator Save(string userId, User newUser)
    {
        string json = JsonUtility.ToJson(newUser);
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
        using (UnityWebRequest www = UnityWebRequest.Put(URL + "/users/" + userId + ".json", myData))
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                this.textError.text = "Usuario registrado correctamente";
                
            }
            else
            {
                this.textError.text = "Error al registrar el usuario";
            }
        }
    }

   public void onPanelLogin()
    {
        panelLogin.SetActive(true);
    }


    public void onPanelRegister()
    {
        panelRegister.SetActive(true);
    }



    public void onBack()
    {
        this.textError.text = "";
        if (panelLogin.activeSelf == true)
        {
            panelLogin.SetActive(false);
           
        }
        else if(panelRegister.activeSelf == true)
        {
            panelRegister.SetActive(false);
            
        }
    }




  

    public void IrGuiaDeUsuario()

    {
        Application.OpenURL(url);
    }

}
