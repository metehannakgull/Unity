using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
   
    public void playButton()
    {
        SceneManager.LoadScene(1); //PLAY butonuna bast���m 1 numaral� sahnem yani oyun sahneme gidece�im.
    }
   
}
