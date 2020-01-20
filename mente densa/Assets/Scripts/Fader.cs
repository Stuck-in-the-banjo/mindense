using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum FADE_STATE
{
    FADE,
    LOAD,
    IDLE
}

public class Fader : MonoBehaviour
{
    public float time_to_fade = 1.5f; //seconds
    public float timer = 0.0f;
    bool fade = true;

    SpriteRenderer sr;

    public float time_to_load_scene = -1;
    float load_timer = 0.0f;
    public int scene_to_load;

    public FADE_STATE state = FADE_STATE.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case FADE_STATE.FADE:

                if (timer < time_to_fade)
                {
                    Color tmp = sr.color;

                    float x = timer / time_to_fade;

                    if (!fade)
                        tmp.a = Mathf.Lerp(0.0f, 1.0f, x);
                    else tmp.a = Mathf.Lerp(1.0f, 0.0f, x);

                    sr.color = tmp;
                    timer += Time.deltaTime;

                }
                

                break;

            
        }


       

    }

    public void StartFade(bool fade_type, float fade_time, float new_time_to_load_scene)
    {
        state = FADE_STATE.FADE;
        fade = fade_type;

        timer = 0.0f;
        load_timer = 0.0f;

        time_to_fade = fade_time;
        time_to_load_scene = new_time_to_load_scene;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(scene_to_load);
    }
}
