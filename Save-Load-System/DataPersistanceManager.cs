using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager instance;

    [Header("Debug")]
    [SerializeField] private bool initializeNewGameIfNull = true;

    [Header("File Storage Config")]
    [SerializeField] private string fileName = "game.gd";
    private FileDataHandler dataHandler;

    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    private string selectedProfileId = "";

    public string SelectedProfileId => selectedProfileId;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogError("Found more than one DataPersistanceManager in the scene.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        
        selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, false);
        //LoadGame();
    }
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "MainMenu") return;
        Debug.Log("Scene loaded: " + scene.name);
        dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }
    public void ChangeSelectedProfileId(string newProfileId)
    {
        selectedProfileId = newProfileId;
        LoadGame(); 
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects(); 
        this.gameData = dataHandler.Load(selectedProfileId);

        if (this.gameData == null)
        {
            //Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        //Debug.Log("Loaded game data. Spawned woods count: " + gameData.spawnedWoodObjects.Count);
        //gameData.mouseSensitivity = SettingsManagerMainMenu.instance.mouseSens;

        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            
            dataPersistanceObj.LoadData(gameData);
            //Debug.Log(dataPersistanceObj);
            
        }
        //Debug.Log("Loaded treeCount = " + gameData.treesCut);
    }


    public void SaveGame()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects(); 
       // Debug.Log(dataPersistanceObjects);
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
            //Debug.Log(dataPersistanceObj);
        }
        //Debug.Log("Saved treeCount = " + gameData.treesCut);

        dataHandler.Save(gameData, selectedProfileId);
    }

    public void DeleteProfileData(string profileId)
    {
        dataHandler.Delete(profileId);
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        var list = new List<IDataPersistance>(dataPersistenceObjects);

        //Debug.Log($"Found {list.Count} IDataPersistance objects:");
        foreach (var obj in list)
        {
            //Debug.Log($"- {obj.GetType().Name} on GameObject '{((MonoBehaviour)obj).gameObject.name}'");
        }

        return list;
    }

    /*private void OnApplicationQuit()
    {
        SaveGame();
    } */
    
    
}
