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
    void Start()
    {
        PlayerLogic = Player.GetComponent<PlayerExtended>() as PlayerExtended;
        AnimatorManager = this.GetComponent<Animator>() as Animator;
        NavMeshAgent = this.GetComponent<NavMeshAgent>() as NavMeshAgent;
        isChasing = false;
        _source = this.GetComponent<AudioSource>() as AudioSource;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);

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
}
