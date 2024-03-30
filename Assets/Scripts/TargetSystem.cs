using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public List<Target> targets = new();
    InstanceManager instanceManager;
    [SerializeField] float maxTargetDistance = 35f;
    Camera mainCamera;
    Target closesttarget;
    Target temptarget;
    [SerializeField] float zAxisMultiplyer = 30;
    
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

        // if(instanceManager.inputReader.Aim && closesttarget != null)
        // {
        //     Debug.Log(closesttarget);
        //     return;
        // }
        
        float temp = Mathf.Infinity;

        foreach(Target target in targets)
        {
            float targetDistance = Get3DTargetDistance(target);
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

    float Get3DTargetDistance(Target target)
    {
        Vector3 targetScreenPosition = mainCamera.WorldToScreenPoint(target.transform.position);
        Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, targetScreenPosition.z);
        float zAxisDistance = Vector3.Distance(instanceManager.player.position , target.transform.position);
        return Vector3.Distance(targetScreenPosition, centerScreenPosition) + zAxisDistance*zAxisMultiplyer;
    }

    public Target GetColsestTarget()
    {
        return closesttarget;
    }

    
}
