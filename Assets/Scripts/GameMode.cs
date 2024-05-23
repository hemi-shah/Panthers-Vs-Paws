using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public TicTacToeGame TicTacToeGame;
    public Sounds Sounds;
    private OpponentType currentOpponentType;
    void Start()
    {
        currentOpponentType = OpponentType.Human;
    }

    public void OnButtonPressed(int buttonNumber)
    {
        OpponentType opponenetType = SetOpponentType(buttonNumber);
        ChangeOpponentType(opponenetType);
    }

    public OpponentType GetOpponentType()
    {
        return currentOpponentType;
    }

    private OpponentType SetOpponentType(int buttonNumber)
    {
        if (buttonNumber == 1)
            return OpponentType.EasyComputer;
        if (buttonNumber == 2)
            return OpponentType.Human;
        else
            return OpponentType.HardComputer;
    }

    private void ChangeOpponentType(OpponentType opponentType)
    {
        if (opponentType != currentOpponentType)
        {
            Sounds.PlayGameModeSound();
            currentOpponentType = opponentType;
            TicTacToeGame.ChangeOpponent();
        }
    }
}
