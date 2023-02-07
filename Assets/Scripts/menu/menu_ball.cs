using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_ball : MonoBehaviour
{
    private Rigidbody2D ball;
    private Vector3 ball_velocity_zmienna;
    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Rigidbody2D>();
        ball.velocity = new Vector3(-10, 0, 0);
        ball_velocity_zmienna = ball.velocity;
    }
    private float rotate(GameObject palette)
    {
        return (palette.transform.position.y - gameObject.transform.position.y) * -8;

    }
    private void checking()
    {
        ball_velocity_zmienna = ball.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("palette_left") || collision.gameObject == GameObject.Find("palette_right"))
        {
            ball_velocity_zmienna.y = rotate(collision.gameObject);
            ball_velocity_zmienna.x *= -1;
            if (ball_velocity_zmienna.x < 0)
            {
                if (ball_velocity_zmienna.x > -9)
                {
                    ball_velocity_zmienna.x = -10;
                }
            }
            else
            {
                if (ball_velocity_zmienna.x < 9)
                {
                    ball_velocity_zmienna.x = 10;
                }
            }
            ball.velocity = ball_velocity_zmienna;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checking();
    }
}
