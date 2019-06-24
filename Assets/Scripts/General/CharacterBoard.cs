using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;

public class CharacterBoard : MonoBehaviour
{
    [SerializeField] private GameObject _enemyBoard;
    [SerializeField] private GameObject _enemyBoardText;
    [SerializeField] private GameObject _defenderBoard;
    [SerializeField] private GameObject _defenderBoardText;
    [SerializeField] private GameObject _board;

    [SerializeField] private Level _level;

    public void OpenCharacterBoard()
    {
        _board.SetActive(true);
        _defenderBoard.SetActive(true);
        _defenderBoardText.SetActive(true);
    }

    public void OnContinueToEnemyBoard()
    {
        _defenderBoard.SetActive(false);
        _defenderBoardText.SetActive(false);

        _enemyBoard.SetActive(true);
        _enemyBoardText.SetActive(true);
    }

    public void OnContinueToNextLevel()
    {
        _level.PlayNextLevelCampaignMode();
    }
}
