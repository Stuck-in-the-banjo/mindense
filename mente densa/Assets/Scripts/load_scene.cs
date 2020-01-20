using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour
{
    public int scene_to_load;

    public float time_to_load;
    float timer = 0.0f;
    bool start_load = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start_load)
            return;

        if (timer > time_to_load)
            SceneManager.LoadScene(scene_to_load);
        else timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        start_load = true;
    }
}
