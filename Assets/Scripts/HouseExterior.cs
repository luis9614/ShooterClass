using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseExterior : MonoBehaviour
{
    public int IndexScene;
    public string verb;
    public Text MessageDisplay;

    // bEHAVIOUR vARIABLE
    bool isInTriggerZone = false;
    // Control Variables
    float lastStep = 0.0f, timeBetweenSteps = 0.5f;
    
    void Start()
    {
        displayMessage("");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTriggerZone)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    SceneManager.LoadScene(IndexScene);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        displayMessage("Press Q to " + verb);
        isInTriggerZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInTriggerZone = false;
        hideMessage();
    }
    void displayMessage(string msg)
    {
        MessageDisplay.text = msg;
        //MessageDisplay.SetActive(true);
    }

    void hideMessage()
    {
        MessageDisplay.text = "";
    }
}
