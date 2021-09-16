using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager1 : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject HelpMenu;
    public GameObject welcomePnel;
    public void start()
    {
        SceneManager.LoadScene(2);
    }
    public void OptionScreen()
    {
        HomeScreen.SetActive(true);
        welcomePnel.SetActive(true);
        HelpMenu.SetActive(false);
    }
    public void HelpScreen()
    {
        HomeScreen.SetActive(false);
        HelpMenu.SetActive(true);
        welcomePnel.SetActive(false);
    }

}