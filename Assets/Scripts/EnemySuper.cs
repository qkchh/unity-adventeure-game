using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuper : MonoBehaviour
{


    public Rigidbody2D Rig;
    [Header("敌人速度")]
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



    private Rigidbody2D GroudDwon;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        GroudDwon = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Dead();

        if (GroudDwon.drag != 0)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                GroudDwon.drag = 0;
            }
        }
    }

    private void EnemyMove()
    {

        // 实现左右移动 
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // 实现向右平滑移动
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, moveSpeed * Time.deltaTime * 60 * -1, ref velocityX, AccelerateTime), Rig.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // 实现向左平滑移动
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, moveSpeed * Time.deltaTime * 60 , ref velocityX, AccelerateTime), Rig.velocity.y);
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
        if (Rig.velocity.y < 0)
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
    }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.PlayerDead();
        }
    }

    private void Dead()
    {
        if (transform.position.y < 0)
        {
            gameObject.SetActive(false);
        }
    }



    // 设置初始摩擦力
    public void Friction()
    {
        GroudDwon.drag = 1000;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Timer = 0.3f;
    }
}
