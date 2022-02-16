using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudActivate : MonoBehaviour
{
    public Sprite cloud2_01;
    public Sprite cloud2_02;

    public Sprite cloud_01;
    public Sprite cloud_02;
    private bool isCloud = true;
    public bool IsCloud
    {
        set { isCloud = value; }
        get { return isCloud; }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player!=null && isCloud)
        {
            SpriteRenderer[] srs=GetComponentsInChildren<SpriteRenderer>();
            srs[0].sprite = cloud2_01;
            srs[1].sprite = cloud2_02;
            player.PlayerDead();
            isCloud = false;
        }
    }

    public void Back()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        srs[0].sprite = cloud_01;
        srs[1].sprite = cloud_02;
    }

}
