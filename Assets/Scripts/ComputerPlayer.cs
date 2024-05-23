using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    public TicTacToeGame TicTacToeGame;
    public GameMode GameMode;
    public Slots Slots;
    public TicTacToeResolver TicTacToeResolver;
    
    public void PlayComputerTurnAfterPause()
    {
        if (GameMode.GetOpponentType() == OpponentType.EasyComputer)
        {
            PlayEasyComputerMove();
        }
        else if (GameMode.GetOpponentType() == OpponentType.HardComputer)
        {
            PlayHardComputerMove();
        }
    }

    private void PlayHardComputerMove()
    {
        // if can win
        bool hasWon = TryToWin();
        if (hasWon)
            return;
        
        // if can block
        bool hasBlocked = TryToBlock();
        if (hasBlocked)
            return;
        
        // random slot
        PlayMarkerInRandomSlot();
    }

    private bool TryToWin()
    {
        return TryToPlayBestMoveForPlayer(TicTacToeGame.CurrentMarkerType());
    }

    private bool TryToBlock()
    {
        return TryToPlayBestMoveForPlayer(TicTacToeGame.FirstPlayerMarkerType());
    }

    private bool TryToPlayBestMoveForPlayer(MarkerType markerType)
    {
        int bestSlotIndex = TicTacToeResolver.FindBestSlotIndexForPlayer(Slots.SlotOccupants(), markerType);
        if (bestSlotIndex != -1)
        {
            TicTacToeGame.PlaceMarkerInSlot((Slots.GetSlot(bestSlotIndex)));
            return true;
        }
        return false;
    }
    private void PlayEasyComputerMove()
    {
        PlayMarkerInRandomSlot();
    }
    private void PlayMarkerInRandomSlot()
    {
        Slot slot = Slots.RandomFreeSlot();
        TicTacToeGame.PlaceMarkerInSlot(slot);
    }
}
