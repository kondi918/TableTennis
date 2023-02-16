using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_controller : MonoBehaviour
{ 
    private Music music_changer;
    void Start()
    {
        music_changer = GameObject.Find("Music").GetComponent<Music>();
        music_changer.changing_music();
    }
}
