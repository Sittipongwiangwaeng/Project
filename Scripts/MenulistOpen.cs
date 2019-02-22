using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenulistOpen : MonoBehaviour {

    public GameObject listPanel;
    

    public void OpenPanel()
    {
        if(listPanel != null)
        {
           
            bool isActive = listPanel.activeSelf;
            listPanel.SetActive(!isActive);
        }
    }
}
