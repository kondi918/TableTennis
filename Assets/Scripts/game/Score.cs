using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int player_1_score = 0;
    private static Text player_1_score_text;
    public static int player_2_score = 0;
    private static Text player_2_score_text;
    void Start()
    {
        GameObject.Find("Player_2t").GetComponent<Text>().text = Game_Settings.player_2_name;
        GameObject.Find("Player_1t").GetComponent<Text>().text = Game_Settings.player_1_name;
        player_1_score_text = GameObject.Find("Player_1_score").GetComponent<Text>();
        player_2_score_text = GameObject.Find("Player_2_score").GetComponent<Text>();
        player_1_score_text.text = player_1_score.ToString();
        player_2_score_text.text = player_2_score.ToString();
    }
    public static void add_score_player_1()
    {
        player_1_score++;
        player_1_score_text.text = player_1_score.ToString(); 
    }
    public static void add_score_player_2()
    {
        player_2_score++;
        player_2_score_text.text = player_2_score.ToString();
    }
}
