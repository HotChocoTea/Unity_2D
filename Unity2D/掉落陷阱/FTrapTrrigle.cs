using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTrapTrrigle : MonoBehaviour
{
    public GameObject target;
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
        target.SendMessage("Fall", SendMessageOptions.DontRequireReceiver);
    }
}
