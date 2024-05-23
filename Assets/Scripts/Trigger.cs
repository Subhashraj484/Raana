using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Triggercat triggercat;
    [SerializeField] CatVisibility catVisibility;
    bool done;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player") & !done)
        {
            catVisibility.SetCanDetectTrue();
            triggercat.Move();
            done = true;
        }
    }
}
