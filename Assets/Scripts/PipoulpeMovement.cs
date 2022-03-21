using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PipoulpeMovement : MonoBehaviour
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

}
 