using UnityEngine;

public class InputReader : MonoBehaviour
{
    Vector2 inputDirection ;
    bool sprint;
    bool jump;
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


    }

    public Vector2 InputDirection => inputDirection;
    public bool Sprint => sprint;
    public bool Jump => jump;
}