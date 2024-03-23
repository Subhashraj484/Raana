using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    List<Target> targets = new();

    public void AddTarget(Target target)
    {
        if(targets.Contains(target)) return;
        targets.Add(target);
    }

    public void RemoveTarget(Target target)
    {
        if(!targets.Contains(target)) return;
        targets.Remove(target);
    }

    
}
