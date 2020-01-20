using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera_to_pos : MonoBehaviour
{
    public GameObject camera;

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
        camera.transform.Translate(0.0f, 13.0f, 0.0f);
        Debug.Log("colision");
    }
}
