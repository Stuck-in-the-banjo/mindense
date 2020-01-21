using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    public CameaFollow camera_follow_script;
    public PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.enable_action = false;
        player.enable_jump = false;
        player.enable_move = false;
        camera_follow_script.y_offsset = 3.0f;
        camera_follow_script.gameObject.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
    }
}
