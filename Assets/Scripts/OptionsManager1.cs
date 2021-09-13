using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager1 : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject HelpMenu;
    public void start()
    {
        SceneManager.LoadScene(2);
    }
    public void Home()
    {
        HomeScreen.SetActive(true);
        HelpMenu.SetActive(false);
    }
    public void HomeMenu()
    {
        HomeScreen.SetActive(true);
        HelpMenu.SetActive(false);
    }
    public void OptionScreen()
    {
        HomeScreen.SetActive(false);
        HelpMenu.SetActive(false);
    }
    public void HelpScreen()
    {
        HomeScreen.SetActive(false);
        HelpMenu.SetActive(true);
    }

}