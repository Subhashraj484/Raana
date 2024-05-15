using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainScreenUIManager : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(StartNewGame);
        optionsButton.onClick.AddListener(ShowOptions);
        exitButton.onClick.AddListener(ExitApplication);
    }

    void ContinueGame()
    {
        //contuineGame
    }

    void StartNewGame()
    {
        
    }
    
    void ShowOptions()
    {
        
    }
    void ExitApplication()
    {
        
    }

    void OnDisable()
    {
        continueButton.onClick.RemoveAllListeners();
        newGameButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

}

public enum SceneName {MainUI , MainGame }
