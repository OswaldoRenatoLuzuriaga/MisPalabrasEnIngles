using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PauseTestScript
    {

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("GamePlay");
        }


        [UnityTest]
        public IEnumerator PauseEnabledTest()
        {
            GameObject.Find("PauseCanvas").GetComponent<PauseController>().Pausa();
            Canvas panelPausa = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
            GameObject.Find("PauseCanvas").GetComponent<PauseController>().Play();
            yield return new WaitForSeconds(1f);
            Assert.IsFalse(panelPausa.enabled);
            
        }

      
    }
}
