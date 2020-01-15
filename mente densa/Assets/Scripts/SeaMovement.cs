using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float up_desplacement;
    public float speed = 5.0f;
    float timer = 0.0f;

    float initial_position_y;
    float final_position_y_up;
    float final_position_y_down;

    // Start is called before the first frame update
    void Start()
    {
        initial_position_y = transform.position.y;
        final_position_y_up = initial_position_y + up_desplacement;
        final_position_y_down = initial_position_y - up_desplacement;
    }

    // Update is called once per frame
    void Update()
    {
        //Change Sin to [0..1] range
        float sin_changed = (Mathf.Sin(timer) * 0.5f) + 0.5f;
        float new_y = Mathf.Lerp(initial_position_y, final_position_y_up, sin_changed);

        Vector3 tmp = transform.position;
        tmp.y = new_y;

        transform.position = tmp;

        timer += Time.deltaTime * speed;
    }

    public float GetSin()
    {
        return ((Mathf.Sin(timer) * 0.5f) + 0.5f);
    }
}
