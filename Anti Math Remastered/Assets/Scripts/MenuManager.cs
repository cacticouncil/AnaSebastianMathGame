using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;
    public GameObject LevelSelectionMenu;
    public GameObject LevelSelectedMenu;

    private void Start()
    {
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToOptions()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToCredits()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

}
