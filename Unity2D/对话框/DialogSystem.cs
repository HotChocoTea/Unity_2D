using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;



    [Header("文本文件")]
    public TextAsset textFile;
    public int index;//文本的行数
    public float textSpeed;

    [Header("头像")]
    public Sprite faceA;
    public Sprite faceB;
   


    private bool textFinished;
    private bool cancel;
    List<string> textList = new List<string>();
    void Awake()
    {
        textLabel.fontSize = 10;
        GetText(textFile); 
        
    }
    //这个是在start前就调用的
    private void OnEnable()
    {
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (index>=textList.Count && Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetMouseButtonDown(0) )
        {
            //textFinished为真时，才能按R键，否则会多次调用协程
            if (textFinished && !cancel)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished )
            {
                cancel = !cancel;
            }
           
        }
    }

    private void  GetText(TextAsset textFile)
    {
        textList.Clear();
        index = 0;
        var lineData=   textFile.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }


    IEnumerator SetTextUI ()
    {
        textFinished = false;//表示开始打字了
        textLabel.text = "";//每输出一行后，就清空
        //换头像
        switch (textList[index])
        {
            case "A":
                faceImage.sprite = faceA;
                index++;
                break;
            case "B":
                faceImage.sprite = faceB;
                index++;
                break;
            default:
                break;
        }
        int letter = 0;
        while (!cancel && letter<textList[index].Length-1 && index< textList.Count-1)
        {
            textLabel.text += textList[index][letter];//累加，将一行的文本一个一个的显示出来
            letter++;
            yield return new  WaitForSeconds(textSpeed);
        }    
       
        textLabel.text = textList[index];//直接输出
        cancel = false;
        textFinished = true;//打字完成
        index++;
    }
}
