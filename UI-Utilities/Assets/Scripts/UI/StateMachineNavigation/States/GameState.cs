using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        Owner.UI.GameView.OnPause += PauseGame;

        Owner.UI.GameView.ShowView();
    }

    public override void DestroyState()
    {
        Owner.UI.GameView.HideView();

        Owner.UI.GameView.OnPause -= PauseGame;

        base.DestroyState();
    }

    private void PauseGame()
    {
        Owner.ChangeState(new PauseState());
    }
}
