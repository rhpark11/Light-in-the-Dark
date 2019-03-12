using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{

    public string scene_name;
    public Fading f;

    public void loadScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
    }

    public void fadeIntoScene(){
        f.LoadSceneAsync(scene_name);
    }
}
