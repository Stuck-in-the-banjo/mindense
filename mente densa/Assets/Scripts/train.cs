using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    bool enable_moving = false;

    public float acceleration;
    public float max_speed;

    float current_speed = 0.0f;

    public GameObject player;
    public GameObject camera;

    Vector3 player_initial_pos;
    Vector3 train_initial_pos;
    Vector3 camera_initial_pos;

    public bool is_deadly = false;

    // Start is called before the first frame update
    void Start()
    {
        player_initial_pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        train_initial_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        camera_initial_pos = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (enable_moving)
            Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMovin()
    {
        enable_moving = true;
    }

    void Move()
    {
        current_speed += acceleration;
        Mathf.Clamp(current_speed, 0.0f, max_speed);

        transform.Translate( current_speed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!is_deadly)
        {
            Debug.Log("He chokao bro");
            player.transform.position = player_initial_pos;
            transform.position = train_initial_pos;
            camera.transform.position = camera_initial_pos;

            camera.GetComponent<CameaFollow>().new_pos = camera_initial_pos;

            current_speed = 0.0f;
        }
    }
}
