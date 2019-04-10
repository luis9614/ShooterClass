using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicObj : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] CDS = new GameObject[5];
    private Transform[] CDPositions = new Transform[5];
    // Start is called before the first frame update

    private System.Random random;

    public List<GameObject> spawnLocations;
    void Start()
    {
        random = new System.Random();
        if(GameData.isNewGame){
            spawnLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("Respawn"));
            AssignSpawnLocations();
            InstantiateCD();
        }else{
            //  LOAD
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignSpawnLocations(){
        int listLength = 0;
        int r = 0;
        for(int i=0;i<4;i++){
            listLength = spawnLocations.Count;
            r = random.Next(0, listLength);
            GameObject aux = spawnLocations[r];
            spawnLocations.RemoveAt(r);
            CDPositions[i] = aux.gameObject.transform;

            Debug.Log(CDPositions[i].position);
        }
    }

    void InstantiateCD(){
        for(int i = 0; i < 4; i++){
            Instantiate(CDS[i],CDPositions[i].position,  Quaternion.identity);
        }
    }
}
