using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JSONReadWriteSystem : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField idField;
    [SerializeField]
    private GameObject nextButton;

    public Text statusText;


  
    public void NextButtonClicked()
    {
        SceneManager.LoadScene(GameMenuStrings.MainMenu);
    }
    public void CreateNewPlayer()
    {
        Debug.Log("Button Clicked");
        // Create a new player and add it to the data
        GameData data = new GameData();
        data.Name = nameField.text;
        data.Id = idField.text;

        // Save the updated player data back to the JSON file
        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath+ "/GameDataResources/GameDataFile.json", json);
        statusText.text = "Welcome "+data.Name;
        nextButton.SetActive(true);
    }

    public void LoadFromJson()
    {
        try
        {
            string json = File.ReadAllText(Application.dataPath + "/GameDataResources/GameDataFile.json");
        }
        catch (Exception ex)
        {
            // Catch any other exception
            statusText.text = "No player Data available";
        }
        finally
        {
            string json = File.ReadAllText(Application.dataPath + "/GameDataResources/GameDataFile.json");

            GameData data = JsonUtility.FromJson<GameData>(json);

            nameField.text = data.Name;
            idField.text = data.Id;
        }
       
        
       
    }
}
