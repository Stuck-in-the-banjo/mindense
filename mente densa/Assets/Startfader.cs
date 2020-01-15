using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startfader : MonoBehaviour
{
    public Fader fader_game_object;

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
        Debug.Log("ENTER");
        fader_game_object.StartFade(true, 2.0f);
    }


}
