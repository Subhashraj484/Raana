
using Unity.VisualScripting;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    GameUI gameUI;
    [SerializeField] float destroyDistance = 3f;
    private void Start() {
        gameUI = GameUI.Instance;
    }
    
    void Update()
    {
        if(Vector3.Distance(gameUI.GetPlayerPosition() , transform.position) < destroyDistance) 
        {
            GameUI.Instance.UpdateCollectable();
            Destroy(gameObject);
        }

       
    }
}
