using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScreenUIManager : MonoBehaviour
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    void Start()
    {

        newGameButton.onClick.AddListener(StartNewGame);
        optionsButton.onClick.AddListener(ShowOptions);
        exitButton.onClick.AddListener(ExitApplication);
    }



    void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    
    void ShowOptions()
    {
        
    }
    void ExitApplication()
    {
        Application.Quit();
    }

    void OnDisable()
    {
        newGameButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

}

public enum SceneName {MainUI , MainGame }
