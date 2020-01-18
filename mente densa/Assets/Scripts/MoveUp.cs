using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    bool start_moving = false;
    public float speed = 5.0f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    Vector2 move;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        move = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (start_moving)
        {
            Move();
            Draw();

            if (timer >= 1.0f)
                start_moving = false;

            timer += Time.deltaTime * (1.0f/speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        start_moving = true;
        collision.gameObject.GetComponent<PlayerMove>().patatero = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerMove>().patatero = true;
    }

    void Move()
    {
        move.x = transform.position.x;
        move.y = Mathf.Lerp(transform.position.y, -1.75f, timer);

        rb.MovePosition(move);
    }

    void Draw()
    {
        Color tmp = sr.color;
        tmp.a = Mathf.Lerp(0.0f, 0.5f, timer * speed);
        sr.color = tmp;
    }

}
