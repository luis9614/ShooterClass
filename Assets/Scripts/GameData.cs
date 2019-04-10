using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static List<CDBehaviour> allCds = new List<CDBehaviour>();
    public static List<CDBehaviour> CollectedCDs = new List<CDBehaviour>();

    public static Vector3 AyuwokiPosition = new Vector3();
    public static Vector3 PlayerPos = new Vector3();

    public static Vector3[] CDPositions = new Vector3[5];

    public static int grabbedCDs = 0;
    public static int totalCDs = 4;

    public static bool isNewGame = true;

    public static Dictionary<string, bool> mapEnabled = new Dictionary<string, bool>();

    public static void MarkAsUsed(string albumName)
    {
        mapEnabled[albumName] = false;
        Debug.Log("Marked as grabbed: " + albumName);
    }

    public static void ClearData()
    {
        isNewGame = false;
        CDPositions = new Vector3[5];
        mapEnabled.Clear();
        grabbedCDs = 0;

    }


}
