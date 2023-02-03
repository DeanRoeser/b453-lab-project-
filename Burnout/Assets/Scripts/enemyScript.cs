using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float maxAgro;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb;
    bool agro;
    public Animator cat;
    public Transform feet;
    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer =Vector2.Distance(transform.position, player.position);
        rb.gravityScale = 8;

        
        if(distToPlayer < agroRange)
        {
            agro = true;
        }
        else if(distToPlayer > maxAgro)
        {
            agro = false;
        }

        if(agro == true)
        {
            Chase();
        }
        else
        {
            cat.SetBool("Running", false);
            StopChasing();
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck != null)
        {
            rb.gravityScale = 8;
            return true;
        }

        return false;
    }

    void Chase()
    {
        if(transform.position.x < player.position.x)
        {
            //enemy on the left, move right
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            if (IsGrounded())
            {
                cat.SetBool("Running", true);
                Debug.Log("did grounded");
            }
            cat.SetBool("Running", true);
            cat.transform.localScale = new Vector3(1, 1, -1);
            cat.transform.localEulerAngles = new Vector3(0, -120, 0);
            
        }
        else
        {
            //enemy is to the right, move left
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            if (IsGrounded())
            {
                cat.SetBool("Running", true);
                Debug.Log("did grounded");
            }
            cat.SetBool("Running", true);
            cat.transform.localScale = new Vector3(1, 1, 1);
            cat.transform.localEulerAngles = new Vector3(0, 60, 0);
                    }
    }

    void StopChasing()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
