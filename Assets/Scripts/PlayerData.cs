using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private string gender;
    [SerializeField] private Text playerNameText;
    [SerializeField] private GameObject playerNamePanel;

    // Start is called before the first frame update
    void Start()
    {
        SetData();
        GetData(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(playerName);
        bw.Write("Player Gender : " + gender);

        bw.Close();
        fs.Close();
    }
    public void GetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        playerName = br.ReadString();
        playerNameText.text = "Welcome to the mission!"+"\n" +playerName.ToString();
        playerNamePanel.SetActive(true);
        br.Close();
        fs.Close();
    }
}