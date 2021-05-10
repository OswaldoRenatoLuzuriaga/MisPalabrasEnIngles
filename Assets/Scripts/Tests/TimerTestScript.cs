using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace Tests
{
    public class TimerTestScript
    {



        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("GamePlay");
        }

       
     
        [UnityTest]
        public IEnumerator TimerAddTest()
        {
           
         
            yield return new WaitForSeconds(30f);
            GameObject.Find("TimerPanel").GetComponent<TimerController>().AddTiempo();
            float timerNew = GameObject.Find("TimerPanel").GetComponent<TimerController>().timer;
            Assert.LessOrEqual(timerNew,120f);
        }

        [UnityTest]
        public IEnumerator GameOver()
        {
     
            GameObject.Find("TimerPanel").GetComponent<TimerController>().GameOver();
            GameObject.Find("TimerPanel").GetComponent<TimerController>().score.text = "Aciertos: " + 7;
            GameObject.Find("TimerPanel").GetComponent<TimerController>().scoreTotal.text = "Récord de aciertos: " + + 7;
            yield return new WaitForSeconds(10f);
            Assert.IsTrue(GameObject.Find("TimerPanel").GetComponent<TimerController>().canvas.enabled);
        }
    }
}
