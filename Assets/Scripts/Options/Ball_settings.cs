using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_settings : MonoBehaviour
{
    public Text ball_speed_text;
    public void ball_parametres_update(float volume)
    {
        Game_Settings.ball_speed = volume*-1;
        ball_speed_text.text = volume.ToString();
    }
}
