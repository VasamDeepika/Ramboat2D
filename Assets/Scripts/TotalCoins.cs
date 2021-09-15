using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour
{
    [SerializeField] public int allCoins=0;
    public static TotalCoins instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.persistentDataPath + "/AllCoins.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        allCoins = (br.ReadInt32());
        print(allCoins);
        fs.Close();
        br.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetData()
    {
        //PlayerPrefs.SetInt("allCoins",allCoins);
        string filePath = UnityEngine.Application.persistentDataPath + "/AllCoins.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(allCoins);
        fs.Close();
        bw.Close();
    }
}
