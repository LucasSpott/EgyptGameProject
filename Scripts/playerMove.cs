using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour{

    [Header("Player Stats")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpSpeed = 4.0f;
    [SerializeField] private float rotateSpeed = 3.0f;
    [SerializeField] private float runSpeed = 3.0f;

    [Header("Player Components")]
    float gravity = -10.0f;
    CharacterController control;
    Vector3 moveVelocity;
    Animator anim;

    void Awake(){
        control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update(){
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        // Run Function
        if(Input.GetKey(KeyCode.LeftShift)){
            moveVelocity = transform.forward * runSpeed * vInput;
            moveVelocity += transform.right * runSpeed * hInput;
        if(vInput >= 1){
            anim.SetBool("Running", true);
            anim.SetBool("Walking", false);
        }
    }
    
        if(hInput != 0 || vInput != 0){
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
        }else{
            anim.SetBool("Walking", false);
            anim.SetBool("Idle", true);
        }

        // Move Controller with colider jump
        if(control.isGrounded){
            moveVelocity = transform.forward * speed * vInput;
            moveVelocity += transform.right * speed * hInput;
            
            //CAMERA CONTROLLER
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
            transform.Rotate(0, mouseX, 0);
            transform.Rotate(0, mouseY, 0);
            mouseX *= Time.deltaTime;
            mouseY *= Time.deltaTime;
        }

        // Jump Function
    if(Input.GetButtonDown("Jump")){
        moveVelocity.y = jumpSpeed;
    }
        moveVelocity.y += gravity * Time.deltaTime;
        control.Move(moveVelocity * speed * Time.deltaTime);
    }
}

