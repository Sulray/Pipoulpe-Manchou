using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ManchouMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputX;
    private float inputY;

    [SerializeField] private float move_speed;
    [SerializeField] private float jump_speed;
    [SerializeField] private float swimBounceX;
    [SerializeField] private float swimBounceY;
    [SerializeField] private float gravity;
    [SerializeField] private float swimGravity;
    [SerializeField] private float drag;
    [SerializeField] private float swimDrag;


    LayerMask maskPlatform;
    LayerMask maskPipoulpe;
    LayerMask maskIce;
    LayerMask maskWater;
    LayerMask maskBoostJump;

    private bool isOnPlatform = true;
    private bool isOnPipoulpe = false;
    private bool isOnIce = false;
    private bool isInWater = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        maskPlatform = LayerMask.GetMask("Platform");
        maskPipoulpe = LayerMask.GetMask("Pipoulpe");
        maskIce = LayerMask.GetMask("Ice");
        maskWater = LayerMask.GetMask("Water");
        maskBoostJump = LayerMask.GetMask("BoostJumpLayer");
        rb.gravityScale = gravity;

    }

    // Update is called once per frame
    void Update()
    {
        isOnPlatform = CheckGround(maskPlatform);
        isOnPipoulpe = CheckGround(maskBoostJump);
        isOnIce = CheckGround(maskIce);
        isInWater = CheckGround(maskWater);
        //Debug.Log(isOnPipoulpe);

        if (isInWater)
        {
            //rb.velocity = new Vector2(inputX * swim_speed, inputY * swim_speed);
            //rb.AddForce(new Vector2(inputX, inputY) * swimBounce, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(inputX * swimBounceX, inputY * swimBounceY), ForceMode2D.Force);

        }
        else
        {
            rb.velocity = new Vector2(inputX * move_speed, rb.velocity.y);
        }

        if (isOnPipoulpe)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
            print("Add force");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        inputX = context.ReadValue<Vector2>().x;
        if (isInWater)
        {
            Debug.Log("move isinwater");
            inputY = context.ReadValue<Vector2>().y;
            rb.AddForce(new Vector2(inputX * swimBounceX, inputY * swimBounceY) , ForceMode2D.Impulse);
        }
        else
        {
            inputY = 0;
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        //print("début jump");
        if ((isOnPlatform)||(isOnIce))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
        
        /*
        if (isOnPipoulpe)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
            print("Add force");
        }
        //print("fin jump");
        */
    }



    void OnTriggerEnter2D(Collider2D other)     
    {
        /*
        LayerMask otherLayer = other.gameObject.layer;

        Debug.Log(other.gameObject.layer);
        Debug.Log("other layer : " + otherLayer);
        Debug.Log("mask water : " + maskWater);
       
        print(other.gameObject.layer);
        Debug.Log("collided");
        if (otherLayer == maskWater)
        {
            Debug.Log("Collided with water");
        }
        if (other.gameObject.layer == maskBoostJump)
        {
            Debug.Log("Collided with maskBoostJump");
            Debug.Log(CheckGround(maskBoostJump));
        }
        */

        if (other.gameObject.tag == "Water")
        {
            Debug.Log("enter water");
            rb.gravityScale = swimGravity;
            rb.drag = swimDrag;

        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            Debug.Log("exit water");
            rb.gravityScale = gravity;
            rb.drag = drag;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipoulpe")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }

    private bool CheckGround(LayerMask mask)
    {
        // print("Checkground");
        BoxCollider2D collision = this.GetComponent<BoxCollider2D>();
        RaycastHit2D rc = Physics2D.CircleCast(new Vector2(rb.position.x, rb.position.y), collision.size.x * transform.lossyScale.x / 2, new Vector2(0, -1), collision.size.y * transform.lossyScale.y * (1f / 2 + 1 / 10),mask);
        return rc.collider != null;
    }

    void hits (InputAction.CallbackContext context)
    {

    }
}
