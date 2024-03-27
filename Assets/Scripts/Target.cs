using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    TargetSystem targetSystem;
    [SerializeField] Slider slider;
    [SerializeField] float fillTime = 1.5f;
    bool startToFill;
    float timer = 0;

    void Start()
    {
        targetSystem = InstanceManager.Instance.targetSystem;
        slider.value = 0;

    }
    private void OnBecameVisible()
    {
        targetSystem.AddTarget(this);
        // Debug.Log("hi");
    }

    private void Update() {
        if(!startToFill) return;

        if(timer >= fillTime) StopFill();

        timer += Time.deltaTime;
        slider.value = timer/fillTime;
    }

    private void OnBecameInvisible()
    {
        // Debug.Log("Bye");
        targetSystem.RemoveTarget(this);
        
    }

    public void StartToFill()
    {
        startToFill = true;

    }

    public void StopFill()
    {
        startToFill = false;
        timer = 0;
        slider.value = timer;
    }




}
