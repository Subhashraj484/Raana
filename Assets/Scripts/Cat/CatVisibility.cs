using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVisibility : MonoBehaviour
{
    [SerializeField] bool canDetect;
    [SerializeField] float range = 20f;
    bool visible;

    bool done;
    GameUI gameUI;
    Transform player;

    private void Start() {
        gameUI = GameUI.Instance;
        player = gameUI.Player.transform;
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
