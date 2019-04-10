using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static List<CDBehaviour> allCds = new List<CDBehaviour>();
    public static List<CDBehaviour> CollectedCDs = new List<CDBehaviour>();
    public static Vector3 AyuwokiPosition = new Vector3();

    public static Vector3[] CDPositions = new Vector3[5];
    public static bool[] CDStatud = new bool[5];

    public static int grabbedCDs = 0;
    public static int totalCDs = 4;

    public static bool isNewGame = true;

    public static void markUsed(string albumName){
        for(int i = 0; i< 4;i++){
            
        }
    }


}
