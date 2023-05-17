using System;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameStateView : MonoBehaviour
{
    [SerializeField] private Button[] _updateButtons;
    [SerializeField] private GameObject[] _panels;

    public void InitButtons(Action update)
    {
        _updateButtons.ForEach(x => x.onClick.AddListener(update.Invoke));
    }

    public void OpenViewPanel(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                ChangePanel(0, 1);
                break;
            case GameState.Win:
                ChangePanel(1, 0);
                break;
            case GameState.Lose:
                ChangePanel(2, 0);
                break;
        }
    }

    void ChangePanel(int indexEnable, int time)
    {
        _panels.ForEach(x => x.SetActive(false));
        _panels[indexEnable].SetActive(true);
        Time.timeScale = time;
    }
}