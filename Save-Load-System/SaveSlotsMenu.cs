using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>(true);

        
        if (saveSlots.Length >= 3)
        {
            saveSlots[0].profileId = "slot1";
            saveSlots[1].profileId = "slot2";
            saveSlots[2].profileId = "slot3";
        }
        else
        {
            Debug.LogError("Not enough SaveSlot components assigned in the scene (need 3).");
        }
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);

        Dictionary<string, GameData> profilesData = DataPersistanceManager.instance.GetAllProfilesGameData();

        foreach (SaveSlot slot in saveSlots)
        {
            GameData data = null;
            string profileId = slot.GetProfileId();
            profilesData.TryGetValue(slot.profileId, out data);
            slot.SetData(data, profileId);

            slot.SetInteractable(true); //always start enabled
            slot.saveSlotButton.onClick.RemoveAllListeners();
            slot.saveSlotButton.onClick.AddListener(() => OnSaveSlotClicked(slot));
        }

        backButton.interactable = true;
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        DataPersistanceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        //load game data now if needed before scene change
        //DataPersistanceManager.instance.LoadGame();

        // Then load the scene once
        Debug.Log("Clicked");
        SceneManager.LoadSceneAsync("LoadingScene");
        
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot slot in saveSlots)
        {
            slot.SetInteractable(false);
        }

        backButton.interactable = false;
    }
}
