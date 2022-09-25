using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSKip : MonoBehaviour
{
    public void GoToHome(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
