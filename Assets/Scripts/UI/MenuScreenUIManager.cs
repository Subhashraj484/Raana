using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class MenuScreenUIManager : MonoBehaviour
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button closeOption;
    [SerializeField] Button closeStory;
    [SerializeField] Button story;
    [SerializeField] Slider rangeSlider;
    [SerializeField] Slider durationSlider;
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject storyPanel;
    [SerializeField] CanvasGroup storyCanvas;
    [SerializeField] CanvasGroup optionCanvas;


    [SerializeField] DifficultyLevel difficultyLevel;
    void Start()
    {

        newGameButton.onClick.AddListener(StartNewGame);
        optionsButton.onClick.AddListener(ShowOptions);
        exitButton.onClick.AddListener(ExitApplication);
        closeOption.onClick.AddListener(CloseOption);
        closeStory.onClick.AddListener(CloseStory);
        story.onClick.AddListener(Story);


        optionPanel.gameObject.SetActive(false);
        storyPanel.gameObject.SetActive(false);

        optionCanvas.alpha =  0;
        storyCanvas.alpha = 0 ;
    
    }

    private void Story()
    {
        storyPanel.gameObject.SetActive(true);
        storyCanvas.alpha = 1 ;
        
    }

    private void CloseStory()
    {
        storyPanel.gameObject.SetActive(false);
        storyCanvas.alpha = 0 ;





    }

    private void CloseOption()
    {
        optionPanel.gameObject.SetActive(false);
        optionCanvas.alpha =  0;

        difficultyLevel.F_difficultyRange = rangeSlider.value;
        difficultyLevel.F_duration = durationSlider.value;

        Debug.Log("Range " + difficultyLevel.F_difficultyRange);
        Debug.Log("Duration " + difficultyLevel.F_duration);

    }

    void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    
    void ShowOptions()
    {
        optionPanel.gameObject.SetActive(true);
        optionCanvas.alpha =  1; 
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
