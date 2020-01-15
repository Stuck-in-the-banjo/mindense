using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWavinState : MonoBehaviour
{
    public GameObject waver;
    public float sin_pos = 0.0f;

    Animator anim;
    SeaMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = waver.GetComponent<SeaMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("wavin", movement.GetSin() * 0.5f);
    }
}
