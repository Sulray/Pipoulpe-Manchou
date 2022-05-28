using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PipoulpeMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputX;
    private float inputY;

    [SerializeField] private float move_speed;
    [SerializeField] private float swimBounceX;
    [SerializeField] private float swimBounceY;
    [SerializeField] private float gravity;
    [SerializeField] private float swimGravity;
    [SerializeField] private float drag;
    [SerializeField] private float swimDrag;
    [SerializeField] private float maxSpeedGround;
    [SerializeField] private float maxSpeedWater;
    [SerializeField] private float maxSpeedIce;
    [SerializeField] private float maxSpeedAir;



    LayerMask maskPlatform;
    LayerMask maskIce;
    LayerMask maskWater;

    private bool isOnPlatform = true;
    private bool isOnIce = false;
    private bool isInWater = false;

    Vector3 characterScale;
    float initCharacterScaleX;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        maskPlatform = LayerMask.GetMask("Platform");
        maskIce = LayerMask.GetMask("Ice");
        maskWater = LayerMask.GetMask("Water");
        rb.gravityScale = gravity;

    }

    // Update is called once per frame
    void Update()
    {

        isOnPlatform = CheckGround(maskPlatform);
        isOnIce = CheckGround(maskIce);
        isInWater = CheckGround(maskWater);
        //Debug.Log(isOnPipoulpe);


        characterScale = transform.localScale;
        if (inputX < 0)
        {
            characterScale.x = initCharacterScaleX;
        }
        else if (inputX > 0)
        {
            characterScale.x = -initCharacterScaleX;
        }
        transform.localScale = characterScale;


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


        Debug.Log(rb.velocity.x);
        float maxSpeedX = maxSpeedGround;
        float maxSpeedY = maxSpeedAir;
        if (isInWater)
        {
            maxSpeedX = maxSpeedWater;
            maxSpeedY = maxSpeedWater;
        }
        if (isOnIce)
        {
            maxSpeedX = maxSpeedIce;
        }
        if (isOnPlatform)
        {
            maxSpeedX = maxSpeedGround;
        }
        if (inputX < 0)
        {
            rb.velocity = new Vector2(Mathf.Max(-maxSpeedX, rb.velocity.x), Mathf.Min(maxSpeedY,rb.velocity.y));
        }
        else if (inputX > 0)
        {
            rb.velocity = new Vector2(Mathf.Min(maxSpeedX, rb.velocity.x), Mathf.Min(maxSpeedY, rb.velocity.y));
        }



    }

    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log("pipoulpe move");

        inputX = context.ReadValue<Vector2>().x;
        if (isInWater)
        {
            Debug.Log("move isinwater");
            inputY = context.ReadValue<Vector2>().y;
            rb.AddForce(new Vector2(inputX * swimBounceX, inputY * swimBounceY), ForceMode2D.Impulse);
        }
        else
        {
            inputY = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

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
        if (collision.gameObject.tag == "Manchou")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }

        private bool CheckGround(LayerMask mask)
    {
        // print("Checkground");
        BoxCollider2D collision = this.GetComponent<BoxCollider2D>();
        RaycastHit2D rc = Physics2D.CircleCast(new Vector2(rb.position.x, rb.position.y), collision.size.x * initCharacterScaleX / 2, new Vector2(0, -1), collision.size.y * transform.lossyScale.y * (1f / 2 + 1 / 10), mask);
        return rc.collider != null;
    }

}
