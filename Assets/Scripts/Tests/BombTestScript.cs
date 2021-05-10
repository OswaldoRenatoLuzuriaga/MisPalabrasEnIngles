using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace Tests
{
    public class BombTestScript
    {

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("GamePlay");
        }




        [UnityTest]
        public IEnumerator FadeButton1()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button1;
            string opcionButton = GameObject.Find("BombImage").GetComponent<BombController>().optionText1.text;
            GameObject.Find("BombImage").GetComponent<BombController>().LanzarBomba();
            yield return new WaitForSeconds(1f);

            /*
            * Si la opción correcta no esta el boton uno, se comprueba que la imagen de error se muestre
            * y que el botón este desactivado
            */

            if (!opcionButton.Equals("wolf"))
            {
                //Imagen de error se muestra
                Assert.IsTrue(GameObject.Find("BombImage").GetComponent<BombController>().fail1.enabled);
                //Boton se desactiva
                Assert.IsTrue(button.enabled);
            }
            else
            {
                //Imagen de error no se muestra
                Assert.IsFalse(GameObject.Find("BombImage").GetComponent<BombController>().fail1.enabled);
                //Boton sigues activado
                Assert.IsFalse(button.enabled);
            }
        }



        [UnityTest]
        public IEnumerator FadeButton2()
        {
            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            string opcionButton = GameObject.Find("BombImage").GetComponent<BombController>().optionText2.text;
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button2;

            GameObject.Find("BombImage").GetComponent<BombController>().LanzarBomba();
            yield return new WaitForSeconds(1f);

            /*
             * Si la opción correcta no esta el boton dos, se comprueba que la imagen de error se muestre
             * y que el botón este desactivado
             */

            if (!opcionButton.Equals("wolf"))
            {
                //Imagen de error se muestra
                Assert.IsTrue(GameObject.Find("BombImage").GetComponent<BombController>().fail2.enabled);
                //Boton se desactiva
                Assert.IsTrue(button.enabled);
            }
            else
            {
                //Imagen de error no se muestra
                Assert.IsFalse(GameObject.Find("BombImage").GetComponent<BombController>().fail2.enabled);
                //Boton sigues activado
                Assert.IsFalse(button.enabled);
            }




        }

        [UnityTest]
        public IEnumerator FadeButton3()
        {

            GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().InitOptions("wolf");
            string opcionButton = GameObject.Find("BombImage").GetComponent<BombController>().optionText3.text;
            Button button = GameObject.Find("GestorDePreguntas").GetComponent<OptionController>().button3;

            GameObject.Find("BombImage").GetComponent<BombController>().LanzarBomba();
            yield return new WaitForSeconds(1f);

            /*
             * Si la opción correcta no esta el boton tres, se comprueba que la imagen de error se muestre
             * y que el botón este desactivado
             */

            if (!opcionButton.Equals("wolf"))
            {
                //Imagen de error se muestra
                Assert.IsTrue(GameObject.Find("BombImage").GetComponent<BombController>().fail3.enabled);
                //Boton se desactiva
                Assert.IsTrue(button.enabled);
            }
            else
            {
                //Imagen de error no se muestra
                Assert.IsFalse(GameObject.Find("BombImage").GetComponent<BombController>().fail3.enabled);
                //Boton sigues activado
                Assert.IsFalse(button.enabled);
            }



        }


    }
}
