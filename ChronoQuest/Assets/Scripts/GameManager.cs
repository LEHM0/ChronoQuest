using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelsCompleted = 0;
    public int goodKarma = 0;
    public int badKarma = 0;

    void Awake()
    {
        //Ensures GameManger stays across all levels
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGoodKarma()
    {
        goodKarma++;

        Debug.Log($"Good Karma increase to {goodKarma}");
    }

    public void AddBadKarma()
    {
        badKarma++;

        Debug.Log($"Bad Karma increase to {badKarma}");
    }

    public void TriggerEnding()
    {
        if (levelsCompleted == 3)
        {
            JudgeEnding();
        }
    }

    public void JudgeEnding()
    {
        if ( goodKarma > badKarma )
        {
            //SceneManager.LoadScene("GoodEnding");
            Debug.Log("Good Ending Achieved!");
        }

        else
        {
            //SceneManager.LoadScene("BadEnding");
            Debug.Log("Bad Ending Achieveed!");
        }
    }

    public void ChooseLevel()
    {
        //
    }
    public void TestChooseLevel()
    {
        //
    }

    public void ClearLevel()
    {
        //
    }
    public void TestClearLevel()
    {
        switch (levelsCompleted)
        {
            case 0:
                levelsCompleted++;
                SceneManager.LoadScene("TestLevelOne");

                break;
            case 1:
                levelsCompleted++;
                SceneManager.LoadScene("TestLevelTwo");

                break;
            case 2:
                levelsCompleted++;
                SceneManager.LoadScene("TestLevelThree");

                break;
            case 3:
                Debug.Log("All levels completed");
                break;
            default:
                Debug.Log("All levels completed");
                break;
        }
    }

    void Update()
    {
        TriggerEnding();
    }
}
