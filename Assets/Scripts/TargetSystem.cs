using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public List<Target> targets = new();
    InstanceManager instanceManager;
    [SerializeField] float maxTargetDistance = 35f;
    Camera mainCamera;
    Target closesttarget;
    Target temptarget;
    void Start()
    {
        instanceManager = InstanceManager.Instance;
        mainCamera = Camera.main;
    }

    private void Update() {
        if(targets.Count <= 0) 
        {
            closesttarget = null;
            return;
        }
        
        float temp = Mathf.Infinity;

        foreach(Target target in targets)
        {
            float targetDistance = GetTargetDistance(target);
            if(temp > targetDistance)
            {
                temp = targetDistance;
                temptarget = target;
            }
        }

        closesttarget = temptarget;
    }

    public void AddTarget(Target target)
    {
        if(!IsReachable(target.transform.position)) return;
        if(targets.Contains(target)) return;
        targets.Add(target);
    }

    public void RemoveTarget(Target target)
    {
        if(!targets.Contains(target)) return;
        targets.Remove(target);
    }

    public bool IsReachable(Vector3 position)
    {
        return Vector3.Distance(instanceManager.player.position , position) < maxTargetDistance;
    }

    float GetTargetDistance(Target target)
    {
        Vector3 targetScreenPosition = mainCamera.WorldToScreenPoint(target.transform.position);
        Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, targetScreenPosition.z);
        return Vector3.Distance(targetScreenPosition, centerScreenPosition);
    }

    
}
