using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        Owner.UI.PauseView.OnResume += ResumeGame;
        Owner.UI.PauseView.OnBackToMenu += BackToMenu;

        Owner.UI.PauseView.ShowView();
    }

    public override void DestroyState()
    {
        Owner.UI.PauseView.HideView();

        Owner.UI.PauseView.OnResume -= ResumeGame;
        Owner.UI.PauseView.OnBackToMenu -= BackToMenu;

        base.DestroyState();
    }

    private void ResumeGame()
    {
        Owner.ChangeState(new GameState());
    }

    private void BackToMenu()
    {
        Owner.ChangeState(new MenuState());
    }
}
