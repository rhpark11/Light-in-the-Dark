using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{

    public string scene_name;
    // Start is called before the first frame update

    // Update is called once per frame
    public void loadScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
    }
}
