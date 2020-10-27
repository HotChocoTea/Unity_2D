using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRoataion=true;
    public Transform pointTrans;
    public float angel=3;
   
    public float aimAngel = 60;
    private float sum = 0;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoataion)
        {
            Toggle();
        }
       
    }

    private void Rotataion()
    {
        
        if (Mathf.Abs(sum) < Mathf.Abs(aimAngel))
        {
            transform.RotateAround(pointTrans.position, new Vector3(0, 0, 1), angel);
            sum += angel;
        }
        else
        {
            sum = 0;
            ChangeOrientation();
        }
    }
    private void ChangeOrientation()
    {
        angel = -angel;
    }
    private void Toggle()
    {
        Rotataion();
      
    }
   
}
