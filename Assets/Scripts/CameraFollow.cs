using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; //获取角色对象
    public GameObject ReGamePlan;
    private float CameraX;
    private float InitLocalX;
    public bool isResurgence;
    // Start is called before the first frame update
    void Start()
    {
        InitLocalX = player.transform.position.x;
        CameraX = transform.position.x - InitLocalX;
    }

    // Update is called once per frame
    void Update()
    {
        // 角色复活
        if (!player.gameObject.activeSelf && isResurgence)
        {
            GameObject reGamePlan= GameObject.Instantiate(ReGamePlan);
            reGamePlan.transform.position=transform.position+new Vector3(0,0,10);
            reGamePlan.name = "ReGamePlan";
            isResurgence = false;
        }
    }

    private void FixedUpdate()
    {
        if (!(player.transform.position.x <= InitLocalX))
        {
            transform.position = new Vector3(player.transform.position.x + CameraX, transform.position.y, -10);
        }
    }
}
