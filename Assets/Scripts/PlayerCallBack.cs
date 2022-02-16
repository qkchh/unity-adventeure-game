using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCallBack : MonoBehaviour
{

    public delegate void callback(int a);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Resurgence(int a, int b, callback call)
    {
        int count = a + b;
         call(count);
    }
}
