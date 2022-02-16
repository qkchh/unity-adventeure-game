using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.IO;

public class SceneOneSave : MonoBehaviour
{

    /// <summary>
    /// 存档游戏
    /// </summary>
    private GameObject Player;
    private GameObject Stabs;

    private SpriteRenderer[] StabsSP;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Stabs = GameObject.Find("Stabs");
        StabsSP = Stabs.GetComponentsInChildren<SpriteRenderer>();
   
        SaveGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 加载游戏
    public void Load()
    {
        LoadGame(LoadXml());
    }

    public void SaveGame()
    {
        GameSaves saves = new GameSaves();
        foreach (SpriteRenderer StabSP in StabsSP)
        {
            saves.StabSpriteEnable.Add(StabSP.enabled);
        }
        // 角色位置
        saves.PlayerTransform = Player.transform.position.x.ToString() + "#" + Player.transform.position.y.ToString();
        SaveXml(saves);
    }

    //加载游戏
    private void LoadGame(GameSaves saves)
    {
        int i = 0;
        foreach (SpriteRenderer StabSP in StabsSP)
        {
            StabSP.enabled = saves.StabSpriteEnable[i];
            i++;
        }
        string[] local = saves.PlayerTransform.Split('#');
        Player.transform.position = new Vector3(float.Parse(local[0]), float.Parse(local[1]), 0);
    }


    // 存档到xml文件
    private void SaveXml(GameSaves saves)
    {
        string filePath = Application.dataPath + "/StreamingAssets" + "/SceneOneArchive.xml";
        // 创建xml文档
        XmlDocument xmlDoc = new XmlDocument();
        //根节点
        XmlElement root = xmlDoc.CreateElement("save");
        //跟节点中的值
        root.SetAttribute("name", "fielSceneOne");

        XmlElement colliders;
        XmlElement Stabs;
        XmlElement Stab;

        colliders = xmlDoc.CreateElement("colliders");
        for (int i = 0; i < saves.StabSpriteEnable.Count; i++)
        {
            Stabs = xmlDoc.CreateElement("Stabs");
            Stab = xmlDoc.CreateElement("Stab");
            Stab.InnerText = saves.StabSpriteEnable[i].ToString();
            Stabs.AppendChild(Stab);
            colliders.AppendChild(Stabs);
        }
        root.AppendChild(colliders);

        XmlElement PlayerTransfrom;
        PlayerTransfrom = xmlDoc.CreateElement("PlayerTransfrom");
        PlayerTransfrom.InnerText = saves.PlayerTransform;
        root.AppendChild(PlayerTransfrom);
        xmlDoc.AppendChild(root);
        xmlDoc.Save(filePath);
    }


    // 读取xml文件
    private GameSaves LoadXml()
    {
        string filePath = Application.dataPath + "/StreamingAssets" + "/SceneOneArchive.xml";
        GameSaves saves = new GameSaves();
        if (File.Exists(filePath))
        {
            // 加载xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNodeList Stabs = xmlDoc.GetElementsByTagName("Stabs");
            foreach (XmlNode stab in Stabs)
            {
                saves.StabSpriteEnable.Add(bool.Parse(stab.ChildNodes[0].InnerText));
            }

            //通过节点遍历元素
            saves.PlayerTransform = xmlDoc.GetElementsByTagName("PlayerTransfrom")[0].InnerText;
        }


        return saves;
    }
}
