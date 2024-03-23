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
    }

    private void OnBecameInvisible()
    {
        targetSystem.RemoveTarget(this);
        
    }
}
