using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public void Start(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        Application.Quit();
    }
}
