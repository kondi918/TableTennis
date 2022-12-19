using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_palette_left : MonoBehaviour
{
    private GameObject ball;
    private Vector3 ball_position;
    private Vector3 palette_position;
    void Start()
    {
        ball = GameObject.Find("ball");
    }
    private void checking()
    {
        ball_position = ball.transform.position;
        palette_position = transform.position;
    }
    private void moving()
    {
        if (ball_position.x < -7)
        {
            if (ball_position.y - palette_position.y < -0.7f || ball_position.y - palette_position.y > 0.7f)
            {
                if (palette_position.y < ball_position.y && palette_position.y < 2.4f)
                {
                    palette_position.y += 0.25f;
                }
                else if (palette_position.y > ball_position.y && palette_position.y > -6f)
                {
                    palette_position.y -= 0.25f;
                }
                transform.position = palette_position;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checking();
        moving();
    }
}
