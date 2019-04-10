using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static List<CDBehaviour> allCds = new List<CDBehaviour>();
    public static List<CDBehaviour> CollectedCDs = new List<CDBehaviour>();
    public static Vector3 AyuwokiPosition = new Vector3();

    public static Transform[] CDPositions = new Transform[5];

    public static int grabbedCDs = 0;
    public static int totalCDs = 4;

    public static bool isNewGame = true;
}
