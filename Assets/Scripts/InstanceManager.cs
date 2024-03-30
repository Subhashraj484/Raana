using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    #region  SingleTon
    public static InstanceManager Instance{get ; private set ;}

    private void Awake() {
        if(Instance != null)
        {
            Debug.Log("There exist more than one InstanceManager in the scene");
            Destroy(this);

        }
        Instance = this;
    }
    #endregion
    
    public InputReader inputReader;
    public TargetSystem targetSystem;
    public Transform player;
    public Transform arrowReleasePoint;

}
