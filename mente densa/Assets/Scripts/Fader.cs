using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public float time_to_fade = 1.5f; //seconds
    public float timer = 0.0f;
    bool start = false;
    bool fade = true;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if (timer < time_to_fade)
            {
                Color tmp = sr.color;

                if(fade)
                    tmp.a = Mathf.Lerp(0.0f, 1.0f, timer);
                else tmp.a = Mathf.Lerp(1.0f, 0.0f, timer);

                sr.color = tmp;
                timer += Time.deltaTime / time_to_fade;
            }
        }

        //Debug
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            start = true;
            fade = true;
            timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            start = true;
            fade = false;
            timer = 0.0f;
        }

    }

    public void StartFade(bool fade_type)
    {
        start = true;
        fade = fade_type;
    }

}
