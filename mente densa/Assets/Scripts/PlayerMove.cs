using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Movement stuff
    public float deceleration = 1.0f;
    public float acceleration = 2.0f;
    public float max_speed = 5.0f;
    float current_speed = 0.0f;

    Rigidbody2D rb;

    //Jump Stuff
    public float jump_impulse = 5.0f;
    float current_impulse;

    bool can_jump = true;


    public bool enable_move = true;
    public bool enable_jump = true;
    public bool enable_action = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {


      

        if (enable_jump)
        {
            HandleJump();

        }
    }

    private void FixedUpdate()
    {
        if (enable_move)
            HandleAxis();

    }

    void HandleAxis()
    {       
        float axis = Input.GetAxisRaw("Horizontal");

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

   //private void OnTriggerStay2D(Collider2D collision)
   //{
   //    can_jump = true;
   //    Debug.Log("COLISION tigger");
   //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        can_jump = true;
        Debug.Log("COLISION tigger");
    }
}

//public class PlayerMove : MonoBehaviour
//{
//    public float speed;
//
//    Rigidbody2D rb;
//
//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }
//
//    private void FixedUpdate()
//    {
//        float axis = Input.GetAxisRaw("Horizontal");
//        rb.MovePosition(transform.position + transform.TransformDirection(axis, 0, 0) * Time.deltaTime * speed);
//    }
//}