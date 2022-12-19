using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette_color_changer : MonoBehaviour
{
    public List<Sprite> palette_color = new List<Sprite>();
    private SpriteRenderer left_palette;
    private SpriteRenderer right_palette;
    private static int left_palette_color_number;
    private static int right_palette_color_number;
    void Start()
    {
        left_palette = GameObject.Find("options_palette_left").GetComponent<SpriteRenderer>();
        right_palette = GameObject.Find("options_palette_right").GetComponent<SpriteRenderer>();
        right_palette_color_number = 0;
        left_palette_color_number = 0;
    }
    private int checker(int check)
    {
        //Debug.Log(check);
        if(check < 0)
        {
            check = palette_color.Count-1;
        }
        if(check > palette_color.Count-1)
        {
            check = 0;
        }
        return check;
    }

    public void Left_button_palette_left()
    {
        left_palette_color_number--;
        left_palette_color_number = checker(left_palette_color_number);
        left_palette.sprite = palette_color[left_palette_color_number];
    }
    public void right_button_palette_left()
    {
        left_palette_color_number++;
        left_palette_color_number = checker(left_palette_color_number);
        left_palette.sprite = palette_color[left_palette_color_number];
    }
    public void Left_button_palette_right()
    {
        right_palette_color_number--;
        right_palette_color_number = checker(right_palette_color_number);
        right_palette.sprite = palette_color[right_palette_color_number];
    }
    public void right_button_palette_right()
    {
        right_palette_color_number++;
        right_palette_color_number = checker(right_palette_color_number);
        right_palette.sprite = palette_color[right_palette_color_number];

    }
}
