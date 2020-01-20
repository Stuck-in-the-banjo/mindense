using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olasoleadoras : MonoBehaviour
{

    Animator anim;
    float tmp = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp += Time.deltaTime;

        float value = (Mathf.Sin(tmp) * 0.5f) + 0.5f;

        if (value > 0.9) value = 1.0f;
        if (value < 0.25) value = 0.0f;

        anim.SetFloat("wavin", value);

        Debug.Log(anim.GetFloat("wavin"));
    }
}
