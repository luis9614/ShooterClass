using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExtended : MonoBehaviour
{
    // Utils
    public Text MessageDisplay;
    public Text CountDisplay;
    // Start is called before the first frame update

    public GameObject Flashlight;

    public Camera MainCamera;
    public Camera AyuwokiCam;

    public bool isLight;

    public int grabbedCDs = 0;
    public int totalCDs = 4;

    // State
    public List<CDBehaviour> collected;
    [SerializeField]
    public Transform AyuwokiPos;

    // Control Variables
    float lastStep, timeBetweenSteps = 0.5f;

    void Start()
    {
        if(GameData.isNewGame){
            isLight = true;
            collected = new List<CDBehaviour>();
            grabbedCDs = 0;
        }else{
            collected = GameData.CollectedCDs;
            grabbedCDs = GameData.grabbedCDs;
        }
        
        
        MainCamera.enabled = true;
        AyuwokiCam.enabled = false;
        totalCDs = GameData.totalCDs;
        UpdateGrabbedCDs();

    }

    // Update is called once per frame
    void Update()
    {
        if(grabbedCDs == totalCDs){
            WinGame();
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                switchLight();
            }
            
        }
    }

    private void switchLight()
    {
        isLight = !isLight;
        if (isLight)
        {
            Flashlight.SetActive(true);
        }
        else
        {
            Flashlight.SetActive(false);
        }
    }

    public void WinGame(){

    }

    public void displayMessage(string msg)
    {
        MessageDisplay.text = msg;
        //MessageDisplay.SetActive(true);
    }

    public void hideMessage()
    {
        MessageDisplay.text = "";
    }
    private void UpdateGrabbedCDs(){
        CountDisplay.text = "Found " + grabbedCDs.ToString() + "/" + totalCDs.ToString() + " CD's";
    }
    private void UpdateGameData(){
        GameData.AyuwokiPosition = AyuwokiPos.position;
        GameData.CollectedCDs = collected;
        GameData.grabbedCDs = grabbedCDs;
    }
    public void grabCD(CDBehaviour cd)
    {
        this.collected.Add(cd);
        grabbedCDs++;
        UpdateGrabbedCDs();
        hideMessage();
        // save
        UpdateGameData();
        Debug.Log("Ayuwoki Pos: " + GameData.AyuwokiPosition.ToString());
        Debug.Log("Collected CDS: " + GameData.CollectedCDs.Count.ToString());
    }

    public void EndGame()
    {
        //this.transform.LookAt(AyuwokiPos);
        MainCamera.enabled = false;
        AyuwokiCam.enabled = true;
    }
}
