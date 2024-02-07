using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player_movenment_script : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jump);
        }

        rb.velocity = new Vector2(xDir * speed, 0f);

    }
}
