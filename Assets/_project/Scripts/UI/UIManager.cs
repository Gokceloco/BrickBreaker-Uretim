using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public VictoryUI victoryUI;
    public FailUI failUI;

    public void ShowMainMenu()
    {
        mainMenu.Show();
        victoryUI.Hide();
        failUI.Hide();
    }
    public void ShowVictoryUI()
    {
        victoryUI.Show(1.5f);
    }
    public void ShowFailUI()
    {
        failUI.Show(1f);
    }

    public void StartGameButtonPressed()
    {
        mainMenu.Hide();
        gameDirector.RestartLevel();
    }
    public void LoadNextLevelButtonPressed()
    {
        victoryUI.Hide();
        gameDirector.LoadNextLevel();
    }    
    public void RetryButtonPressed()
    {
        failUI.Hide();
        gameDirector.RestartLevel();
    }
}
