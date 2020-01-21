using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject clover1UI;
    public GameObject clover2UI;
    public GameObject colorclover1UI;
    public GameObject level2unlocked;

    public TextMeshProUGUI coins1UI;
    public TextMeshProUGUI coins2UI;



    void Start()
    {
        PlayerStats.LoadPlayer();

        if (PlayerStats.clover1 && SceneManager.GetActiveScene().buildIndex==0)
        {
            clover1UI.SetActive(true);
        }
        if (PlayerStats.clover2 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            clover2UI.SetActive(true);
        }
        if (PlayerStats.colorclover1 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            colorclover1UI.SetActive(true);
        }
        if (PlayerStats.level >= 2)
        {
            level2unlocked.SetActive(true);
        }
        coins1UI.text = "x" + PlayerStats.coins1.ToString()+ "/45";
        coins2UI.text = "x" + PlayerStats.coins2.ToString()+ "/79";


  
    }
    public int whichlevel;
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + whichlevel);
    }
    public void quitgame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void returntomenu()
    {
        SceneManager.LoadScene(0);
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void deletesavefile()
    {
        PlayerStats.level = 1;
        PlayerStats.coins1 = 0;
        PlayerStats.coins2 = 0;
        PlayerStats.clover1 = false;
        PlayerStats.clover2 = false;
        PlayerStats.colorclover1 = false;
        PlayerStats.SavePlayer();
        PlayerStats.LoadPlayer();

        if (PlayerStats.clover1 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            clover1UI.SetActive(true);
        }
        if (PlayerStats.clover2 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            clover2UI.SetActive(true);
        }
        if (PlayerStats.colorclover1 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            colorclover1UI.SetActive(true);
        }
        if (PlayerStats.level >= 2)
        {
            level2unlocked.SetActive(true);
        }
        coins1UI.text = "x" + PlayerStats.coins1.ToString() + "/45";
        coins2UI.text = "x" + PlayerStats.coins2.ToString() + "/79";
    }

}
