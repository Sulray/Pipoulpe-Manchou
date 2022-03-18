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

    private bool isGrounded = true;
    private bool isOnIce = false;
    private bool isInWater = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(inputX * move_speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {

        inputX = context.ReadValue<Vector2>().x;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        print("début jump");
        if (CheckGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
        print("fin jump");
    }

    private bool CheckGround()
    {
        print("Checkground");
        LayerMask mask = LayerMask.GetMask("Platform");
        BoxCollider2D collision = this.GetComponent<BoxCollider2D>();
        RaycastHit2D rc = Physics2D.CircleCast(new Vector2(rb.position.x, rb.position.y), collision.size.x * transform.lossyScale.x / 2, new Vector2(0, -1), collision.size.y * transform.lossyScale.y * (1f / 2 + 1 / 5), mask);
        print(rc.collider != null);
        return rc.collider != null;
    }
}
