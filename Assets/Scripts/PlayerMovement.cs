using System;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
[RequireComponent(typeof(CharacterController) , typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    readonly int MovementBlend = Animator.StringToHash("MovementBlend");
    readonly int Movement = Animator.StringToHash("Movement");
    readonly int Jump = Animator.StringToHash("Jump");
    readonly int Falling = Animator.StringToHash("Falling");
    CharacterController characterController;
    Animator animator;
    InputReader inputReader;
    Camera mainCamera;

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float sprintSpeed = 10;
    float currentSpeed;
    [SerializeField] float  rotationSpeed = 100;

    [SerializeField] LayerMask groundlayer;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] float groundCheckYOffset = 0.5f;
    [SerializeField] float maxJumpHeight = 5f;
    [SerializeField] float jumpTime = 0.75f;
    [SerializeField] float blendFactorDampTime = 0.1f;

    float gravity = -9.8f;
    float initialVelocity;
    bool isGrounded;
    Vector3 verticalVelocity = Vector3.zero;
    float maxMovementBlend = 0.5f;
    float crossfadeTime = 0.1f;
    Target target;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        inputReader = InstanceManager.Instance.inputReader;
        mainCamera = Camera.main;

        float timeToApex = jumpTime/2;
        gravity = (-2*maxJumpHeight)/Mathf.Pow(timeToApex,2);
        initialVelocity = (2*maxJumpHeight)/timeToApex;

        animator.CrossFadeInFixedTime(Movement , crossfadeTime);
        inputReader.OnAim += OnAim;
        inputReader.OnAimRelease += OnAimRelease;


    }



    private void Update() {

        HandelGravity();
        HandelJump();

        Vector3 moveDirection = GetMovementDirection();
        
        characterController.Move(currentSpeed * Time.deltaTime * moveDirection);
        characterController.Move(verticalVelocity*Time.deltaTime);

        float movementMagnitude = inputReader.InputDirection.normalized.magnitude;
        float movementBlendFloat = Mathf.Clamp(movementMagnitude,0,maxMovementBlend);

        animator.SetFloat(MovementBlend , movementBlendFloat , blendFactorDampTime , Time.deltaTime);

        if(inputReader.InputDirection.magnitude > 0.1f)
        {
            moveDirection.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation , 
            Quaternion.LookRotation(moveDirection) , 
            rotationSpeed*Time.deltaTime);

        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + Vector3.up*groundCheckYOffset , groundCheckRadius);
    }

    void HandelGravity()
    {
        bool isFalling = verticalVelocity.y <= 0;
        float gravityMultiplayer =2f;
        if(Physics.CheckSphere(transform.position + Vector3.up*groundCheckYOffset , groundCheckRadius , groundlayer))
        {
            verticalVelocity.y = -0.05f;
            isGrounded = true;
            animator.SetBool(Falling , false);

        }else if(isFalling)
        {
            //runs only if its not grounded
            animator.SetBool(Falling , true);
            float previousYVelocity = verticalVelocity.y;
            float newYVelocity = previousYVelocity + gravityMultiplayer*gravity*Time.deltaTime;
            float nextYvelocity = (previousYVelocity + newYVelocity ) / 2;
            verticalVelocity.y = nextYvelocity;
        }
        else{
            float previousYVelocity = verticalVelocity.y;
            float newYVelocity = previousYVelocity + gravity*Time.deltaTime;
            float nextYvelocity = (previousYVelocity + newYVelocity ) / 2;
            verticalVelocity.y = nextYvelocity;
            isGrounded = false;
        }
    }

    void HandelJump()
    {
        if(inputReader.Jump && isGrounded)
        {
            verticalVelocity.y = initialVelocity;
            animator.SetBool(Jump , true);
        }
        else
        {
            animator.SetBool(Jump , false);

        }
    }

    Vector3 GetMovementDirection()
    {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        Vector3 right = mainCamera.transform.right;
        right.y = 0;
        if(inputReader.InputDirection.magnitude > 0.1f)
        {
            if(inputReader.Sprint)
            {
                currentSpeed = sprintSpeed;
                maxMovementBlend = 1f;

            }
            else
            {
                currentSpeed = moveSpeed;
                maxMovementBlend = 0.5f;
            }
            
        }
        else
            maxMovementBlend = 0.5f;


        return  forward*inputReader.InputDirection.y + right*inputReader.InputDirection.x ;
    }

    private void OnAim()
    {
        target = InstanceManager.Instance.targetSystem.GetColsestTarget();
        if(target == null) return;
        
        target.StartToFill();
        
    }

    private void OnAimRelease()
    {
        if(target == null) return;

        target.StopFill();
        target = null;
    }
}
