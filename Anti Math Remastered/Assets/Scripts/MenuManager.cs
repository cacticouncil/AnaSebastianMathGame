using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;
    public GameObject LevelSelectionMenu;
    public GameObject LevelSelectedMenu;

    public GameObject InfoPanel;
    private void Start()
    {
        GoToMainMenu();
        Time.timeScale = 1;
        
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

    public void GoToLevelSelection()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(true);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToLevelSelected()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(true);
     
    }
    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void FixedUpdate()
    {
        if (InfoPanel == null)
            return;
        if (Camera.main.GetComponent<CamScript>().Right)
        {
            InfoPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            InfoPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            InfoPanel.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
        }
        else
        {
            InfoPanel.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
            InfoPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
            InfoPanel.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
        }
    }
}
