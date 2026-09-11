using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile ID (e.g., slot1, slot2, slot3)")]
    [SerializeField] public string profileId = "";

    [Header("Slot UI References")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI moneyTotalText;
    [SerializeField] private TextMeshProUGUI radioTowerRebuiltText;
    [SerializeField] public Button saveSlotButton;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI towerStatusText;
    public TextMeshProUGUI storyContractsCompletedText;

    
    public void SetData(GameData data, string profileId)
    {
        this.profileId = profileId;

        if (data != null)
        {
            noDataContent.gameObject.SetActive(false);
            dayText.text = "Day: " + data.GetDay();
            moneyText.text = data.playerMoney.ToString("F0") + "$"; 
            towerStatusText.text = data.towerComplete ? "Tower: Rebuilt" : "Tower: Awaiting Repair";
            storyContractsCompletedText.text = $"{data.currentStoryContractIndex+1}/50 Story Contracts";
        }
        else
        {
            noDataContent.gameObject.SetActive(true);

            dayText.text = "";
            moneyText.text = "";
            towerStatusText.text = "";
            storyContractsCompletedText.text = "";
        }
    }

    
    public void SetInteractable(bool interactable)
    {
        if (saveSlotButton != null)
        {
            saveSlotButton.interactable = interactable;
        }
    }

    
    public string GetProfileId()
    {
        return profileId;
    }
    public void OnClick()
    {
        DataPersistanceManager.instance.ChangeSelectedProfileId(profileId);
        SceneManager.LoadSceneAsync("Scene_0"); 
    }
}
