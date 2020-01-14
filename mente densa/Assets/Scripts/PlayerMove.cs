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

    public bool enable_move = true;
    public bool enable_jump = true;
    public bool enable_action = true;

    bool using_pc = false;

    // Start is called before the first frame update
    void Start()
    {

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

    }
}