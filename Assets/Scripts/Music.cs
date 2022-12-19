using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public List<AudioClip> cliplist;
    private AudioSource source;
    private Scene scene;
    private static int scene_number = 0; // 0 - Menu, 1 - Game

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = cliplist[0];
        source.Play();
        DontDestroyOnLoad(GameObject.Find("Music"));
        scene_number = 0;
    }
    public void changing_music()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Game" && scene_number != 1)
        {
            source.clip = cliplist[1];
            source.Play();
            scene_number = 1;
        }
    }
}
