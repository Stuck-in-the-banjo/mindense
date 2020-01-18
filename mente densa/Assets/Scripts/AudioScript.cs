using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public GameObject teleport_no_light;
    Vector3 initial_pos;

    float timer = 0.0f;
    float mini_timer = 0.0f;

    public float light_flickering_time_0;
    public float light_flickering_time_1;
    public float light_flickering_time_2;

    bool lol = true;
    int fliker = 0;


    int interaction = 0;
    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction == 0)
            DoFlikerin0();

        if (interaction == 1)
            DoFlikerin1();
    }

    void DoFlikerin1()
    {
        Debug.Log("Doin 2 fliker");
        if (mini_timer > 0.05f)
        {
            if(lol)
                transform.position = initial_pos;
            else transform.position = teleport_no_light.transform.position;

            lol = !lol;
            mini_timer = 0.0f;
            fliker++;
        } else mini_timer += Time.deltaTime;

        if (fliker == 10)
        {
            interaction = 2;
            transform.position = teleport_no_light.transform.position;
            mini_timer = 0.0f;
        }
    }

    void DoFlikerin0()
    {
        if (mini_timer > 1.5f)
        {
            if (!lol)
                transform.position = initial_pos;
            else transform.position = teleport_no_light.transform.position;

            lol = !lol;
            mini_timer = 0.0f;
            fliker++;
        }
        else mini_timer += Time.deltaTime;

        if(fliker == 3)
        {
            interaction = 1;
            transform.position = initial_pos;
            fliker = 0;
            mini_timer = 0.0f;
            lol = true;
        }
    }
}
