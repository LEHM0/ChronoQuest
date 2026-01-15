using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//Database script provided by Claude
[Serializable]
public class GameState
{
    public int levelsCompleted;
    public int goodKarma;
    public int badKarma;
    public Vector3 playerPos;
    public string currentScene;
}

public class SupabaseManager : MonoBehaviour
{
    [Header("Supabase Configuration")]
    [SerializeField] private string supabaseUrl = "YOUR_PROJECT_URL";
    [SerializeField] private string supabaseKey = "YOUR_ANON_KEY";

    private string tableName = "game_saves";

    public static SupabaseManager instance;

    void Awake()
    {
        //Ensures SupabaseManager stays across all levels
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

    public void SaveGame(string userId, GameState gameState, Action<bool> onComplete)
    {
        StartCoroutine(SaveGameCoroutine(userId, gameState, onComplete));
    }

    public void LoadGame(string userId, Action<GameState> onComplete)
    {
        StartCoroutine(LoadGameCoroutine(userId, onComplete));
    }

    private IEnumerator SaveGameCoroutine(string userId, GameState gameState, Action<bool> onComplete)
    {
        //Serialize game state to JSON
        string jsonData = JsonUtility.ToJson(gameState);

        //Create the data to send
        string postData = $@"{{
            ""user_id"": ""{userId}"",
            ""save_name"": ""main_save"",
            ""game_state"": {jsonData}
        }}";

        byte[] bodyRaw = Encoding.UTF8.GetBytes(postData);

        //Create request
        string url = $"{supabaseUrl}/rest/v1/{tableName}";
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        //Set headers
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("apikey", supabaseKey);
        request.SetRequestHeader("Authorization", $"Bearer {supabaseKey}");
        request.SetRequestHeader("Prefer", "resolution=merge-duplicates");

        //Send request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Game saved successfully!");
            onComplete?.Invoke(true);
        }
        else
        {
            Debug.LogError($"Save failed: {request.error}\n{request.downloadHandler.text}");
            onComplete?.Invoke(false);
        }
    }

    private IEnumerator LoadGameCoroutine(string userId, Action<GameState> onComplete)
    {
        //Build query URL to get the latest save for this user
        string url = $"{supabaseUrl}/rest/v1/{tableName}?user_id=eq.{userId}&order=updated_at.desc&limit=1";

        UnityWebRequest request = UnityWebRequest.Get(url);

        //Set headers
        request.SetRequestHeader("apikey", supabaseKey);
        request.SetRequestHeader("Authorization", $"Bearer {supabaseKey}");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;

            //Parse the response array
            if (response.Length > 2) //More than just "[]"
            {
                SaveDataWrapper wrapper = JsonUtility.FromJson<SaveDataWrapper>("{\"items\":" + response + "}");

                if (wrapper.items != null && wrapper.items.Length > 0)
                {
                    GameState loadedState = wrapper.items[0].game_state;
                    Debug.Log("Game loaded successfully!");
                    onComplete?.Invoke(loadedState);
                }
                else
                {
                    Debug.Log("No save data found");
                    onComplete?.Invoke(null);
                }
            }
            else
            {
                Debug.Log("No save data found");
                onComplete?.Invoke(null);
            }
        }
        else
        {
            Debug.LogError($"Load failed: {request.error}");
            onComplete?.Invoke(null);
        }
    }

    [Serializable]
    public class SaveDataWrapper
    {
        public SaveDataItem[] items;
    }

    [Serializable]
    public class SaveDataItem
    {
        public string user_id;
        public string save_name;
        public GameState game_state;
    }
}
