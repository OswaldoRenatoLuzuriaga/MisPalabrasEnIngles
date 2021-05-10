using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace Tests
{
    public class InfoTestScript
    {



        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("GamePlay");
        }


        [UnityTest]
        public IEnumerator InfoTest()
        {
            GameObject.Find("GestorAyudaTres").GetComponent<InfoPanelController>().SetInformation("Esto es un mensaje de prueba");
            GameObject.Find("GestorAyudaTres").GetComponent<InfoPanelController>().SetCharacterName("wolf");
            GameObject.Find("GestorAyudaTres").GetComponent<InfoPanelController>().OnPanel();
            yield return new WaitForSeconds(1f);
            Assert.AreEqual(GameObject.Find("GestorAyudaTres").GetComponent<InfoPanelController>().infoText.text, "Esto es un mensaje de prueba");

           
        }

    }
}
