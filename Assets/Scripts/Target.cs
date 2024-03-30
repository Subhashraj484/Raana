using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    float fillTimer = 0;
    const string ArrowTag = "Arrow";
    float coolDownTime = 4f;
    float coolDownTimer = 0;
    bool coolingDown;
    Transform playerTransform;
    float rotationSpeed = 600;

    void Start()
    {
        targetSystem = InstanceManager.Instance.targetSystem;
        playerTransform = InstanceManager.Instance.player;
        slider.value = 0;

    }
    private void OnBecameVisible()
    {
        if(coolingDown) return;
        targetSystem.AddTarget(this);

        // Debug.Log("hi");
    }

    private void Update() {

        if(coolingDown)
        {
            coolDownTimer += Time.deltaTime;
            if(coolDownTimer >= coolDownTime)
            {
                coolingDown = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                coolDownTimer =0;

            } 

        }

        if(coolingDown) return;

        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();
        transform.rotation =    Quaternion.RotateTowards(transform.rotation , 
                                Quaternion.LookRotation(direction) ,
                                rotationSpeed*Time.deltaTime);

        if(!startToFill) return;

        if(fillTimer >= fillTime) StopFill();

        fillTimer += Time.deltaTime;
        slider.value = fillTimer/fillTime;

        
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
        // fillTimer = 0;
        // slider.value = fillTimer;

    }


    void OnParticleCollision(GameObject other)
    {
        if(!other.transform.CompareTag(ArrowTag)) return;

        other.GetComponent<ParticleSystem>().Stop();
        other.gameObject.SetActive(false);
        coolingDown = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        targetSystem.RemoveTarget(this);
    } 
    
    public float GetSliderValue()
    {
        return slider.value;
    }

    public void Reset()
    {
        fillTimer = 0;
        slider.value = fillTimer;
    }

}

