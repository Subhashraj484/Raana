using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ArrowSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem correctArrowParticle;
    [SerializeField] ParticleSystem wrongArrowParticle;
    [SerializeField] float roundOfThreshold = 0.1f;
    

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    InstanceManager instanceManager;
    private void Start() {
        instanceManager = InstanceManager.Instance;
    }
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Target target = instanceManager.targetSystem.GetColsestTarget();
            if(target == null) return;
            
            float sliderValue = target.GetSliderValue();

            if(sliderValue > 0.5 - roundOfThreshold && sliderValue < 0.5 + roundOfThreshold)
            {
                Debug.Log("half");
                ReleaseCorrectArrow(target);
            }
            else if(sliderValue == 1)
            {
                Debug.Log("full");
                ReleaseCorrectArrow(target);
            }
            else
            {
                Debug.Log("not full");
                ReleaseWrongArrow(target);
            }


            target.Reset();
        }
    }

    void ReleaseCorrectArrow(Target target)
    {
        correctArrowParticle.transform.position = target.transform.position;
        var shape = correctArrowParticle.shape;
        shape.position = correctArrowParticle.transform.InverseTransformPoint(instanceManager.arrowReleasePoint.position);
        correctArrowParticle.gameObject.SetActive(true);
        correctArrowParticle.Play();
    } 

    void ReleaseWrongArrow(Target target)
    {
        wrongArrowParticle.transform.position = instanceManager.arrowReleasePoint.position;
        wrongArrowParticle.transform.LookAt(target.transform.position);
        wrongArrowParticle.gameObject.SetActive(true);
        wrongArrowParticle.Play();
    }
}
