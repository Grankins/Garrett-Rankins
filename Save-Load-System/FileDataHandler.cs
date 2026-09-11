using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
public class FileDataHandler
{
    private readonly string dataDirPath;
    private readonly string dataFileName;
    private readonly bool useEncryption;

    private readonly string encryptionCodeWord = "qxh63bdj8asd"; 

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption = false)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    
    public void Save(GameData data, string profileId)
    {
        try
        {
            if (!Directory.Exists(dataDirPath))
            {
                Directory.CreateDirectory(dataDirPath);
            }

            string fullPath = GetFullPath(profileId);

            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            File.WriteAllText(fullPath, dataToStore);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving file: " + e);
        }
    }

    
    public GameData Load(string profileId)
    {
        string fullPath = GetFullPath(profileId);

        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"Save file not found for profileId: {profileId}");
            return null;
        }

        try
        {
            string dataToLoad = File.ReadAllText(fullPath);

            if (useEncryption)
            {
                dataToLoad = EncryptDecrypt(dataToLoad);
            }

            GameData loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading file: " + e);
            return null;
        }
    }

   
    public void Delete(string profileId)
    {
        string fullPath = GetFullPath(profileId);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }

    
    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profilesData = new Dictionary<string, GameData>();

        if (!Directory.Exists(dataDirPath))
        {
            Debug.LogWarning("Save directory not found: " + dataDirPath);
            return profilesData;
        }

        try
        {
            string[] files = Directory.GetFiles(dataDirPath, $"{Path.GetFileNameWithoutExtension(dataFileName)}_*{Path.GetExtension(dataFileName)}");

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                
                int underscoreIndex = fileName.LastIndexOf('_');
                if (underscoreIndex < 0)
                    continue;

                string profileId = fileName.Substring(underscoreIndex + 1);

                GameData data = Load(profileId);

                if (data != null)
                {
                    profilesData.Add(profileId, data);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading all profiles: " + e);
        }

        return profilesData;
    }

    
    private string GetFullPath(string profileId)
    {
        if (string.IsNullOrEmpty(profileId))
        {
            return Path.Combine(dataDirPath, dataFileName);
        }
        else
        {
            
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(dataFileName);
            string ext = Path.GetExtension(dataFileName);
            return Path.Combine(dataDirPath, $"{fileNameWithoutExt}_{profileId}{ext}");
        }
    }

   
    private string EncryptDecrypt(string data)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            result.Append((char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]));
        }

        return result.ToString();
    }

    
    public string GetMostRecentlyUpdatedProfileId()
    {
        if (!Directory.Exists(dataDirPath))
            return "";

        string[] files = Directory.GetFiles(dataDirPath, $"{Path.GetFileNameWithoutExtension(dataFileName)}_*{Path.GetExtension(dataFileName)}");

        string latestProfile = "";
        DateTime latestTime = DateTime.MinValue;

        foreach (string file in files)
        {
            DateTime lastWrite = File.GetLastWriteTime(file);
            if (lastWrite > latestTime)
            {
                latestTime = lastWrite;

                string fileName = Path.GetFileNameWithoutExtension(file);
                int underscoreIndex = fileName.LastIndexOf('_');
                if (underscoreIndex >= 0)
                {
                    latestProfile = fileName.Substring(underscoreIndex + 1);
                }
            }
        }

        return latestProfile;
    }
}
