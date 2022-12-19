using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_settings : MonoBehaviour
{
    public AudioSource audio_src;
    public Text volume_text;
    private float music_volume = 1f;
    void Update()
    {
        audio_src.volume= music_volume;
    }
    public void volume_update(float volume)
    { 
        music_volume= volume;
        volume_text.text = Mathf.Round(music_volume*100f).ToString();
    }
}
