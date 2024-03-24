using UnityEngine;

public class Target : MonoBehaviour
{
    TargetSystem targetSystem;

    void Start()
    {
        targetSystem = InstanceManager.Instance.targetSystem;

    }
    private void OnBecameVisible()
    {
        targetSystem.AddTarget(this);
        Debug.Log("hi");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Bye");
        targetSystem.RemoveTarget(this);
        
    }


}
