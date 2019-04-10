using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicObj : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] CDS = new GameObject[5];
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
            GameData.isNewGame = false;
        }else{
            InstantiateCD();
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
            Vector3 aVect = aux.gameObject.transform.position;
            GameData.CDPositions[i] = new Vector3(aVect.x, aVect.y, aVect.z);
            string albumName = CDS[i].name;
            GameData.mapEnabled.Add(albumName, true);

            Debug.Log("Pos: " + GameData.CDPositions[i]);
        }
    }

    void InstantiateCD(){
        foreach (KeyValuePair<string, bool> kvp in GameData.mapEnabled)
        {
            Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value.ToString());
        }
        for (int i = 0; i < 4; i++){
            if (GameData.mapEnabled[CDS[i].name])
            {
                Instantiate(CDS[i], GameData.CDPositions[i], Quaternion.identity);
            }
            else
            {
                Debug.Log("Ignored an Element: title: " + CDS[i].name);
            }
            
        }
    }
}
