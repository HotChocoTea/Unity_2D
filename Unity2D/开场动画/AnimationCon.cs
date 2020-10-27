using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationCon : MonoBehaviour
{
    public GameObject []images;
   
    public float displaySpeed=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( Appear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Disappear()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].GetComponent<Image>().DOFade(0, 1.0f);
        }      
    }
   


    IEnumerator Appear()
    {
        for (int i = 0; i < 4; i++)
        {
            images[i].GetComponent<Image>().DOFade(1, 3.0f);
            yield return new WaitForSeconds(displaySpeed);
        }
        yield return new WaitForSeconds(2.0f);
        Disappear();
        yield return new WaitForSeconds(1.0f);
        for (int i = 4; i < images.Length; i++)
        {
            images[i].GetComponent<Image>().DOFade(1, 3.0f);
            yield return new WaitForSeconds(displaySpeed);
        }
        yield return new WaitForSeconds(2.0f);
        Disappear();
    }

}
