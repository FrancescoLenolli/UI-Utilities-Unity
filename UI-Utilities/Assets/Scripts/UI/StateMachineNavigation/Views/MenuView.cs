using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView
{
    public Action OnStart;
    public Action OnQuit;

    public void StartGame()
    {
        OnStart?.Invoke();
    }

    public void QuitGame()
    {
        OnQuit?.Invoke();
    }
}
