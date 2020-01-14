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

    //Jump Stuff
    public float gravity = 1.0f;
    public float jump_impulse = 5.0f;
    public float current_impulse = 0.0f;
    public float current_gravity = 0.0f;
    public bool can_jump = true;

    public bool enable_move = true;
    public bool enable_jump = true;
    public bool enable_action = true;

    float test;

    bool using_pc = false;

    // Start is called before the first frame update
    void Start()
    {
        test = jump_impulse * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable_move)
            HandleAxis();

        if(enable_jump)
            HandleJump();
    }

    void HandleAxis()
    {       
        float axis = Input.GetAxisRaw("Horizontal");

        current_speed += axis * acceleration;
        current_speed = Mathf.Clamp(current_speed, -max_speed, max_speed);

        transform.Translate(current_speed * Time.deltaTime, 0.0f, 0.0f);

        //Decelerate
        if(axis == 0.0f)
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
            current_gravity = gravity;
            current_impulse = test;
            can_jump = false;
        }

        current_impulse -= current_gravity * Time.deltaTime;


        transform.Translate(0.0f, current_impulse, 0.0f);

        if (transform.position.y < 0.0f)
        {
            Vector3 position_y_0 = transform.position;
            position_y_0.y = 0.0f;

            transform.Translate(position_y_0 - transform.position);
            current_impulse = 0.0f;
            current_gravity = 0.0f;
            can_jump = true;
        }
    }
}