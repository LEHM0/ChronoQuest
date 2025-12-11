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
        //Add in other script: GameManager.Instance.AddGoodKarma();

        Debug.Log($"Good Karma increase to {goodKarma}");
    }

    public void AddBadKarma()
    {
        badKarma++;
        //Add in other script: GameManager.Instance.AddBadKarma();

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
        }

        else
        {
            //SceneManager.LoadScene("BadEnding");
        }
    }

    void Update()
    {
        TriggerEnding();
    }
}
