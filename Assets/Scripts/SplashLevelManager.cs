using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashLevelManager : MonoBehaviour
{
    [SerializeField]
    private float loadLevelTimer;
    private void Start()
    {
        Invoke("LoadNextLevel", loadLevelTimer);
    }

    [System.Obsolete]
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
