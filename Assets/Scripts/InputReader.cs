using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    Vector2 inputDirection ;
    bool sprint;
    bool jump;
    bool aim;
    public event Action OnAim;
    public event Action OnAimRelease;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        inputDirection = new Vector2(x,y);

        sprint = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnAim?.Invoke();
        }
        if(Input.GetMouseButtonUp(0))
        {
            OnAimRelease?.Invoke();
        }


    }

    public Vector2 InputDirection => inputDirection;
    public bool Sprint => sprint;
    public bool Jump => jump;
    public bool Aim => aim;
}