using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class PlayerStats
{
    public static int level = 1;
    public static int coins1 = 0;
    public static int coins2 = 0;
    public static bool clover1 = false;
    public static bool clover2 = false;
    public static bool colorclover1 = false;

    public static void SavePlayer()
    {
        SaveSystem.SavePlayer();
    }
    public static void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        coins1 = data.coins1;
        coins2 = data.coins2;
        clover1 = data.clover1;
        clover2 = data.clover2;
        colorclover1 = data.colorclover1;
    }
}