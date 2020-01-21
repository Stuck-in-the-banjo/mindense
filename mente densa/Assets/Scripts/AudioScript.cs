using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AudioScript : MonoBehaviour
{
    public GameObject teleport_no_light;
    public GameObject collider_to_delete;
    public train Train_gameobject;
    public GameObject light;
   

    Vector3 initial_pos;

    float timer = 0.0f;
    float mini_timer = 0.0f;

    bool lol = true;
    int fliker = 0;

    bool init_pos = false;

    int interaction = 0;

    //Post Process
    public PostProcessVolume volume;
    Vignette viñeteado;

    //Audio
    AudioSource light_audio;
    float audio_timer = 0.0f;
    bool audioaso = true;
    int audio_state = 0;
    public AudioSource footsteps;
    public AudioSource puerta;
    public AudioSource interruptor;

    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position;

        volume.profile.TryGetSettings(out viñeteado);
        light_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction == 0)
            DoFlikerin0();

        if (interaction == 1)
            DoFlikerin1();

        if (interaction == 2)
            DoAudios();

        if (interaction == 3)
            DoTrain();
    }

    void DoFlikerin1()
    {
        Debug.Log("Doin 2 fliker");
        if (mini_timer > 0.05f)
        {
            if (lol)
            {
                transform.position = initial_pos;
                light_audio.UnPause();
            }
            else
            {
                transform.position = teleport_no_light.transform.position;
                light_audio.Pause();
            }

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
            {
                transform.position = initial_pos;
                light_audio.UnPause();
            }
            else
            {
                transform.position = teleport_no_light.transform.position;
                light_audio.Pause();
            }

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

    void DoAudios()
    {
        if(audio_state == 0)
        {
            if (audioaso)
            {
                light_audio.Pause();
                puerta.Play();
                audioaso = false;
            }

            if (audio_timer >= puerta.clip.length)
            {
                footsteps.Play();
                audio_state++;
                audio_timer = 0.0f;
            }
        }

        if(audio_state == 1)
        {
            if (audio_timer >= 7.0f)
            {
                footsteps.Pause();
                interruptor.Play();
                audio_timer = 0.0f;
                audio_state++;
            }
            else
            {
                float y = (1 / 7.0f) * audio_timer;
                float x = -((y * 2) - 1);

                Debug.Log(y);

                footsteps.panStereo = x;
            }
        }
        
        if(audio_state == 2)
        {
            if(audio_timer >= interruptor.clip.length)
                interaction = 3;
        }
        

        audio_timer += Time.deltaTime;
        //interaction = 3;
    }

    void DoTrain()
    {
       
        if (!init_pos)
        {
            GetComponent<CameaFollow>().follow_y = true;
            transform.position = initial_pos;
            init_pos = true;
            GameObject.Destroy(collider_to_delete);
            Train_gameobject.StartMovin();
            light.active = false;
            viñeteado.intensity.value = 0.26f;
        }
    }
}
