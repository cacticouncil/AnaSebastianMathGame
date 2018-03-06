using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif


public class MenuManagerImproved : MonoBehaviour
{
    public enum Menus { Main, Options, Credits, LevelSelection, Confirmation }

    public GameObject[] menus;

    public int bob;

    public void ChangeMenu(string menu)
    {
        Menus current = Menus.Main;
        for (int i = 0; i < System.Enum.GetValues(typeof(Menus)).Length; i++)
        {
            if(menu == ((Menus)i).ToString())
            {
                current = (Menus)i;
            }
        }

        for (int i = 0; i < menus.Length; i++)
        {
            if ((Menus)i == current)
                menus[i].SetActive(true);
            else
                menus[i].SetActive(false);
        }
    }
}

//#if UNITY_EDITOR
//[CustomEditor(typeof(MenuManagerImproved))]
//public class ManagerEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        MenuManagerImproved script = target as MenuManagerImproved;
//
//        GUILayout.BeginHorizontal();
//        GUILayout.Label("Somethin");
//        serializedObject.FindProperty("menus");
//        script.bob = EditorGUILayout.IntField(script.bob);
//        GUILayout.EndHorizontal();
//        EditorGUILayout.yes
//
//    }
//}
//#endif

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
        if (InfoManager.instance.Sound)
            GetComponent<AudioSource>().Play();
        InfoManager.instance.Save();
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToOptions()
    {
        if(InfoManager.instance.Sound)
        GetComponent<AudioSource>().Play();
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToCredits()
    {
        if (InfoManager.instance.Sound)
            GetComponent<AudioSource>().Play();
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToLevelSelection()
    {
        if (InfoManager.instance.Sound)
            GetComponent<AudioSource>().Play();
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(true);
        LevelSelectedMenu.SetActive(false);
    }

    public void GoToLevelSelected()
    {
        if (InfoManager.instance.Sound)
            GetComponent<AudioSource>().Play();
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);
        LevelSelectedMenu.SetActive(true);
     
    }
    public void load(string scene)
    {
        if (InfoManager.instance.Sound)
            GetComponent<AudioSource>().Play();
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
