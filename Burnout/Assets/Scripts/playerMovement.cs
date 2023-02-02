using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float force = 2000f;
    public float slowDown; 
    public float jumpForce ;
    float mx;
    public Transform feet;
    public LayerMask groundLayers;
    public  float grav;
    private float val = 0f;
    public float smoothTime;
    public Animator john;

    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        if(Input.GetButton("Jump") && !IsGrounded())
        {
            rb.gravityScale = Mathf.SmoothDamp(rb.gravityScale, grav, ref val, smoothTime);
        }
        if(Input.GetButtonUp("Jump") && !IsGrounded())
        {
            Drop();
        }
        if(IsGrounded())
        {
            rb.gravityScale = 1;
        }
        else
        {
            john.SetBool("Walking", false);
        }
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    void Drop()
    {
        rb.gravityScale = grav;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if(groundCheck != null)
        {
            rb.gravityScale = 1;
            return true;
        }
        
        return false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            if(IsGrounded())
                john.SetBool("Walking", true);
            john.transform.localScale = new Vector3(1 ,1 ,1);
            john.transform.localEulerAngles = new Vector3(0, -60, 0);
            rb.drag = 0;
            rb.AddForce(new Vector2(-force * Time.deltaTime, 0));
        }
        else if (Input.GetKey("a"))
        {
            if(IsGrounded())
                john.SetBool("Walking", true);
            john.transform.localScale = new Vector3(1 ,1 ,-1);
            john.transform.localEulerAngles = new Vector3(0, -120, 0);
            rb.drag = 0;
            rb.AddForce(new Vector2(force * Time.deltaTime, 0));
        }
        else
        {
            john.SetBool("Walking", false);
            rb.drag = slowDown;
            
        }
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 15);
    }
}
