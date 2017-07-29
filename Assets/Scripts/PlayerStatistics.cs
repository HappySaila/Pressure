using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class PlayerStatistics : MonoBehaviour {
    public static PlayerStatistics INSTANCE;

    [SerializeField] Text[] values;

    //Player.
    [HideInInspector] public int totalJumps = 0;            
    [HideInInspector] public int totalDeaths = 0;
    [HideInInspector] public int totalPoints = 0;
    [HideInInspector] public int timesShot = 0;
    //Items.
    [HideInInspector] public int springJumps = 0;
    [HideInInspector] public int trampolineJumps = 0;
    [HideInInspector] public int heliHatsAquired = 0;
    [HideInInspector] public int jetpackShoesAquired = 0;
    [HideInInspector] public int bounceShoesAquired = 0;
    [HideInInspector] public int shieldsAquired = 0;
    [HideInInspector] public int monstersKilled = 0;


    //Runs GetData() and makes INSTANCE equal this.
    private void Awake() {
        if(INSTANCE == null) {
            INSTANCE = this;
        }

        GetData();
    }

    //Updates stats to text.
    private void Update() {
        UpdateStats();
    }

    //Updates the Stats GUI text.
    private void UpdateStats() {
        try {
            values[0].text = totalJumps.ToString();
            values[1].text = totalDeaths.ToString();
            values[2].text = totalPoints.ToString();
            values[3].text = timesShot.ToString();
            values[4].text = springJumps.ToString();
            values[5].text = trampolineJumps.ToString();
            values[6].text = heliHatsAquired.ToString();
            values[7].text = jetpackShoesAquired.ToString();
            values[8].text = bounceShoesAquired.ToString();
            values[9].text = shieldsAquired.ToString();
            values[10].text = monstersKilled.ToString();
        } catch(Exception e) {
            //This is a false error. Does no harm to the game.
			Debug.LogFormat("e {0}", e.Message);
        }
    }

    //Returns all keys' values.
    private void GetData() {
        if (PlayerPrefs.HasKey("TotalJumps")) {
            totalJumps = PlayerPrefs.GetInt("TotalJumps");
            totalPoints = PlayerPrefs.GetInt("TotalPoints");
            totalDeaths = PlayerPrefs.GetInt("TotalDeaths");
            bounceShoesAquired = PlayerPrefs.GetInt("BounceShoesAquired");
            jetpackShoesAquired = PlayerPrefs.GetInt("JetpackShoesAquired");
            heliHatsAquired = PlayerPrefs.GetInt("HeliHatsAquired");
            shieldsAquired = PlayerPrefs.GetInt("ShieldsAquired");
            springJumps = PlayerPrefs.GetInt("SpringJumps");
            trampolineJumps = PlayerPrefs.GetInt("TrampolineJumps");
            timesShot = PlayerPrefs.GetInt("TimesShot");
            timesShot = PlayerPrefs.GetInt("MonstersKilled");
        }
    }

    //Saves all values to keys.
    public void SaveData() {
        PlayerPrefs.SetInt("TotalJumps", totalJumps);
        PlayerPrefs.SetInt("TotalPoints", totalPoints);
        PlayerPrefs.SetInt("TotalDeaths", totalDeaths);
        PlayerPrefs.SetInt("BounceShoesAquired", bounceShoesAquired);
        PlayerPrefs.SetInt("JetpackShoesAquired", jetpackShoesAquired);
        PlayerPrefs.SetInt("HeliHatsAquired", heliHatsAquired);
        PlayerPrefs.SetInt("ShieldsAquired", shieldsAquired);
        PlayerPrefs.SetInt("SpringJumps", springJumps);
        PlayerPrefs.SetInt("TrampolineJumps", trampolineJumps);
        PlayerPrefs.SetInt("TimesShot", timesShot);
        PlayerPrefs.SetInt("MonstersKilled", monstersKilled);
    }

    //Saves all key values before application closes.
    private void OnApplicationQuit() {
        SaveData();
        PlayerPrefs.Flush();
    }

    //Saves all values when application is paused.
    private void OnApplicationPause(bool pause) {
        SaveData();
        PlayerPrefs.Flush();
    }

    //Called to reset all key values.
    public void ResetKeys() {
        totalJumps = 0;
        totalPoints = 0;
        totalDeaths = 0;
        bounceShoesAquired = 0;
        jetpackShoesAquired = 0;
        heliHatsAquired = 0;
        shieldsAquired = 0;
        springJumps = 0;
        trampolineJumps = 0;
        timesShot = 0;
        monstersKilled = 0;
    }
}
