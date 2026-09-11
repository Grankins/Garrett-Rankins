using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static ExpeditionManager;

public class GameData 
{
    public long lastUpdatedTicks;
    public DateTime lastUpdated
    {
        get
        {
            return new DateTime(lastUpdatedTicks);
        }
        set
        {
            lastUpdatedTicks = value.Ticks;
        }
    }

    public bool hasData;
    public int treesCut;
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public double playerMoney;
    public bool towerComplete; //D
    public int currentDay;
    public int currentHour;
    public int currentMinute;
    public int totalDays;
    public bool isClockRunning;
    public bool seismicMonitorState; //D
    public bool seismicComplete; //D
    public bool baseTowerComplete; //D
    public bool radarComplete; //D
    public bool receiverComplete;
    public int raioTower2x4Count;
    public bool isRebuilt;
    public int currentLevel;
    public int currentXp;
    
    
    public List<Vector3> treePositions;
    public bool fillerFilled;

    
    
    
    

    //stations
    public int fourCount;
    public int twoCount;
    public int oneCount;
    public int plyCount;
    public int stain1Count;
    public int stain2Count;
    public int logMachineCount;
    public int stain1type;
    public int stain2type;

    public List<int> furnaceSmeltingQueue = new List<int>();
    public List<int> furnaceOreCounts = new List<int>();
    public bool furnaceIsSmelting;
    public float furnaceSmeltProgress;
    public int furnaceCurrentSmeltingIndex;
    public List<string> anvilBarKeys;
    public List<int> anvilBarValues;
    public List<string> craftedItems = new List<string>();

    //Contracts
    public static readonly string[] WoodKeys = {
    "NoStain 1x4", "Oak 1x4", "RedCedar 1x4",
    "NoStain 2x4", "Oak 2x4", "RedCedar 2x4",
    "NoStain 4x4", "Oak 4x4", "RedCedar 4x4",
    "NoStain Plywood", "Oak Plywood", "RedCedar Plywood"
    };
    public List<int> collectedWoodAmounts = new List<int>();

    //HotBar
    public string equippedItemName;
    public string equippedItemType;
    public int activeSlot;

    //Drones
    [System.Serializable]
    public class DroneData
    {
        public Vector3 position;
        public bool isActive;
        public int droneBattery;
        public List<string> inventoryItems;
        public int logCount;
        public bool isDroneDeployed;
        public int droneId;
        public DroneData(Vector3 position, bool isActive,int droneBattery, int logCount, bool isDeployed, int ID)
        {
            this.position = position;
            this.isActive = isActive;
            this.droneBattery = droneBattery;
            this.logCount = logCount;
            this.isDroneDeployed = isDeployed;
            this.droneId = ID;
        }

        // Optional: parameterless constructor for JSON serialization
        public DroneData() { }
    }
    public List<DroneData> droneDataList = new List<DroneData>();

    //BlackMarket
    public bool strikeInfusionActive;
    public bool magnetActive;
    public bool stolenActive;
    public bool droneNetworkActive;

    //Grab
    public bool held;


    //Shoulder

    //Items

    public List<SpawnedWoodData> spawnedWoodObjects = new List<SpawnedWoodData>();

    //OreManager
    // Totals
    public int ironTotal;
    public int goldTotal;
    public int tungstenTotal;
    public int radianiteTotal;
    public int volcaniteTotal;

    public int ironGrandTotal;
    public int goldGrandTotal;
    public int tungstenGrandTotal;
    public int radianiteGrandTotal;
    public int volcaniteGrandTotal;

    public List<BarSaveManager.BarData> savedBars = new List<BarSaveManager.BarData>();
    //Settings Manager
    public int graphicsQualityIndex;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public bool isFullscreen;
    public float mouseSensitivity;
    //Skills
    public int strength;
    public int speed;
    public int throwing;
    public int looting;
    public int sellMultiplier;
    public int contractLicense;
    public int machineEfficiency;
    public int xpHunter;
    public int skillPoints;

    //Research
    public int ironMined;
    public int woodCrafted_4x4;
    public int woodCrafted_2x4;
    public int woodCrafted_1x4;
    public int woodCrafted_plywood;
    public int goldMined;
    public int tungstenMined;
    public int logsObtained;
    public int totalstained1;
    public int totalstained2;
    
    

    public bool hasUnlocked2x4Machine;
    public bool hasUnlocked1x4Machine;
    public bool hasUnlockedPlywoodMachine;
    public bool hasUnlockedStainerMachine;
    public bool hasUnlockedStainerMachine2;
    public bool hasUnlockedCharpit;
    public bool hasUnlockedResourceBooster;
    public bool hasUnlockedMineExpeditions;
    public bool hasUnlockedRiverMill;

    //HotBar//Inventory
    public bool isTreeWackerLiteCrafted;
    public bool isTreeWackerProCrafted;
    public bool isBattleAxeCrafted;
    public bool isLeviathanCrafted;
    public string lastAxeName;

    public bool isDefaultAxeEquip;
    public bool isTreeWackerLiteEquip;
    public bool isTreeWackerProEquip;
    public bool isBattleAxeEquip;
    public bool isLeviathanEquip;

    //Expeditions
    public int expeditionsCompletedCount;
    public List<ExpeditionSaveData> expeditionData;
    [System.Serializable]
    public class FillerObjectData
    {
        public string prefabName;
        public Vector3 position;
        public float scale;
        public float yRotation;
    }
    public List<FillerObjectData> fillerObjects = new List<FillerObjectData>();
    public List<Vector3> spawnedObjects = new List<Vector3>();

    //Achievement Stuff
    public float distanceTraveled;

    
    public List<AchievementSaveData> achievementsData;

    public bool treeBreakerAchievement;

    //Contracts
    public int totalContractsCompleted;

    //Station Queue
    public List<int> logMachineQueue = new List<int>();
    public List<int> cutterQueue = new List<int>();
    public List<int> cutterTwoQueue = new List<int>();
    public List<int> cutterThreeQueue = new List<int>();
    public List<int> plywoodQueue = new List<int>();
    public List<int> stain1Queue = new List<int>();
    public List<int> stain2Queue = new List<int>();

    public int currentStoryContractIndex;

    //TutorialMarks
    public bool poiAnvilVisited;
    public bool poiFurnaceVisited;
    public bool poiCampfireVisited;
    public bool poiResearchVisited;
    public bool poiBillBoardVisited;
    public bool poiRadioTowerVisited;

    public bool tutorialCompleted;
    public List<ItemSaveData> droppedItems = new();

    public List<MachineSaveEntry> machineStates = new();
    [System.Serializable]
    public class MachineSaveEntry
    {
        public string machineID;
        public List<string> queuedTypes;
        public float currentProgress;
    }



    public AdvancedAreaSaveData advancedAreaData = new AdvancedAreaSaveData();
    public GameData()
    {
        this.treesCut = 0;
        playerPosition = new Vector3(509,9,208);
        playerRotation = Quaternion.Euler(0, 0, 0);
        this.playerMoney = 150;
        this.currentDay = 0;
        this.currentHour = 6;
        this.currentMinute = 0;
        this.totalDays = 0;
        this.isClockRunning = true;
        this.seismicMonitorState = false;
        this.seismicComplete = false;
        this.radarComplete = false;
        this.baseTowerComplete = false;
        this.towerComplete = false;
        this.currentLevel = 1;
        this.currentXp = 0;
        this.isTreeWackerLiteCrafted = false;
        this.isTreeWackerProCrafted = false;
        this.isBattleAxeCrafted = false;
        this.isLeviathanCrafted = false;
        //this.currentAxe = defaultAxe;
        //this.currentAxeAttack = 6;
        treePositions = new List<Vector3>();
        hasData = false;
        this.fourCount = 0;
        this.twoCount = 0;
        this.oneCount = 0;
        this.plyCount = 0;
        this.stain1Count = 0;
        this.stain2Count = 0;
        this.logMachineCount = 0;
        this.stain1type = 1;
        this.stain2type = 1;
        this.equippedItemName = "DefaultAxe";
        this.equippedItemType = "Axe";
        this.mouseSensitivity = 2.0f;
        this.isFullscreen = true;
        this.stain1type = 1;
        this.stain2type = 2;
        //this.fillerFilled = false;
        

    }
    public void SaveCollectedWood(Dictionary<string, int> woodDict)
    {
        collectedWoodAmounts = new List<int>();
        foreach (string key in WoodKeys)
        {
            woodDict.TryGetValue(key, out int amount);
            collectedWoodAmounts.Add(amount);
        }
    }

    public Dictionary<string, int> LoadCollectedWood()
    {
        Dictionary<string, int> woodDict = new Dictionary<string, int>();
        for (int i = 0; i < WoodKeys.Length; i++)
        {
            int amount = (i < collectedWoodAmounts.Count) ? collectedWoodAmounts[i] : 0;
            woodDict[WoodKeys[i]] = amount;
        }
        return woodDict;
    } /*
    public double GetMoneyTotal()
    { 
        return this.playerMoney;
    }
    public bool GetTowerState() 
    {
        return this.towerComplete;
    }
    public int GetDay()
    {
        return totalDays + 1;
    }
    public void UpdateLastUpdated()
    {
        lastUpdatedTicks = DateTime.Now.Ticks;
    }
    */
}
