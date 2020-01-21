using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level = 1;
    public int coins1 = 0;
    public int coins2 = 0;
    public bool clover1 = false;
    public bool clover2 = false;
    public bool colorclover1 = false;

    public PlayerData()
    {
        level = PlayerStats.level;
        coins1 = PlayerStats.coins1;
        coins2 = PlayerStats.coins2;
        clover1 = PlayerStats.clover1;
        clover2 = PlayerStats.clover2;
        colorclover1 = PlayerStats.colorclover1;

    }
}
