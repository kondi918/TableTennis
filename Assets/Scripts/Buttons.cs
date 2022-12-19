using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void start_game()
    {
        SceneManager.LoadScene("Game");
    }
    public void options()
    {
        GameObject.Find("Main_Camera").transform.position = new Vector2(126.1f, -1.85f);
        GameObject.Find("background_mover").transform.position = new Vector2(130, 0);
    }
    public void options_back()
    {
        GameObject.Find("Main_Camera").transform.position = new Vector2(-3.9f, -1.85f);
        GameObject.Find("background_mover").transform.position = new Vector2(0, 0);
    }
    public void exit_game()
    {
        Application.Quit();
    }
    public void back_to_menu()
    {
        Score.player_1_score = 0;
        Score.player_2_score = 0;
        Destroy(GameObject.Find("Music"));
        Destroy(GameObject.Find("Options_palettes"));
        Destroy(GameObject.Find("Game_Settings"));
        Destroy(GameObject.Find("Score"));
        SceneManager.LoadScene("Menu");
    }
}
