using System.Collections;

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Tests
{
    public class OptionTestScript
    {
        private Button button;


        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("GamePlay");
        }

       
        [UnityTest]
        public IEnumerator InitBotonTest()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            string boton1 = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().nombre1.text;
            string boton2 = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().nombre2.text;
            string boton3 = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().nombre3.text;
            yield return new WaitForSeconds(1f);

            Assert.IsNotNull(boton1);
            Assert.IsNotNull(boton2);
            Assert.IsNotNull(boton3);
        }



        [UnityTest]
        public IEnumerator ClickBoton1Test()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button1;
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().OnClick(button);
            
            yield return new WaitForSeconds(5f);

            Assert.IsTrue(GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().panel.enabled);
        }

        [UnityTest]
        public IEnumerator ClickBoton2Test()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button2;
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().OnClick(button);

            yield return new WaitForSeconds(10f);

            Assert.IsTrue(GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().panel.enabled);
        }



        [UnityTest]
        public IEnumerator ClickBoton3Test()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button3;
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().OnClick(button);

            yield return new WaitForSeconds(10f);

            Assert.IsTrue(GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().panel.enabled);
        }

    }
}
