using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SupabaseManager supabaseManager;
    private GameState currentGameState;
    private PlayerNotifications playerNotifications;

    public static GameManager instance;

    public GameObject notifWindow;
    public GameObject player;
    public int levelsCompleted = 0;
    public int goodKarma = 0;
    public int badKarma = 0;
    public string currentScene;
    public bool endingTriggered = false;

    private string saveNotif = "Game Saved Successfully";

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

    void Start()
    {
        //Initialize a sample game state
        currentGameState = new GameState
        {
            levelsCompleted = 0,
            goodKarma = 0,
            badKarma = 0,
            playerPos = Vector3.zero,
            currentScene = "TestScene"
        };

        playerNotifications = notifWindow.GetComponent<PlayerNotifications>();
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
        if (!endingTriggered && levelsCompleted == 3)
        {
            JudgeEnding();
        }
    }

    public void JudgeEnding()
    {
        if ( goodKarma > badKarma )
        {
            SceneManager.LoadScene("GoodEnding");
            endingTriggered = true;
            Debug.Log("Good Ending Achieved!");
        }

        else
        {
            SceneManager.LoadScene("BadEnding");
            endingTriggered = true;
            Debug.Log("Bad Ending Achieved!");
        }
    }

    public void ChooseLevel()
    {
        //
    }

    public void ClearLevel()
    {
        //
        levelsCompleted++;
    }

    public void SaveCurrentGame()
    {
        //Update game state with current values
        currentGameState.playerPos = player.transform.position;

        string userId = SystemInfo.deviceUniqueIdentifier; //Simple user ID for testing

        supabaseManager.SaveGame(userId, currentGameState, (success) =>
        {
            if (success)
            {
                Debug.Log("Game saved!");
                StartCoroutine(playerNotifications.PlayerNotification(saveNotif));
            }
        });
    }

    public void LoadGame()
    {
        string userId = SystemInfo.deviceUniqueIdentifier;

        supabaseManager.LoadGame(userId, (loadedState) =>
        {
            if (loadedState != null)
            {
                currentGameState = loadedState;

                //Apply the loaded state to your game
                levelsCompleted = loadedState.levelsCompleted;
                goodKarma = loadedState.goodKarma;
                badKarma = loadedState.badKarma;
                player.transform.position = loadedState.playerPos;
                //Load correct scene
                currentScene = loadedState.currentScene;

                Debug.Log($"Game loaded! Level: {loadedState.currentScene}, Good Karma: {loadedState.goodKarma}, Bad Karma: {loadedState.badKarma}");
            }
            else
            {
                Debug.Log("No save data found");
            }
        });
    }

    void Update()
    {
        //Press 1 to save
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveCurrentGame();
        }

        //Press 2 to load
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadGame();
        }

        TriggerEnding();
    }
}
