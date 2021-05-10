using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using TMPro;

namespace Tests
{
    public class AuthTestScript
    {
        public TMP_InputField emailLogin;
        public TMP_InputField passLogin;




        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Login");
        }




        [UnityTest]
        public IEnumerator onLoginPanel()
        {

           
            GameObject.Find("AuthSystem").GetComponent<AuthController>().onPanelLogin();
            yield return new WaitForSeconds(1f);
            bool panel = GameObject.Find("AuthSystem").GetComponent<AuthController>().panelLogin.active;
            Assert.IsTrue(panel);
        }



        [UnityTest]
        public IEnumerator onRegisterPanel()
        {

      
            GameObject.Find("AuthSystem").GetComponent<AuthController>().onPanelRegister();
            yield return new WaitForSeconds(1f);
            bool panel = GameObject.Find("AuthSystem").GetComponent<AuthController>().panelRegister.active;
            Assert.IsTrue(panel);
        }


            





        
        [UnityTest]
        public IEnumerator Login()
        {


            GameObject.Find("AuthSystem").GetComponent<AuthController>().LoginButton();
            GameObject.Find("AuthSystem").GetComponent<AuthController>().emailLogin.text = "renato@hotmail.com";
            GameObject.Find("AuthSystem").GetComponent<AuthController>().passLogin.text = "12345678";
            yield return new WaitForSeconds(5f);

            Assert.IsNotNull(GameObject.Find("AuthSystem").GetComponent<AuthController>().player);
        }




        [UnityTest]
        public IEnumerator Register()
        {


            GameObject.Find("AuthSystem").GetComponent<AuthController>().RegisterButton();
            GameObject.Find("AuthSystem").GetComponent<AuthController>().userRegister.text = "test";
            GameObject.Find("AuthSystem").GetComponent<AuthController>().emailRegister.text = "test@hotmail.com";
            GameObject.Find("AuthSystem").GetComponent<AuthController>().passRegister.text = "12345678";
            yield return new WaitForSeconds(5f);

            Assert.IsNotNull(GameObject.Find("AuthSystem").GetComponent<AuthController>().player);
        }
    }
}
