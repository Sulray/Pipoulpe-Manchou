using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ManchouMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputX;
    [SerializeField] private float move_speed;
    [SerializeField] private float jump_speed;

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

    }

    // Update is called once per frame
    void Update()
    {
        isOnPlatform = CheckGround(maskPlatform);
        isOnPipoulpe = CheckGround(maskBoostJump);
        isOnIce = CheckGround(maskIce);
        isInWater = CheckGround(maskWater);
        //print(isOnPipoulpe);

        rb.velocity = new Vector2(inputX * move_speed, rb.velocity.y);
        //rb.gravityScale = 0; to disable gravity
    }

    public void Move(InputAction.CallbackContext context)
    {

        inputX = context.ReadValue<Vector2>().x;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        //print("début jump");
        if (isOnPlatform)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
        if (isOnPipoulpe)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
            print("Add force");
        }
        //print("fin jump");
    }


    private bool CheckGround(LayerMask mask)
    {
        // print("Checkground");
        BoxCollider2D collision = this.GetComponent<BoxCollider2D>();
        RaycastHit2D rc = Physics2D.CircleCast(new Vector2(rb.position.x, rb.position.y), collision.size.x * transform.lossyScale.x / 2, new Vector2(0, -1), collision.size.y * transform.lossyScale.y * (1f / 2 + 1 / 10), mask);
        return rc.collider != null;
    }
}
