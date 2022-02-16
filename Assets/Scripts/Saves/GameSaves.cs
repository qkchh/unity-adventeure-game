using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaves
{
    // 倒刺精灵是否显示
    public List<bool> StabSpriteEnable=new List<bool>();
    public List<bool> CloudSpriteEnable = new List<bool>();
    public List<bool> MissileIsLaunch = new List<bool>();
    public List<bool> WallNullIsTrigger = new List<bool>();
    public List<bool> GroundDownIsGravity = new List<bool>();

    public bool InvisivleWall;
    public string PlayerTransform;
    public string EnemyTransfrom;
  

}
