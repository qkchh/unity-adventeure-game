using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 对话框的自动播放
/// </summary>
public class Dialog : MonoBehaviour
{
    private float InitTime;
    private float NewTime;
    private bool isText;
    // Start is called before the first frame update
    void Start()
    {
        InitTime = Time.time;
        isText = true;
    }

    // Update is called once per frame
    void Update()
    {
      
        NewTime = Time.time;
        if (NewTime - InitTime >= 3f && NewTime - InitTime < 6f)
        {
            GetComponent<Text>().text = "WD，左右键控制方向，空格键盘控制跳跃";
        }
        if (NewTime - InitTime >= 6f && NewTime - InitTime < 8f)
        {
            GetComponent<Text>().text = "按E键可以与我对话";
        }
        if (NewTime - InitTime >= 8f && isText)
        {
            gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(false);
            isText = false;
        }
    }
}
