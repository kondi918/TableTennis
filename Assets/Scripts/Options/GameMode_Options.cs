using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode_Options : MonoBehaviour
{
    private GameObject gamemode_activator;
    private bool is_enemy_computer = false;
    void Start()
    {
        gamemode_activator = GameObject.Find("Computer_buttons");
        gamemode_activator.SetActive(false);
    }
    public void game_mode()
    {
        if(is_enemy_computer)
        {
            is_enemy_computer = false;
            Game_Settings.who_is_enemy = "player";
            Game_Settings.player_2_name = "Player 2";
            gameObject.GetComponentInChildren<Text>().text = "2 Players";
            GameObject.Find("text_right_palette").GetComponent<Text>().text = "Player 2";
            gamemode_activator.SetActive(false);
        }
        else
        {
            is_enemy_computer = true;
            Game_Settings.who_is_enemy = "computer";
            Game_Settings.player_2_name = "Computer";
            gameObject.GetComponentInChildren<Text>().text = "Computer";
            GameObject.Find("text_right_palette").GetComponent<Text>().text = "Computer";
            gamemode_activator.SetActive(true);
        }
    }

}
