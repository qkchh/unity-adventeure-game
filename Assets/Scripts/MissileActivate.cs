using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileActivate : MonoBehaviour
{
    private bool isLaunch=true;
    public bool IsLaunch
    {
        get { return isLaunch; }
        set { isLaunch = value; }
    }
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 33f && isLaunch)
        {
            GetComponent<Animation>().Play("MissileAnimation");
            isLaunch = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player!=null)
        {
            player.PlayerDead();
        }
    }
}
