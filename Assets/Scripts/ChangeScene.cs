using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    public void loadScene(int sceneNumber) //this function will be used on our Start button
    {
        if(sceneNumber == -1)
            Application.Quit();
        else
        SceneManager.LoadScene(sceneNumber);

    }
}