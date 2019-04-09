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
    // Start is called before the first frame update

    public GameObject Flashlight;

    private bool isLight;

    // State
    public List<CDBehaviour> collected;
    [SerializeField]
    public Transform AyuwokiPos;

    // Control Variables
    float lastStep, timeBetweenSteps = 0.5f;

    void Start()
    {
        isLight = true;
        collected = new List<CDBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                //Do step
                Debug.Log("Switched");
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

    public void displayMessage(string msg)
    {
        MessageDisplay.text = msg;
        //MessageDisplay.SetActive(true);
    }

    public void hideMessage()
    {
        MessageDisplay.text = "";
    }

    public void grabCD(CDBehaviour cd)
    {
        this.collected.Add(cd);
        // save
        SaveGame();
    }

    // Methods for Loading and saving game


    public void SaveGame()
    {
        GameData.AyuwokiPosition = AyuwokiPos.position;
        GameData.CollectedCDs = collected;
    }
}
