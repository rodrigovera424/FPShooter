

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController; 
    public float speed = 10f; 

    private float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius =0.3f;
    public LayerMask groundMask;

    bool IsGrounded;

    Vector3 velocity;
    public float jumpHeight = 3 ;

    public bool isSprinting;
    public float sprintingSpeedMultiplier = 2.5F;
    private float sprintSpeed =1;
   private float staminaUseAmount =5;
   private StaminaBar staminaSlider;

   public Animator animator;

private void Start () {

    staminaSlider = FindObjectOfType<StaminaBar>();
    
}

    void Update()
    {

        IsGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);
        if (IsGrounded && velocity.y < 0)
    {
        velocity.y =-2f;
    }
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");

    animator.SetFloat("VelX", x);
animator.SetFloat("VelZ", z);
animator.SetBool("IsSprinting",isSprinting);

       Vector3 move = transform.right * x + transform.forward * z;

     
    JumpCheck();
    RunCheck();
       characterController.Move(move * speed * Time.deltaTime);
       velocity.y+= gravity *Time.deltaTime;
          characterController.Move (velocity * Time.deltaTime); 
    }

 public void JumpCheck()
{
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetBool("IsJumping", true);
    }
    else if (IsGrounded)
    {
        animator.SetBool("IsJumping", false);
    }
    else if (velocity.y < 0.1f)
    {
        // Si la velocidad vertical es cercana a cero, restablece la animación de salto
        animator.SetBool("IsJumping", false);
    }
}
    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;

            if (isSprinting==true)
        {
            staminaSlider.UseStamina(staminaUseAmount);
        }
        else 
        {
            staminaSlider.UseStamina(0);
        }
        }
        if(isSprinting==true)
        {
            sprintSpeed=sprintingSpeedMultiplier;
            staminaSlider.UseStamina(staminaUseAmount);
        }
    else 
    {
        sprintSpeed =1;
        
    }
}
 }
