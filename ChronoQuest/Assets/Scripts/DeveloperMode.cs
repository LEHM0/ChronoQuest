using UnityEngine;
using UnityEngine.SceneManagement;

public class DeveloperMode : MonoBehaviour
{
    public bool devModeActive = false;

    void Update()
    {
        if (devModeActive)
        {
            ChangeScene();
            ChangeKarma();
            ChangeClearedLevels();
        }
    }

    public void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("TestScene");
            Debug.Log("Scene set to TestScene");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("TutorialLevel");
            Debug.Log("Scene set to TutorialLevel");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("AncientEgypt");
            Debug.Log("Scene set to AncientEgypt");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("OldAmerica");
            Debug.Log("Scene set to OldAmerica");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("SpaceAge");
            Debug.Log("Scene set to SpaceAge");
        }
    }

    public void ChangeKarma()
    {
        //
    }

    public void ChangeClearedLevels()
    {
        //
    }
}
