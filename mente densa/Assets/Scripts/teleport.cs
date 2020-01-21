using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleport_pos;

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
        Debug.Log("col");
        collision.gameObject.GetComponent<Collider2D>().isTrigger = false;
        collision.gameObject.transform.position = teleport_pos.position;
    }
}
