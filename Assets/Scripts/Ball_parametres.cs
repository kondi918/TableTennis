using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_parametres : MonoBehaviour
{
    private Rigidbody2D ball;
    private Vector3 ball_velocity_zmienna;
    private float ball_velocity_y;
    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Rigidbody2D>();
        ball.velocity = new Vector3(0, Game_Settings.ball_speed, 0);
        ball_velocity_zmienna = ball.velocity;
        ball_velocity_y = Game_Settings.ball_speed;
    }
    float rotate(GameObject palette)
    {
        return (palette.transform.position.x - gameObject.transform.position.x) * -10;

    }
    void checking()
    {
        if(ball.velocity.y != ball_velocity_y)
        {
            ball_velocity_zmienna.y = ball_velocity_y;
            ball.velocity = ball_velocity_zmienna;
        }
    }
    void adding_ball_speed()
    {
        ball_velocity_zmienna.y *= -1;
        if(ball_velocity_zmienna.y < 0)
        {
            ball_velocity_zmienna.y -= 0.1f;
        }
        else
        {
            ball_velocity_zmienna.y += 0.1f;
        }
    }
    void FixedUpdate()
    {
        ball_velocity_zmienna = ball.velocity;
        checking();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("palette") || collision.gameObject == GameObject.Find("palette_2"))
        {
            adding_ball_speed();
            ball_velocity_zmienna.x = rotate(collision.gameObject);
            ball.velocity = ball_velocity_zmienna;
            ball_velocity_y = ball_velocity_zmienna.y;
        }     
        if(collision.gameObject == GameObject.Find("goal_up"))
        {
            Score.add_score_player_2();
            SceneManager.LoadScene("Game");
        }
        else if(collision.gameObject == GameObject.Find("goal_down"))
        {
            Score.add_score_player_1();
            SceneManager.LoadScene("Game");
        }
    }
}
