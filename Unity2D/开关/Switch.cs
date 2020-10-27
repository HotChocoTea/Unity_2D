using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    Animator myAnimator;
    public GameObject target;
    public string onMessage;
    public string offMessage;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        if (!isOn)
        {
            SetState(true);
        }
    }

    public void TurnOff()
    {
        if (isOn)
        {
            SetState(false);
        }
    }
    public void Toggle()
    {
        if (isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }
    private void SetState(bool on)
    {
        isOn = on;
        myAnimator.SetBool("start", on);
        if (on)
        {
            if (target != null && !string.IsNullOrEmpty(onMessage))
            {
                target.SendMessage(onMessage);
            }
        }
        else
        {
            if (target != null && !string.IsNullOrEmpty(offMessage))
            {
                target.SendMessage(offMessage);
            }
        }
    }
}
