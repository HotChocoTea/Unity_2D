using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InitButton : MonoBehaviour
{
    /// <summary>
    /// 这个是解决当鼠标点了按钮外的某处，已选的button会消失导致无法用键盘移动的小BUG
    /// </summary>
    private GameObject lastSelect;
    // Start is called before the first frame update
    void Start()
    {
        lastSelect = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject==null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
    }
}
