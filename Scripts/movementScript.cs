using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7.5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpForce = 7.5f;

    public float rememberGroundedFor = 0.1f;
    float lastTimeGrounded;

    bool isOnGround = false;
    public Transform groundChecker; //Te tiek pielikts objekts, kas atrodas tieshi zem speletaja, kas tiek izmantots lia parbauditu vai ir uz platformas
    public float CheckGroundR;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Move();
        isGrounded();
        Jump();
        BetterJump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        float step = x * speed;

        rb.velocity = new Vector2(step, rb.velocity.y);
    }

    
    void Jump() //Ja lec un ja ir uz zemes vai nesen bija uz zemes
    {
        if (Input.GetButtonDown("Jump") && (isOnGround || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    

    void BetterJump() //Padara leksanu labaku, kritot tiek palielinata gravitacija, lai atrak krit, bet lecot ja netiek tureta poga, tad lec zemak
    {
        if (rb.velocity.y < 0) //if we fall
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime; //time.deltatime ir lai atjaunotu katra frame
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // if we are jumping up, we need to check if we hold the button
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime; //and I amm not holding it
        }
    }

    void isGrounded() //parbauda vai ir pie zemes noteikta radiusa
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, CheckGroundR, groundLayer);

        if (collider != null)
        {
            isOnGround = true;
        }
        else
        {
            if (isOnGround)
            {
                lastTimeGrounded = Time.time;
            }
            isOnGround = false;
        }
    }

}
