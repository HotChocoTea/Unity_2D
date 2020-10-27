using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    /// <summary>
    /// 控制方块的运动的，应该比较简易明了，就不阐述了。。。
    /// </summary>
    public float speed;
    public bool isHorizontal;
    public float duration=2.0f;
    private Rigidbody2D rig;
    private float orientationX=1;
    private float orientationY=1;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ControlMovement();
    }
    private void MoveX()
    {
        rig.velocity = new Vector2(orientationX*speed * Time.fixedDeltaTime, 0);
    }
    private void MoveY()
    {
        rig.velocity = new Vector2(0, orientationY * speed * Time.fixedDeltaTime);
    }

    private void Stop()
    {
        rig.velocity = new Vector2(0, 0);
    }
    private void Timer()
    {
        duration -= Time.fixedDeltaTime;
        if (duration<=0)
        {
            ChangeOrientation();
            duration = timer;
        }
    }
    private void ChangeOrientation()
    {
        Stop();
        orientationX = -orientationX;
        orientationY = -orientationY;
    }
    private void ControlMovement()
    {
        if (isHorizontal)
        {
           
            MoveX();
            Timer();
        }
        else
        {
            MoveY();
            Timer();
        }
    }
}
