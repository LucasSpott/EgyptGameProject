using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningscript : StateMachineBehaviour{
   public Animator anim;
    public CharacterController controller;

    void Awake(){
    }
    void Update(){
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
                anim.SetBool("Walking", true);
            }else{
                anim.SetBool("Walking", false);
                anim.SetBool("Idle", true);
            }


    }
}
}
