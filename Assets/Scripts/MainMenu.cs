using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void Play(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
