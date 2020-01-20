using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Movement stuff
    Rigidbody2D rb;
    public float deceleration = 1.0f;
    public float acceleration = 2.0f;
    public float max_speed = 5.0f;
    float current_speed = 0.0f;
    public bool enable_move = true;

    //Jump Stuff
    public bool enable_jump = true;
    public float jump_impulse = 5.0f;

    bool can_jump = true;

    //action stuff
    public bool enable_action = true;
    float throw_impulse = 5.0f;
    public GameObject rock;
    int throwed = 0;

    public bool patatero = true;

    //animator
    Animator anim;
    bool boolaso = false;
    SpriteRenderer sr;

    public bool marronero = false;
    bool giga_marronero = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enable_jump)
        {
            HandleJump();

           
        }

        HandleJumpAnimations();

        if (boolaso)
            anim.SetBool("Throw", false);

        if (enable_action && throwed < 3)
            ThrowRock();
    }

    private void FixedUpdate()
    {
        if (enable_move)
            HandleAxis();

    }

    void HandleAxis()
    {       
        float axis = Input.GetAxisRaw("Horizontal");

        HandleRunAnimation(axis);

        current_speed += axis * acceleration;
        current_speed = Mathf.Clamp(current_speed, -max_speed, max_speed);

        transform.Translate(current_speed * Time.deltaTime, 0.0f, 0.0f);



        //Decelerate
        if (axis == 0.0f)
        {
            if (current_speed > 0.0f)
            {
                current_speed -= deceleration;
                current_speed = Mathf.Clamp(current_speed, 0.0f, max_speed);
            }

            if (current_speed < 0.0f)
            {
                current_speed += deceleration;
                current_speed = Mathf.Clamp(current_speed, -max_speed, 0.0f);
            }
            
        }

        
    }

    void HandleJump()
    {
      if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && can_jump)
      {
          Debug.Log("Jump");

            can_jump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0.0f, jump_impulse), ForceMode2D.Impulse);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        can_jump = true;
        Debug.Log("COLISION tigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        can_jump = false;
    }

    void ThrowRock()
    {

       

        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
           

            if (marronero)
            {
                if(giga_marronero)
                {
                    GameObject new_rock = Instantiate(rock, transform.position, Quaternion.identity);
                    new_rock.GetComponent<RockMovement>().AddInitialImpulse(20.0f);
                    giga_marronero = false;
                    boolaso = true;
                    anim.SetBool("Throw", true);
                }
                
            }
            else
            {
                GameObject new_rock = Instantiate(rock, transform.position, Quaternion.identity);
                new_rock.GetComponent<RockMovement>().AddInitialImpulse(throw_impulse);
                throw_impulse += 8;
                throwed++;
                boolaso = true;
                anim.SetBool("Throw", true);

            }
            
        }

       
    }

    void HandleJumpAnimations()
    {
        if (rb.velocity.y == 0.0f)
            anim.SetBool("fallin", false);

        if (rb.velocity.y > 0.0f)
            anim.SetBool("jumpin", true);

        if (rb.velocity.y < 0.0f)
        {
            anim.SetBool("jumpin", false);
            anim.SetBool("fallin", true);
        }

        if(!patatero)
        {
            anim.SetBool("jumpin", false);
            anim.SetBool("fallin", false);
        }
    }

    void HandleRunAnimation(float value)
    {
        if (value != 0.0f)
            anim.SetBool("movin", true);
        else anim.SetBool("movin", false);

        if (value > 0.0f)
            sr.flipX = false;

        if (value < 0.0f)
            sr.flipX = true;
    }
}

