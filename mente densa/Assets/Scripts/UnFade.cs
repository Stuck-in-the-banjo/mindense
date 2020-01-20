using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFade : MonoBehaviour
{
    float timer = 0.0f;
    public float time_to_fade;

    float start_timer = 0.0f;
    public float time_to_start_fade;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (start_timer > time_to_start_fade)
        {
            if (timer < time_to_fade)
            {
                Color tmp = sr.color;

                float x = timer / time_to_fade;

             
                tmp.a = Mathf.Lerp(0.0f, 1.0f, x);
                

                sr.color = tmp;
                timer += Time.deltaTime;
            }
            else timer += Time.deltaTime;
        }

        start_timer += Time.deltaTime;
    }
}
