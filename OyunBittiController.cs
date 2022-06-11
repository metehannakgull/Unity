using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBittiController : MonoBehaviour
{
    public Text yemPuanii;
    GameManager manager;

  

    public void  Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void oyunbitti()
    {
        if (manager.yemPuani2 == 7)
        {
            gameObject.SetActive(true);
            yemPuanii.text = " Yem Puaný: " + manager.textYemMiktari.text;
        }

    }
    public void Update()
    {
        oyunbitti();
    }
}
