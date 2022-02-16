using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{

    public GameObject Wall;
    public GameObject Ground;
    public GameObject lucencyWall;
    public GameObject Stab;
    public GameObject InvisibleWall;
    // Start is called before the first frame update
    void Start()
    {
        createMap();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // 创建地图
    private void createMap()
    {
        CreateGround();
        // CreateUpWall();
        CreateLeftWall();
        CreateWall();
        CreateStab();
        CreateInvisible();
    }
    // 创建地形
    private void CreateGround()
    {
        for (int i = 0,k=0; i < 20; i++)
        {
            for (int j = 0; j < 2; j++,k++)
            {
                GameObject ground = GameObject.Instantiate(Ground);
                ground.name = "groud" + k;  //设置新建游戏对象名字
                // 设置地板位置
                ground.transform.position = new Vector3(i, j, 0);
            }
        }

        for (int i = 23, k = 0; i < 30; i++)
        {
            for (int j = 0; j < 2; j++, k++)
            {
                GameObject ground = GameObject.Instantiate(Ground);
                ground.name = "groud" + k;  //设置新建游戏对象名字
                // 设置地板位置
                ground.transform.position = new Vector3(i, j, 0);
            }
        }

        for (int i = 33, k = 0; i < 40; i++)
        {
            for (int j = 0; j < 2; j++, k++)
            {
                GameObject ground = GameObject.Instantiate(Ground);
                ground.name = "groud" + k;  //设置新建游戏对象名字
                // 设置地板位置
                ground.transform.position = new Vector3(i, j, 0);
            }
        }
    }

    private void CreateWall()
    {
        for(int i = 9,k=0; i < 13; i++,k++)
        {
            GameObject wall =GameObject.Instantiate(Wall);
            wall.name = "wall" + k;
            // 设置墙头位置
            wall.transform.position = new Vector3(i, 4, 0);
        }
        for (int i = 17, k = 0; i < 20; i++, k++)
        {
            GameObject wall = GameObject.Instantiate(Wall);
            wall.name = "wall" + k;
            // 设置墙头位置
            wall.transform.position = new Vector3(i, 7, 0);
        }
    }

    private void CreateStab()
    {
        for (int i = 10, k = 0; i < 13; i++, k++)
        {
            GameObject stab = GameObject.Instantiate(Stab);
            stab.name = "stab" + k;
            // 设置倒刺位置
            stab.transform.position = new Vector3(i, 3, 0);
        }
        for (int i = 18, k = 0; i < 20; i++, k++)
        {
            GameObject stab = GameObject.Instantiate(Stab);
            stab.name = "stab" + k;
            // 设置倒刺位置
            stab.transform.position = new Vector3(i, 6, 0);
        }
    }

    /*
    private void createWall()
    {
        for (int i = 0, k = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++, k++)
            {

            }
        }
    }
    */
    // 创建最左侧空气墙
    private void CreateLeftWall()
    {
        for(int i = -2,k=0; i < 0; i++)
        {
            for(int j = 0; j < 14; j++,k++)
            {
                GameObject leftWall = GameObject.Instantiate(lucencyWall);
                leftWall.name = "leftWall" + k;
                // 设置空气墙头位置
                leftWall.transform.position = new Vector3(i, j, 0);
            }
        }
    }
    /*
    // 创建上方空气墙
    private void CreateUpWall()
    {
        for (int i = 0, k = 0; i < 20; i++)
        {
            for (int j = 10; j < 12; j++, k++)
            {
                GameObject upWall = GameObject.Instantiate(lucencyWall);
                upWall.name = "upWall" + k;
                // 设置空气墙头位置
                upWall.transform.position = new Vector3(i, j, 0);
            }
        }
    }
    */

        // 构建隐形方块
    private void CreateInvisible()
    {
        GameObject invisibleWall = GameObject.Instantiate(InvisibleWall);
        invisibleWall.name = "InvisibleWall01";
        // 设置墙头位置
        invisibleWall.transform.position = new Vector3(20, 4, 0);
    }
}
