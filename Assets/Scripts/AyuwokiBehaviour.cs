using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AyuwokiBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float Speed;

    private Animator AnimatorManager;
    private NavMeshAgent NavMeshAgent;

    private AudioSource _source;

    public float MinDistance;
    public float MaxDistance;

    private PlayerExtended PlayerLogic;
    private bool isChasing;
    // Start is called before the first frame update

    // Control Variables
    float lastStep, timeBetweenSteps = 1.0f;
    void Start()
    {
        PlayerLogic = Player.GetComponent<PlayerExtended>() as PlayerExtended;
        AnimatorManager = this.GetComponent<Animator>() as Animator;
        NavMeshAgent = this.GetComponent<NavMeshAgent>() as NavMeshAgent;
        isChasing = false;
        _source = this.GetComponent<AudioSource>() as AudioSource;
        AnimatorManager.SetBool("turnedLightOn", true);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        this.Speed = MapForce(distance);
        if(distance <= 5.0f)
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                _source.Play();
            }
        }
        if(!isChasing && PlayerLogic.isLight)
        {
            isChasing = true;
            AnimatorManager.SetBool("turnedLightOn", true);
            _source.Play();
            Debug.Log("Changed animation to running");
        }
        else if (PlayerLogic.isLight)
        {
            this.transform.position += this.transform.forward * Speed * Time.deltaTime;
            Vector3 dir = transform.position - Player.transform.position;
            dir = Vector3.Normalize(dir);
            Vector3 newPos = transform.position - dir * Speed * Time.deltaTime;
            NavMeshAgent.Warp(newPos);
            //NavMeshAgent.speed = 
        }
        else if(isChasing && !PlayerLogic.isLight)
        {
            isChasing = false;
            AnimatorManager.SetBool("turnedLightOn", false);
            Debug.Log("Changed animation to idle");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerLogic.EndGame();
        }
    }

    public float MapForce(float value, float in_min= 0.0f, float in_max = 256.0f, float out_min = 3.0f, float out_max=8.0f)
    {
        Debug.Log("Calculating for value" + value.ToString());
        float res = (value - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        Debug.Log("Res" + res.ToString());
        return res;
    }
}
