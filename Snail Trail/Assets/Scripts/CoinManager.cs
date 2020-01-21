using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI text;
    static public int coins;
    public GameObject UIClover;
    public GameObject UIColorClover;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void changeScore(int coinValue)
    {
        coins += coinValue;
        text.text = "x" + coins.ToString();
    }

}
