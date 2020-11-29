using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void ReturnToMain ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("SimpleAR");
    }
}
