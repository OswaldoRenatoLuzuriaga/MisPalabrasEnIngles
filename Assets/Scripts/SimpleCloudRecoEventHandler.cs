using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;
using UnityEngine.UI;

public class SimpleCloudRecoEventHandler : MonoBehaviour, IObjectRecoEventHandler
{
    private CloudRecoBehaviour mCloudRecoBehaviour;
    private bool mIsScanning = false;
    private string mTargetMetadata = "";

  

   

    [Header("ImageTarget")]
    public ImageTargetBehaviour chickenTarget;
    public ImageTargetBehaviour crocodileTarget;
    public ImageTargetBehaviour rabbitTarget;
    public ImageTargetBehaviour wolfTarget;
    public ImageTargetBehaviour cowTarget;
    public ImageTargetBehaviour bearTarget;
    public ImageTargetBehaviour sharkTarget;
    public ImageTargetBehaviour frogTarget;
    public ImageTargetBehaviour ibexTarget;
    public ImageTargetBehaviour buterflyTarget;

    private ObjectTracker mImageTracker;
  

   // public Transform positionTarget;






    void Start()
    {
       

        // register this event handler at the cloud reco behaviour
        mCloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();

        if (mCloudRecoBehaviour)
        {
            mCloudRecoBehaviour.RegisterEventHandler(this);
        }
    }

    public void OnInitialized(TargetFinder targetFinder)
    {
        // get a reference to the Image Tracker, remember it
        mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();
    }
    public void OnInitError(TargetFinder.InitState initError)
    {
        Debug.Log("Cloud Reco init error " + initError.ToString());
    }
    public void OnUpdateError(TargetFinder.UpdateState updateError)
    {
        if (GUI.Button(new Rect(500, 300, 200, 50), "Prueba con otra carta"))
        {
            // Restart TargetFinder
            mCloudRecoBehaviour.CloudRecoEnabled = true;
        }
    }



    public void OnStateChanged(bool scanning)
    {

        mIsScanning = scanning;
        if (scanning)
        {
            var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);
        }
    }


    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
     
        TargetFinder.CloudRecoSearchResult cloudRecoSearchResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;
    
        mTargetMetadata = cloudRecoSearchResult.MetaData;
       


        //Inicializamos las opciones de los botones
        GameObject panelDeOpciones = GameObject.FindGameObjectWithTag("GestorPreguntas");
        panelDeOpciones.GetComponent<OptionController>().InitOptions(cloudRecoSearchResult.TargetName);

        //Paso la información al panel informativo
        GameObject informationPanel = GameObject.FindGameObjectWithTag("GestorAyudaTres");
        informationPanel.GetComponent<InfoPanelController>().SetCharacterName(cloudRecoSearchResult.TargetName);
        informationPanel.GetComponent<InfoPanelController>().SetInformation(mTargetMetadata);

      

        switch (cloudRecoSearchResult.TargetName)
        {

            case "chicken":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, chickenTarget.gameObject);

                    break;
                }
            case "crocodile":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, crocodileTarget.gameObject);
                    ;
                    break;
                }
            case "cow":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, cowTarget.gameObject);

                    break;
                }
            case "rabbit":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, rabbitTarget.gameObject);

                    break;
                }
            case "butterfly":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, buterflyTarget.gameObject);
                    break;
                }
            case "shark":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, sharkTarget.gameObject);
                    break;
                }
            case "bear":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, bearTarget.gameObject);
                    break;
                }

            case "ibex":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, ibexTarget.gameObject);
                    break;
                }
            case "frog":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, frogTarget.gameObject);
                    break;
                }
            case "wolf":
                {
                    ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                    tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, wolfTarget.gameObject);
                    break;
                }
        }
         if (!mIsScanning)
         {
            mCloudRecoBehaviour.CloudRecoEnabled = true;
         }
        else
        {
            mCloudRecoBehaviour.CloudRecoEnabled = false;
        }
        

    }


   
    public void RestartScannig()
    {
        ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables();
        mCloudRecoBehaviour.CloudRecoEnabled = true;
    }





}
