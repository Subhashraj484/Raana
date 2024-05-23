using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] List<CollectableImage> CollectableImages = new();
    [SerializeField] GameObject escapePanel;
    [SerializeField] CanvasGroup escapeCanvasGroup;

    [SerializeField] GameObject gameoverPanel;
    [SerializeField] CanvasGroup gameoverCanvasGroup;
    [SerializeField] GameObject winpanel;
    [SerializeField] CanvasGroup winCanvasGroup;


    [SerializeField] List<Button> mainMenus;
    [SerializeField] List<Button> quits;
    [SerializeField] Button resumeButton;


    [SerializeField] int winPoint = 2;

    public GameObject Player;
    public static GameUI Instance {get ; private set;}
    int currentCollectabeindex = 0;

    bool escape;

    private void Awake() {
        if(Instance != null)
        {
            Destroy(this);
        }
        
        Instance = this;
    }

    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;

        foreach(var image in CollectableImages)
        {
            image.collectableColor = image.collectabe.color;
            image.collectabe.color = new Color(image.collectableColor.r , image.collectableColor.g , image.collectableColor.b , 0.4f); 
        }

        escapePanel.SetActive(false);
        escapeCanvasGroup.alpha = 0;

        
        gameoverPanel.SetActive(false);
        gameoverCanvasGroup.alpha = 0;

        winpanel.SetActive(false);
        winCanvasGroup.alpha = 0;

        foreach(var mainmenu in mainMenus )
        {
            mainmenu.onClick.AddListener(MainMenu);
        }

        foreach(var quit in quits)
        {
            quit.onClick.AddListener(Quit);
        }

        resumeButton.onClick.AddListener(Resume);




    }

    private void Resume()
    {
        escapeCanvasGroup.alpha = 0;
        ResumeGame();
    }

    private void Quit()
    {
        ResumeGame();
        Application.Quit();
    }

    private void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escape = !escape;
            ToggleEscapePanel(escape);
        }
    }

    void ToggleEscapePanel(bool toggle)
    {
        escapePanel.SetActive(toggle);

        if(toggle)
        {
            escapeCanvasGroup.alpha = 1;
            PauseGame();
        }
        else
        {
            escapeCanvasGroup.alpha = 0;
            ResumeGame();

        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        ReleaseCursorState();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        LockCursorState();
    }

    public void UpdateCollectable()
    {

        if(currentCollectabeindex > CollectableImages.Count- 1) return;

        CollectableImage collectableImage = CollectableImages[currentCollectabeindex];
        collectableImage.collectabe.color = new Color(collectableImage.collectableColor.r , collectableImage.collectableColor.g , collectableImage.collectableColor.b , 1); 

        if(currentCollectabeindex >= winPoint - 1)
        {
            ShowWinPanel();
        }
        currentCollectabeindex++;
    }

    public Vector3 GetPlayerPosition()
    {
        return Player.transform.position;
    }

    public void ShowGameOverPanel()
    {

        gameoverPanel.SetActive(true);
        gameoverCanvasGroup.alpha = 1;
        PauseGame();
    }

    public void ShowWinPanel()
    {
        

        winpanel.SetActive(true);
        winCanvasGroup.alpha = 1;
        PauseGame();
    }

    public void ReleaseCursorState()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void LockCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
}

[System.Serializable]
public class CollectableImage
{
    public  Image collectabe;
    public Color collectableColor;
    public bool filled;
}
