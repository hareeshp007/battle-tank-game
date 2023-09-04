using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelMenu;
    private void Awake()
    {
        LevelMenu.SetActive(false);
    }
    public void Play()
    {
        LevelMenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
