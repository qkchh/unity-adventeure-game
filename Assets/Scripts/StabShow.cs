using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabShow : MonoBehaviour
{
    private GameObject Player;
    private bool isActiv=true;
    private GameObject Stabs;
    // Start is called before the first frame update
    void Start()
    {
        Stabs=GameObject.Find("Stabs");
        Stabs.SetActive(false);
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 17 && isActiv)
        {
            Stabs.SetActive(true);
            isActiv = false;
        }
        if(Player.transform.position.x<5 && !isActiv)
        {
            Stabs.SetActive(false);
            isActiv = true;
        }
    }
}
