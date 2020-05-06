using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public static MenuPanel Instance { get; private set; }

    private CanvasGroup _canvasGroup;
    private bool isOpen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        closePanels();
    }

    public void OpenClose()
    {
        if(isOpen)
        {
            closePanels();
        }
        else
        {
            openPanels();
        }
    }

    private void openPanels()
    {
        if(_canvasGroup != null)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
            Time.timeScale = 0;
            isOpen = true;
        }
    }

    private void closePanels()
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
            Time.timeScale = 1;
            isOpen = false;
        }
    }
}
