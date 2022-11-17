using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour{
    
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public Animator anim;

    void Awake(){
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        if (controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
            if(moveDirection != Vector3.zero){
                anim.SetBool("Walking", true);
            }else{
                anim.SetBool("Walking", false);
                anim.SetBool("Idle", true);
            }
            
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        anim.SetFloat("Speed", moveDirection.magnitude);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    
}
}