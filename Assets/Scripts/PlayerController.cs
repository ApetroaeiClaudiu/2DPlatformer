using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    private Rigidbody2D theRB;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    private Animator animator;
    public GameObject cherry;
    public Transform shootPoint;
     
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,whatIsGround);

        if(Input.GetKey(left)){
            theRB.velocity = new Vector2(-moveSpeed,theRB.velocity.y);
        }
        else if(Input.GetKey(right)){
            theRB.velocity = new Vector2(moveSpeed,theRB.velocity.y);
        }
        else {
            theRB.velocity = new Vector2(0,theRB.velocity.y);
        }
        if(Input.GetKeyDown(jump) && isGrounded){
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        if(Input.GetKeyDown(shoot)){
            GameObject cherryClone = (GameObject)Instantiate(cherry,shootPoint.position,shootPoint.rotation);
            cherryClone.transform.localScale = transform.localScale;
            animator.SetTrigger("Shoot");
        }

        if(theRB.velocity.x < 0 ){
            transform.localScale = new Vector3(-4,4,1);
        }
        else if(theRB.velocity.x > 0){
            transform.localScale = new Vector3(4,4,1);
        }

        animator.SetFloat("Speed",Mathf.Abs(theRB.velocity.x));
        animator.SetBool("Grounded",isGrounded);
    }
}
