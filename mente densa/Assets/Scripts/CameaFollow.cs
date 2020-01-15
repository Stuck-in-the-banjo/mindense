using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollow : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        if (player.transform.position.x > 0.0f)
            Follow();
    }

    void Follow()
    {
        float distance_to_move = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(distance_to_move) < 0.1f)
            distance_to_move = 0.0f;

        transform.Translate(distance_to_move * 0.05f, 0.0f, 0.0f);
    }
}
