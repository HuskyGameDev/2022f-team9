using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneLoader : GenericLevelLoader
{
    void OnEnable()
    {
        LoadNextLevel();
    }
}
