using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PanelUIObj;
    void Start()
    {
        
    }

    public void InactivatePanel()
    {
        PanelUIObj.SetActive(false);
    }
    public void InActivatePanel()
    {
        PanelUIObj.SetActive(true);
    }
}
