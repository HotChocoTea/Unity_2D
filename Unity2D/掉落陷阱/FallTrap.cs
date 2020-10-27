using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    public float fallSpeed=2.0f;
    public float disapearTime=2.0f;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fall()
    {
        //rig.velocity = new Vector2(0,fallSpeed*-1);
        rig.AddForce(new Vector2(0, fallSpeed * -1), ForceMode2D.Impulse);
        Invoke("Disapear", disapearTime);
    }
    private void Disapear()
    {
        this.gameObject.SetActive(false);
    }
}
