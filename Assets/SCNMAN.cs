using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCNMAN : MonoBehaviour
{
    public int nextIndx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            LoadGame();
        }
    }

    void LoadGame(){
        GameData.isNewGame = true;
        SceneManager.LoadScene(nextIndx);
    }
}
