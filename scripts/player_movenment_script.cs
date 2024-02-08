using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player_movenment_script : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float movingSpeed = 2f;
    [SerializeField] private float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xdir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xdir * movingSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))

        {

            if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
            {

            }
            else
            {
                rb.velocity = new Vector2(100, jumpForce);

            }

        }

    }
}
