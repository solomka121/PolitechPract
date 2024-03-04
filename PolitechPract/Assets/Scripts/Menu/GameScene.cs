using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;

    public void SelectObj(int n)
    {
        if (n == 1)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
        }

        if (n == 2)
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
        }
    }

    public void Quit() {
        SceneManager.LoadScene(1);
    }
}
