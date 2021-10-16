using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scenes : MonoBehaviour
{
    public void SceneLoading()
    {
        SceneManager.LoadScene(1);
    }
    public void HangarLoading()
    {
        SceneManager.LoadScene(0);
    }
}
