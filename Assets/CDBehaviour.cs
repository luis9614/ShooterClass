using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDBehaviour : MonoBehaviour
{
    public GameObject Player;
    public string AlbumTitle;

    public bool isGrabbable;

    private Light cdLight;
    private PlayerExtended PlayerCtrl;

    public bool isGrabbed;


    // Control Variables
    float lastStep, timeBetweenSteps = 0.5f;
    void Start()
    {
        cdLight = this.gameObject.GetComponentInChildren<Light>();
        isGrabbable = false;
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        PlayerCtrl = this.Player.GetComponent<PlayerExtended>() as PlayerExtended;
        isGrabbed = false;
        //cdLight.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbed){
            this.enabled = false;
        }
        if(isGrabbable && Input.GetKey(KeyCode.F))
        {
            if(Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                this.gameObject.active = false;
                isGrabbed = true;
                PlayerCtrl.grabCD(this);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            cdLight.enabled = false;
            isGrabbable = true;
            PlayerCtrl.displayMessage("Grab " + AlbumTitle);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            cdLight.enabled = true;
            isGrabbable = false;
            PlayerCtrl.hideMessage();
        }
    }
}
