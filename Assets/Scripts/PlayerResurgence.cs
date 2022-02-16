using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家复活
/// </summary>
public class PlayerResurgence : MonoBehaviour
{
    private GameObject Player;
    private bool isReGamePlan;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        isReGamePlan = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
