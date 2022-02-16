using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    public Sprite ReStart01;
    public Sprite ReStart02;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = ReStart02;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = ReStart01;
    }

}
