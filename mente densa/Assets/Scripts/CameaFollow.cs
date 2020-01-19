using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Rigidbody2D tmp;

    public float smooth_speed;

    public float follow_point;
    public float un_follow_point;
    public bool follow_y = false;
    public float y_offsset = 0.0f;

    Vector3 new_pos;

    private void Start()
    {
        new_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    private void FixedUpdate()
    {
        if (player.transform.position.x > follow_point && player.transform.position.x < un_follow_point)
        {
            float desired_pos = player.transform.position.x;
            float smooth = Mathf.Lerp(transform.position.x, desired_pos, smooth_speed * Time.deltaTime);

            new_pos.x = smooth * speed;

          
            

            transform.position = new_pos;
        }


        if (follow_y)
        {
            new_pos.y = player.transform.position.y + y_offsset;
            transform.position = new_pos;
        }
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {

    }


    void Follow()
    {
        float distance_to_move = tmp.position.x - transform.position.x;

        if (Mathf.Abs(distance_to_move) > 1.0)
        {
            distance_to_move = Mathf.Abs(distance_to_move) / distance_to_move;
        }

        Debug.Log(distance_to_move);

        //if (Mathf.Abs(distance_to_move) < 0.1f)
        //    distance_to_move = 0.0f;

        transform.Translate(distance_to_move * Time.deltaTime * speed, 0.0f, 0.0f);
    }

}
