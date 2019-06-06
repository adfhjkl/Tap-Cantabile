using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    AsyncOperation ao;
    // Start is called before the first frame update
    void Start()
    {
       ao = SceneManager.LoadSceneAsync("DemoScene");
       ao.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ao.progress);
        if (Input.touchCount>=1|| Input.GetKeyDown(KeyCode.Mouse0)) {
            //StaticScript.sceneStr = "DemoScene";
            if (ao.progress >= 0.89f) {
                ao.allowSceneActivation = true;
                //SceneManager.LoadScene("DemoScene");
            }
        }
    }
}