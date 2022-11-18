using UnityEngine;

public class Character : MonoBehaviour {    
    public float speed = 10.0f;

    public float rotationSpeed = 100.0f;
    
    public float jumpSpeed = 8.0f;
    
    public float gravity = 20.0f;
    
    public Vector3 moveDirection = Vector3.zero;
    
    public CharacterController controller;
    
    public Animator anim;

    readonly KeyCode W = KeyCode.W;

    readonly KeyCode A = KeyCode.A;

    readonly KeyCode D = KeyCode.D;

    readonly KeyCode S = KeyCode.S;

    public Vector3 mouseDirection = Vector3.zero;


    void Awake()
    {
        controller = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            mouseDirection = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

            mouseDirection = transform.TransformDirection(mouseDirection);

            mouseDirection *= rotationSpeed;

            moveDirection = transform.TransformDirection(moveDirection);
            
            moveDirection *= speed;
            
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }

            if(moveDirection != Vector3.zero){
                anim.SetBool("Walking", true);
                
                anim.SetBool("Idle", false);
            }
            
            else{
                anim.SetBool("Walking", false);
                
                anim.SetBool("Idle", true);
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
       

        if(Input.GetKey(W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else if(Input.GetKey(A)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else if(Input.GetKey(D)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }else if(Input.GetKey(S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
}
}