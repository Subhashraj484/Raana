using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.Splines;

public class CatVisibility : MonoBehaviour
{
    [SerializeField] bool canDetect;
    [SerializeField] float range = 20f;
    [SerializeField] SplineAnimate splineAnimate;
    public DifficultyLevel difficultyLevel;
    bool visible;

    bool done;
    GameUI gameUI;
    Transform player;

    private void Start() {
        gameUI = GameUI.Instance;
        player = gameUI.Player.transform;

        range = difficultyLevel.F_difficultyRange;
        splineAnimate.Duration = difficultyLevel.F_duration;
    }

    private void OnBecameVisible() {
        visible = true;
    }

    private void OnBecameInvisible() {
        
        if(!canDetect) return;
        
        visible = false;
    }

    public void SetCanDetectTrue()
    {
        canDetect = true;
    }

    private void Update() {

        if(!canDetect) return;


        float distance = Mathf.Abs(Vector3.Distance(transform.position , player.position));
        

        if(distance > range)
        {
            gameUI.ShowGameOverPanel();
        }
    }
}
