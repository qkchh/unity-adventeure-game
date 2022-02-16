using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.IO;

public class SavesGame : MonoBehaviour
{

    /// <summary>
    /// 存档游戏
    /// </summary>
    private GameObject Player;
    private GameObject Stabs;
    private GameObject Missiles;
    private GameObject Clouds;
    private GameObject Walls;
    private GameObject EnemySuper;
    private GameObject InvisivleWall;
    private GameObject GroudDowns;

    private SpriteRenderer[] StabsSP;
    private MissileActivate[] MissilesMa;
    private CloudActivate[] CloudsCa;
    private Wall01Strike[] WallStrike;
    private GroundDowm[] GDowm;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        EnemySuper = GameObject.Find("enemy");
        Stabs =GameObject.Find("Stabs");
        StabsSP = Stabs.GetComponentsInChildren<SpriteRenderer>();
        Missiles = GameObject.Find("Missiles");
        MissilesMa = Missiles.GetComponentsInChildren<MissileActivate>();
        Clouds = GameObject.Find("Clouds");
        CloudsCa = Clouds.GetComponentsInChildren<CloudActivate>();
        Walls = GameObject.Find("Walls");
        WallStrike = Walls.GetComponentsInChildren<Wall01Strike>();

        GroudDowns = GameObject.Find("GroundDowns");
        GDowm = GroudDowns.GetComponentsInChildren<GroundDowm>();


        InvisivleWall = GameObject.Find("InvisibleWall");
       

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
        foreach(SpriteRenderer StabSP in StabsSP)
        {
            saves.StabSpriteEnable.Add(StabSP.enabled);
        }
        // 导弹
        foreach (MissileActivate MissileMa in MissilesMa)
        {
            saves.MissileIsLaunch.Add(MissileMa.IsLaunch);
        }
        // 云朵
        foreach (CloudActivate CloudCa in CloudsCa)
        {
            saves.CloudSpriteEnable.Add(CloudCa.IsCloud);
        }
        // 带蘑菇的墙头
        foreach (Wall01Strike wall in WallStrike)
        {
            saves.WallNullIsTrigger.Add(wall.IsTigger);
        }
        // 下坠的砖块
        foreach (GroundDowm ground in GDowm)
        {
            saves.GroundDownIsGravity.Add(ground.IsGravity);
        }

        // 隐形砖块
        saves.InvisivleWall = InvisivleWall.GetComponent<SpriteRenderer>().enabled;
        // 角色位置
        saves.PlayerTransform = Player.transform.position.x.ToString() + "#" + Player.transform.position.y.ToString();
        // 敌人位置
        saves.EnemyTransfrom = EnemySuper.transform.position.x.ToString() + "#" + Player.transform.position.y.ToString();



        SaveXml(saves);
    }

    //加载游戏
    private void LoadGame(GameSaves saves)
    {
        int i=0;
        foreach (SpriteRenderer StabSP in StabsSP)
        {
            StabSP.enabled = saves.StabSpriteEnable[i];
            i++;
        }
        i = 0;
        foreach (MissileActivate MissileMa in MissilesMa)
        {
            MissileMa.GetComponent<MissileActivate>().IsLaunch =saves.MissileIsLaunch[i];
            i++;
        }

        i = 0;
        foreach (CloudActivate CloudCa in CloudsCa)
        {
            CloudActivate ca = CloudCa.GetComponent<CloudActivate>();
            ca.IsCloud= saves.CloudSpriteEnable[i];
            ca.Back();
            i++;
        }

        i = 0;
        foreach (Wall01Strike wall in WallStrike)
        {
            Wall01Strike w=wall.GetComponent<Wall01Strike>();
            w.IsTigger = saves.MissileIsLaunch[i];
            w.Back();
            i++;
        }
        i = 0;
        foreach (GroundDowm ground in GDowm)
        {
            GroundDowm g = ground.GetComponent<GroundDowm>();
            g.IsGravity = saves.GroundDownIsGravity[i]; 
            g.Back();
            i++;
        }



        InvisivleWall.GetComponent<SpriteRenderer>().enabled = saves.InvisivleWall;
        InvisivleWall.GetComponent<InvisibleWallActivate>().IsActivity = saves.InvisivleWall;

        string[] local= saves.PlayerTransform.Split('#');
        Player.transform.position = new Vector3(float.Parse(local[0]), float.Parse(local[1]), 0);

        string[] EnemyLocal = saves.EnemyTransfrom.Split('#');
        EnemySuper.transform.position = new Vector3(float.Parse(EnemyLocal[0]), float.Parse(EnemyLocal[1]), 0);
        EnemySuper.GetComponent<EnemySuper>().enabled = false;
        EnemySuper.GetComponent<EnemySuper>().Friction();
        GameObject.Find("Enemys").GetComponent<EnemysActivity>().IsActivity = true;
    }
    

    // 存档到xml文件
    private void SaveXml(GameSaves saves)
    {
        string filePath = Application.dataPath + "/StreamingAssets" + "/Archive.xml";
        // 创建xml文档
        XmlDocument xmlDoc = new XmlDocument();
        //根节点
        XmlElement root = xmlDoc.CreateElement("save");
        //跟节点中的值
        root.SetAttribute("name", "fiel01");

        XmlElement colliders;
        XmlElement Stabs;
        XmlElement Clouds;
        XmlElement Missiles;
        XmlElement Stab;
        XmlElement Cloud;
        XmlElement Missile;
        XmlElement PlayerTransfrom;
        XmlElement EnemyTransform;

        XmlElement Walls;
        XmlElement WallStrike;

        XmlElement InvisivleWall;


        XmlElement GroundS;
        XmlElement GrounDown;


        colliders = xmlDoc.CreateElement("colliders");
        for(int i = 0; i < saves.StabSpriteEnable.Count; i++)
        {
            Stabs = xmlDoc.CreateElement("Stabs");
            Stab = xmlDoc.CreateElement("Stab");
            Stab.InnerText = saves.StabSpriteEnable[i].ToString();
            Stabs.AppendChild(Stab);
            colliders.AppendChild(Stabs);
        }
        for (int i = 0; i < saves.CloudSpriteEnable.Count; i++)
        {
            Clouds = xmlDoc.CreateElement("Clouds");
            Cloud = xmlDoc.CreateElement("Cloud");
            Cloud.InnerText = saves.CloudSpriteEnable[i].ToString();
            Clouds.AppendChild(Cloud);
            colliders.AppendChild(Clouds);
        }
        for (int i = 0; i < saves.MissileIsLaunch.Count; i++)
        {
            Missiles = xmlDoc.CreateElement("Missiles");
            Missile = xmlDoc.CreateElement("Missile");
            Missile.InnerText = saves.MissileIsLaunch[i].ToString();
            Missiles.AppendChild(Missile);
            colliders.AppendChild(Missiles);
        }
        for (int i = 0; i < saves.WallNullIsTrigger.Count; i++)
        {
            Walls = xmlDoc.CreateElement("Walls");
            WallStrike = xmlDoc.CreateElement("WallStrike");
            WallStrike.InnerText = saves.WallNullIsTrigger[i].ToString();
            Walls.AppendChild(WallStrike);
            colliders.AppendChild(Walls);
        }

        for (int i = 0; i < saves.GroundDownIsGravity.Count; i++)
        {
            GroundS = xmlDoc.CreateElement("GroundS");
            GrounDown = xmlDoc.CreateElement("GrounDown");
            GrounDown.InnerText = saves.GroundDownIsGravity[i].ToString();
            GroundS.AppendChild(GrounDown);
            colliders.AppendChild(GroundS);
        }


        root.AppendChild(colliders);

        InvisivleWall = xmlDoc.CreateElement("InvisivleWall");
        InvisivleWall.InnerText = saves.InvisivleWall.ToString();
        root.AppendChild(InvisivleWall);

        PlayerTransfrom = xmlDoc.CreateElement("PlayerTransfrom");
        PlayerTransfrom.InnerText = saves.PlayerTransform;
        root.AppendChild(PlayerTransfrom);

        EnemyTransform = xmlDoc.CreateElement("EnemyTransform");
        EnemyTransform.InnerText = saves.EnemyTransfrom;
        root.AppendChild(EnemyTransform);

        xmlDoc.AppendChild(root);
        xmlDoc.Save(filePath);
    }


    // 读取xml文件
    private GameSaves LoadXml()
    {
        string filePath = Application.dataPath + "/StreamingAssets" + "/Archive.xml";
        GameSaves saves = new GameSaves();
        if (File.Exists(filePath))
        {
            // 加载xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            //通过节点遍历元素
            XmlNodeList Stabs = xmlDoc.GetElementsByTagName("Stabs");
            foreach(XmlNode stab in Stabs)
            {
                saves.StabSpriteEnable.Add(bool.Parse(stab.ChildNodes[0].InnerText));
            }
            // 云朵
            XmlNodeList Clouds = xmlDoc.GetElementsByTagName("Clouds");
            foreach (XmlNode cloud in Clouds)
            {
                saves.CloudSpriteEnable.Add(bool.Parse(cloud.ChildNodes[0].InnerText));
            }
            // 导弹
            XmlNodeList Missiles = xmlDoc.GetElementsByTagName("Missiles");
            foreach (XmlNode missile in Missiles)
            {
                saves.MissileIsLaunch.Add(bool.Parse(missile.ChildNodes[0].InnerText));
            }
            // 蘑菇墙头
            XmlNodeList Walls = xmlDoc.GetElementsByTagName("Walls");
            foreach (XmlNode WallStrike in Walls)
            {
                saves.MissileIsLaunch.Add(bool.Parse(WallStrike.ChildNodes[0].InnerText));
            }
            // 下坠砖块
            XmlNodeList grounds = xmlDoc.GetElementsByTagName("GroundS");
            foreach (XmlNode ground in grounds)
            {
                saves.GroundDownIsGravity.Add(bool.Parse(ground.ChildNodes[0].InnerText));
            }

            saves.InvisivleWall = bool.Parse(xmlDoc.GetElementsByTagName("InvisivleWall")[0].InnerText);
            saves.PlayerTransform = xmlDoc.GetElementsByTagName("PlayerTransfrom")[0].InnerText;
            saves.EnemyTransfrom = xmlDoc.GetElementsByTagName("EnemyTransform")[0].InnerText;
        }
        return saves;
    }
}
