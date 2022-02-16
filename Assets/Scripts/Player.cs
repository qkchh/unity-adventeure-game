using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rig;
    [Header("玩家速度")]
    public int moveSpeed;
    public int jumpSpeed;
    public float FallMultiplier; // 下坠的加速度
    // public float UpMultiplier;  // 上升的速度
    [Header("其他")]
    public float AccelerateTime;
    public Vector2 PointOffset; //偏移方向
    public Vector2 Size;  // 偏移大小
    public LayerMask GroundLayerMask; // 触底的物体


    private float velocityX;
    private bool isJump = true;
    private bool isBig = true;

    // 定义事件戳
    private float BigStartTime = 0, BigKeepTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        PlayerBig();
        dead();
    }

    private void FixedUpdate()
    {
        PlayreMove();
    }


    // 角色移动跳跃
    private void PlayreMove()
    {
   
        // 实现左右移动 
        if (Input.GetAxis("Horizontal") > 0)
        {
            // 实现向右平滑移动
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, moveSpeed * Time.deltaTime * 60, ref velocityX, AccelerateTime), Rig.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            // 实现向左平滑移动
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, moveSpeed * Time.deltaTime * 60 * -1, ref velocityX, AccelerateTime), Rig.velocity.y);
        }
        else
        {
            // 实现向停止移动
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, 0, ref velocityX, AccelerateTime), Rig.velocity.y);
        }
            

        // 实现跳跃
        if (Input.GetAxisRaw("Jump") == 1 && !isJump)
        {
            Rig.velocity = new Vector2(Rig.velocity.x, jumpSpeed);
            isJump = true;
        }
        // 判断是否触屏到地板
        if (Input.GetAxisRaw("Jump") == 0 && OnGround())
        {
            isJump = false;
        }

        // 当玩家下坠时快一点
        if (Rig.velocity.y <= 0)
        {
            Rig.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.fixedDeltaTime;
        }
        // 上升减缓
        /*
        if(Rig.velocity.y>0&& Input.GetAxisRaw("Jump") != 1)
        {
            Rig.velocity += Vector2.up * Physics2D.gravity.y * (UpMultiplier - 1) * Time.fixedDeltaTime;
        }
        */

        //===========按下E键与NPC交互====
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(Rig.position, new Vector2(-1, 0), 1, LayerMask.GetMask("npc"));
            if (hit.collider != null)
            {
                NpcDialog npc = hit.collider.GetComponent<NpcDialog>();
                if (npc != null)
                {
                    npc.ShowDialog();
                }
            }
        }
    }

    // 触地检测
    bool OnGround()
    {
        Collider2D coll = Physics2D.OverlapBox((Vector2)transform.position + PointOffset, Size, 0, GroundLayerMask);
        if (coll != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // 碰撞检测显现框
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + PointOffset, Size);
    }


   
    private void dead()
    {
        if (transform.position.y < 0)
        {
            PlayerDead();
        }
    }
    // 角色死亡
    public void PlayerDead()
    {
        if(!(transform.localScale.x > 1 && transform.position.y > 0))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().isDead = true;
            gameObject.SetActive(false);
        }
       
    }
    
    // 角色变大状态
    private void PlayerBig()
    {
        if ((transform.localScale.x>1 || transform.localScale.y > 1) && isBig)
        {
            BigStartTime = Time.time;
            isBig = false;
        }
        if (BigStartTime != 0)
        {
            BigKeepTime = Time.time;
           if(BigKeepTime - BigStartTime >= 10)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Size = new Vector2((float)0.3, (float)0.6);
                isBig = true;
            }
        }
    }

}
