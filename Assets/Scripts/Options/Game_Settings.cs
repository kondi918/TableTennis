using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Settings : MonoBehaviour
{
    public static float ball_speed = -8;
    public static string who_is_enemy = "player";
    public static string difficulty = "easy";
    public static string player_1_name = "Player 1";
    public static string player_2_name = "Player 2";
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
