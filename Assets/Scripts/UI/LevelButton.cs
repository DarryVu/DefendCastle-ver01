using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
   
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneIndex); 
    }
}
