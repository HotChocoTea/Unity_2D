using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bool isOpen;
    private Collider2D mycollider;
    public BlockMovement blockMovement;
    void Start()
    {
        
        mycollider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Toggle()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
    public void Open()
    {
        if (!isOpen)
        {
            SetState(true);
        }
    }
    public void Close()
    {
        if (isOpen)
        {
            SetState(false);
        }
    }
    private void SetState(bool open)
    {
        isOpen = open;
        if (open==false)
        {
            blockMovement.Stop();
        }
        blockMovement.enabled = open;
    }
}
