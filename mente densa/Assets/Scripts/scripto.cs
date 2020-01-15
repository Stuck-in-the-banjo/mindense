using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scripto : MonoBehaviour
{
    public SpriteRenderer sr;
    public float time_load_scene = 2.0f;
    float timer = 0.0f;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if (timer > time_load_scene)
                SceneManager.LoadScene(0);
            else timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color tmp = sr.color;
        tmp.a = 1.0f;
        sr.color = tmp;
    }
}
