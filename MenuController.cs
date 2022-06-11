using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
   
    public void playButton()
    {
        SceneManager.LoadScene(1); //PLAY butonuna bastýðým 1 numaralý sahnem yani oyun sahneme gideceðim.
    }
   
}
