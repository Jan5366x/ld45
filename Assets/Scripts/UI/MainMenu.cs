using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject root;

    private const String FIRST_STAGE = "First Stage";
    private const String SECOND_STAGE = "Second Stage";
    private const String CREDITS_STAGE = "Credits Stage";

    public static int choice;
    public static bool victory;

    private void HideAllStages()
    {
        root.transform.Find(FIRST_STAGE).gameObject.SetActive(false);
        root.transform.Find(SECOND_STAGE).gameObject.SetActive(false);
        root.transform.Find(CREDITS_STAGE).gameObject.SetActive(false);
    }

    private void ShowStage(String name)
    {
        HideAllStages();
        root.transform.Find(name).gameObject.SetActive(true);
    }

    public void OnClickPlay()
    {
        ShowStage(SECOND_STAGE);
    }

    public void ShowCredits()
    {
        ShowStage(CREDITS_STAGE);
    }


    public void PlayArmor()
    {
        choice = 0;
        LoadMainScene();
    }

    private static void LoadMainScene()
    {
        victory = false;
        SceneManager.LoadScene("MainGame");
    }

    public void PlaySword()
    {
        choice = 1;
        LoadMainScene();
    }

    public void PlayNothing()
    {
        choice = 2;
        LoadMainScene();
    }

    public void GoBackCredits()
    {
        ShowStage(FIRST_STAGE);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}