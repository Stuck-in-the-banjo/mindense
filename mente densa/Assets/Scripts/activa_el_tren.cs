﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activa_el_tren : MonoBehaviour
{
    public train train_game_object;
    public GameObject mask;

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
        train_game_object.StartMovin();
        mask.active = false;
    }
}
