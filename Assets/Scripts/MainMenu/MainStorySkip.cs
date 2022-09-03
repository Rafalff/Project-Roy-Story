using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStorySkip : MonoBehaviour
{
    public void Skip(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
