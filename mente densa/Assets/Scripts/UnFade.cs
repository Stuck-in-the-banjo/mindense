using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFade : MonoBehaviour
{
    float timer = 0.0f;
    public float time_to_fade;

    float start_timer = 0.0f;
    public float time_to_start_fade;

    public bool start_fade = true;

    SpriteRenderer sr;
    public bool unfade = true;

    public bool restart = false;
    int tmp = 0;

    public float time_to_restart;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start_fade)
            return;

        if (start_timer > time_to_start_fade)
        {
            if (timer < time_to_fade)
            {
                DoFade();

            }
            else
            {
                if (restart && tmp == 0)
                {
                    timer = 0;
                    start_timer = 0.0f;
                    time_to_start_fade = time_to_restart;
                    unfade = !unfade;
                    tmp++;
                }
            }
        }

        start_timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        start_fade = true;
    }

    void DoFade()
    {
        Color tmp = sr.color;

        float x = timer / time_to_fade;

        if (unfade)
            tmp.a = Mathf.Lerp(0.0f, 1.0f, x);
        else tmp.a = Mathf.Lerp(1.0f, 0.0f, x);


        sr.color = tmp;
        timer += Time.deltaTime;
    }
}
