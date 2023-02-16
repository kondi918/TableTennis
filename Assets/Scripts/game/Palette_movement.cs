using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Palette_movement : MonoBehaviour
{
    private GameObject palette_1;
    private GameObject palette_2;
    private GameObject ball;
    private Vector2 balL_velocity;
    private int medium_lvl_random_parametre;
    private Neuron neuron = new Neuron();
    float timer = 0;
    float AI_movement_timer = 0;
    double log_palette_x = 0;
    double log_ball_x = 0;
    int AI_direction = -1; // -1 oznacza lewo, 1 oznacza prawo
    StreamWriter mistakes_txt;
    StreamWriter log_txt;
    List<double> AI_data = new List<double>();
    // Start is called before the first frame update
    void Start()
    {
        palette_1 = GameObject.Find("palette");
        palette_2 = GameObject.Find("palette_2");
        ball = GameObject.Find("ball");
        medium_lvl_random_parametre = UnityEngine.Random.Range(0, 100);
        balL_velocity = ball.GetComponent<Rigidbody2D>().velocity;
        palette_1.GetComponent<SpriteRenderer>().sprite = GameObject.Find("options_palette_left").GetComponent<SpriteRenderer>().sprite;
        palette_2.GetComponent<SpriteRenderer>().sprite = GameObject.Find("options_palette_right").GetComponent<SpriteRenderer>().sprite;
        if(Game_Settings.difficulty == "AI")
        {
            get_files();
        }
    }
    void OnDisable()
    {
        if(Game_Settings.difficulty == "AI")
        {
            mistakes_txt.WriteLineAsync("-----------------------------------------------------");
            log_txt.WriteLineAsync("-----------------------------------------------------");
            mistakes_txt.Close();
            log_txt.Close();
        }
    }
    private void get_files()
    {
        mistakes_txt = new StreamWriter(Application.streamingAssetsPath+"/last_mistakes.txt",true);
        log_txt = new StreamWriter(Application.streamingAssetsPath + "/log.txt", true);
        mistakes_txt.WriteLineAsync("\nData rozpoczêcia gry: " + DateTime.Now);
        log_txt.WriteLineAsync("\nData rozpoczêcia logow: " + DateTime.Now);
    }
    private Vector2 get_ball_position()
    {
        return ball.transform.position;
    }
    private Vector2 get_peltte_position()
    {
        return palette_2.transform.position;
    }
    private float get_ball_distance()
    {
        return palette_2.transform.position.y - ball.transform.position.y;
    }
    private float get_x_distance()
    {
        return palette_2.transform.position.x - ball.transform.position.x;
    }
    private void move_to_center()
    {
        if(get_peltte_position().x + 3.8f > 0.8f)
        {
            palette_2.transform.position -= new Vector3(0.2f, 0, 0);
        }
        else if(get_peltte_position().x + 3.8f < -0.8f)
        {
            palette_2.transform.position += new Vector3(0.2f, 0, 0);
        }
    }
    private void player_1_movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && palette_1.transform.position.x > -7.5f)
        {
            palette_1.transform.position -= new Vector3(0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && palette_1.transform.position.x < -0.3f)
        {
            palette_1.transform.position += new Vector3(0.2f, 0, 0);
        }
    }
    private void player_2_movement()
    {
        if (Input.GetKey(KeyCode.D) && palette_2.transform.position.x < -0.3f)
        {
            palette_2.transform.position += new Vector3(0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && palette_2.transform.position.x > -7.5f)
        {
            palette_2.transform.position -= new Vector3(0.2f, 0, 0);
        }
    }
    private void computer_easy_movement()
    {
        if (get_x_distance() >= 0.5f)
        {
            palette_2.transform.position -= new Vector3(0.1f, 0, 0);
        }
        else if (get_x_distance() <= -0.5f)
        {
            palette_2.transform.position += new Vector3(0.1f, 0, 0);
        }
    }
    private void computer_medium_movement()
    {
        if (medium_lvl_random_parametre < 2)
        {
            int random_site = UnityEngine.Random.Range(0, 100);
            if (get_peltte_position().x > -7.5 && get_peltte_position().x < -0.5)
            {
                if (random_site <= 10)
                {
                    palette_2.transform.position -= new Vector3(0.1f, 0, 0);
                }
                else
                {
                    palette_2.transform.position += new Vector3(0.1f, 0, 0);
                }
            }
        }
        else
        {
            if (get_ball_distance() > 5f && balL_velocity.y < 0)
            {
                move_to_center();
            }
            else
            {
                if (get_x_distance() >= 0.5f)
                {
                    float movement = UnityEngine.Random.Range(1, 4) * 0.1f;
                    palette_2.transform.position -= new Vector3(movement, 0, 0);
                }
                else if (get_x_distance() <= -0.5f)
                {
                    float movement = UnityEngine.Random.Range(1, 4) * 0.1f;
                    palette_2.transform.position += new Vector3(movement, 0, 0);
                }
            }
        }
    }
    private void computer_hard_movement()
    {
        if (get_ball_distance() > 5f && balL_velocity.y < 0)
        {
            move_to_center();
        }
        else
        {
            if (get_x_distance() >= 0.5f)
            {
                palette_2.transform.position -= new Vector3(0.4f, 0, 0);
                if (get_ball_distance() < 4f)
                {
                    palette_2.transform.position -= new Vector3(0.1f, 0, 0);
                }
            }
            else if (get_x_distance() <= -0.8f)
            {
                palette_2.transform.position += new Vector3(0.25f, 0, 0);
                if (get_ball_distance() < 4f)
                {
                    palette_2.transform.position += new Vector3(0.1f, 0, 0);
                }
            }
        }
    }
    private List<double> AI_get_positions()
    {
        List<double> positions = new List<double>();
        log_palette_x = get_peltte_position().x;    // pozycje potrzebne do zapisania logow
        log_ball_x = get_ball_position().x;
        positions.Add(log_palette_x);
        positions.Add(log_ball_x);
        return positions;
    }
    private int get_direction()
    {
        int direction = neuron.get_neuron_answer(AI_get_positions());
        return direction;
    }
    private void AI_move_left()
    {
        if (palette_2.transform.position.x > -7.5f)
        {
            palette_2.transform.position += new Vector3(-0.2f, 0, 0);
        }
    }
    private void AI_move_right()
    {
        if (palette_2.transform.position.x < -0.3f)
        {
            palette_2.transform.position += new Vector3(0.2f, 0, 0);
        }
    }
    private int check_for_result()
    {
        int result = -1;
        if(log_palette_x > log_ball_x)
        {
            result = -1;
        }
        else
        {
            result = 1;
        }
        return result;
    }
    private void write_logs(int direction)
    {
        if(direction == check_for_result())
        {
            log_txt.WriteLineAsync("Pozycja paletki: " + log_palette_x + " | Pozycja pilki: " + log_ball_x + " | Wynik: " + direction + "(prawidlowy)");
        }
        else
        {
            log_txt.WriteLineAsync("Pozycja paletki: " + log_palette_x + " | Pozycja pilki: " + log_ball_x + " | Wynik: " + direction + "(nieprawidlowy)");
            mistakes_txt.WriteLineAsync(log_palette_x + " | " + log_ball_x + " | " + direction + " | ");
        }
    }
    private void computer_AI_movement()
    {
        if(AI_movement_timer > 0.1)
        {
            AI_direction = get_direction();
            AI_movement_timer = 0;
            Debug.Log(AI_direction);
            write_logs(AI_direction);
        }
        else
        {
            AI_movement_timer += Time.deltaTime;
        }
        if(AI_direction == -1)
        {
            AI_move_left();
        }
        else
        {
            AI_move_right();
        }

    }
    private void movement()
    {
        player_1_movement();
        if (Game_Settings.who_is_enemy != "computer")
        {
            player_2_movement();
        }
        else
        {
            if (Game_Settings.difficulty == "easy")
            {
                computer_easy_movement();
            }
            else if (Game_Settings.difficulty == "medium")
            {
                computer_medium_movement();
            }
            else if(Game_Settings.difficulty == "hard")
            {
                computer_hard_movement();
            }
            else
            {
                computer_AI_movement();
            }
            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 0.4f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            medium_lvl_random_parametre = UnityEngine.Random.Range(0, 100);
        }
        
        movement();
    
    }
}
