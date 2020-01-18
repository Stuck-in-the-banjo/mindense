using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Rigidbody2D tmp;

    public float smooth_speed;

    private void FixedUpdate()
    {  
        if (player.transform.position.x > 1.0f && player.transform.position.x < 40.0f)
        {
            float desired_pos = player.transform.position.x;
            float smooth = Mathf.Lerp(transform.position.x, desired_pos, smooth_speed * Time.deltaTime);
            transform.position = new Vector3(smooth * speed, transform.position.y, transform.position.z);
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
