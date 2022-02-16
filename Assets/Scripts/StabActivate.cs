using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabActivate : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        // 触碰后玩家死亡
        if (player != null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            player.PlayerDead();
        }
    }
}
