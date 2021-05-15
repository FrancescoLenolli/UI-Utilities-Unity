using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        Owner.UI.MenuView.OnStart += StartGame;
        Owner.UI.MenuView.OnQuit += QuitGame;

        Owner.UI.MenuView.ShowView();
    }

    public override void DestroyState()
    {
        Owner.UI.MenuView.HideView();

        Owner.UI.MenuView.OnStart -= StartGame;
        Owner.UI.MenuView.OnQuit -= QuitGame;

        base.DestroyState();
    }

    private void StartGame()
    {
        Owner.ChangeState(new GameState());
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
