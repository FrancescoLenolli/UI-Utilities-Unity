using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : BaseView
{
    public Action OnPause;

    public void PauseGame()
    {
        OnPause?.Invoke();
    }
}
