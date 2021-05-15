using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : BaseView
{
    public Action OnResume;
    public Action OnBackToMenu;

    public void ResumeGame()
    {
        OnResume?.Invoke();
    }

    public void BackToMenu()
    {
        OnBackToMenu?.Invoke();
    }
}
