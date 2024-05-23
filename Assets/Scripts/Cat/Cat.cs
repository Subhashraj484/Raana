using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
[RequireComponent(typeof(SplineAnimate) , typeof(Animator))]
public class Cat : MonoBehaviour
{
    SplineAnimate splineAnimate;
    Animator animator;
    readonly int Run = Animator.StringToHash("Run"); 
    bool isRunning;
    [SerializeField] float delayTime;
    

    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
        animator = GetComponent<Animator>();
        animator.SetBool(Run , false);
        StartCoroutine(DeplayMovement(delayTime));
    }

    IEnumerator DeplayMovement(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        splineAnimate.Play();
        animator.SetBool(Run , true);
        isRunning = true;

    }

    private void Update() {

        if(!isRunning) return;


        if(splineAnimate.NormalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }


}
