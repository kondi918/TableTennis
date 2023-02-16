using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Buttons : MonoBehaviour
{
    public void set_easy_mode()
    {
        Game_Settings.difficulty = "easy";
    }
    public void set_medium_mode()
    {
        Game_Settings.difficulty = "medium";
    }
    public void set_hard_mode()
    {
        Game_Settings.difficulty = "hard";
    }
    public void set_ai_mode()
    {
        Game_Settings.difficulty = "AI";
    }
}
