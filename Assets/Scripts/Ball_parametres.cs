using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball_parametres : MonoBehaviour
{
    private Rigidbody2D ball;
    private Vector3 ball_velocity_zmienna;
    private float ball_velocity_y;
    private Text count_text;
    private double starting_timer;
    private bool game_start = false;

    private bool starting_count()
    {
        if(starting_timer > 3)
        {
            GameObject.Find("Counting").SetActive(false);
            ball.velocity = new Vector3(0, Game_Settings.ball_speed, 0);
            ball_velocity_zmienna = ball.velocity;
            ball_velocity_y = Game_Settings.ball_speed;
            return true;
        } 
        else if(starting_timer > 2)
        {
            count_text.text = "1";
            starting_timer+= Time.deltaTime;
        }
        else if(starting_timer > 1) 
        {
            count_text.text = "2";
            starting_timer += Time.deltaTime;
        }
        else
        {
            count_text.text = "3";
            starting_timer+= Time.deltaTime; 
        }
        return false;
    }
    void Start()
    {
        count_text = GameObject.Find("Counting").GetComponent<Text>();
        ball = GameObject.Find("ball").GetComponent<Rigidbody2D>();
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
        if (!game_start)
        {
            game_start = starting_count();
        }
        else
        { 

        }
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
