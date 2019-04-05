using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtended : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Flashlight;

    private bool isLight;

    // Control Variables
    float lastStep, timeBetweenSteps = 0.5f;

    void Start()
    {
        isLight = true;

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
}
