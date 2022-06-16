using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
   public void SceneMoverBtn()
    {
        switch(this.gameObject.name)
        {
            case "StartButton":
                SceneManager.LoadScene("GameScene");
                break;
            case "TitleButton":
                SceneManager.LoadScene("MainScene");
                break;
            case "QuitButton":
                GameQuit();
                break;
        }
    }
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
