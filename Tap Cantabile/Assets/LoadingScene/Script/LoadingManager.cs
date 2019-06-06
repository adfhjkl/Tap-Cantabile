using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(Load(StaticScript.sceneStr));
    }

    IEnumerator Load(string temp)
    {
        AsyncOperation ay = SceneManager.LoadSceneAsync(temp);

        while (true)
        {
            if (ay.isDone)
            {
                StopCoroutine(Load(StaticScript.sceneStr));
                ay.allowSceneActivation = true;
            }
            yield return new WaitForEndOfFrame();//코르틴
        }
    }
}
