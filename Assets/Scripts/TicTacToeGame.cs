using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public Slots Slots;
    public TicTacToeResolver TicTacToeResolver;
    public TurnDisplay TurnDisplay;
    public WinnerDisplay WinnerDisplay;
    public GameMode GameMode;
    public Sounds Sounds;
    public ComputerPlayer ComputerPlayer;
    
    private MarkerType currentMarkertype;
    private MarkerType firstPlayerMarkerType;
    private int numberOfTurnsPlayed;
    private bool isWaitingForComputerToPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void OnSlotClicked(Slot slot)
    {
        if (!isWaitingForComputerToPlay)
            PlaceMarkerInSlot(slot);
    }

    public void OnResetButtonClicked()
    {
        Sounds.PlayResetButtonSound();
        Reset();
    }

    public void Reset()
    {
        ResetPlayers();
        ResetDisplays();
        numberOfTurnsPlayed = 0;
        ResetSlots();
        ResetSounds();
    }

    public void ChangeOpponent()
    {
        Reset();
    }

    public MarkerType CurrentMarkerType()
    {
        return currentMarkertype;
    }

    public MarkerType FirstPlayerMarkerType()
    {
        return firstPlayerMarkerType;
    }
    public void PlaceMarkerInSlot(Slot slot)
    {
        if (GameNotOver())
        {
            UpdateSlotImage(slot);
            Sounds.PlayRandomMarkerSound();
            CheckForWinner();
        
            EndTurn();
        }
    }

    private void ResetSlots()
    {
        Slots.Reset();
    }

    private void ResetSounds()
    {
        Sounds.Reset();
    }

    private void ResetPlayers()
    {
        TicTacToeResolver.Reset();
        RandomizePlayer();
        firstPlayerMarkerType = currentMarkertype;
        isWaitingForComputerToPlay = false;
    }

    private void ResetDisplays()
    {
        TurnDisplay.Reset(currentMarkertype);
        WinnerDisplay.Reset();
    }
    private bool GameNotOver()
    {
        return TicTacToeResolver.NoWinner();
    }

    private void CheckForWinner()
    {
        numberOfTurnsPlayed++;
        if (numberOfTurnsPlayed < 5)
            return;
        TicTacToeResolver.CheckForEndOfGame(Slots.SlotOccupants());
    }

    private void EndTurn()
    {
        if (GameNotOver())
            ChangePlayer();
        else
            ShowWinner();
    }

    private void ShowWinner()
    {
        PlayEndOfGameSound();
        WinnerDisplay.Show(TicTacToeResolver.Winner());
    }

    private void PlayEndOfGameSound()
    {
        if (TicTacToeResolver.Winner() == MarkerType.Tie)
            Sounds.PlayTieGameSound();
        else
            Sounds.PlayGameOverSound();
    }

    private void ChangePlayer()
    {
        if (currentMarkertype == MarkerType.Paw)
            currentMarkertype = MarkerType.Panther;
        else
            currentMarkertype = MarkerType.Paw;
        TurnDisplay.Show(currentMarkertype);

        SeeIfComputerShouldPlayer();
    }

    private void SeeIfComputerShouldPlayer()
    {
        if (IsHumanTurn())
            return;
        if (IsPlayingComputerOpponent())
            PlayComputerTurn();
    }

    private bool IsPlayingComputerOpponent()
    {
        return GameMode.GetOpponentType() != OpponentType.Human;
    }

    private void PlayComputerTurn()
    {
        StartCoroutine(PauseForComputerPlayer());
    }

    IEnumerator PauseForComputerPlayer()
    {
        isWaitingForComputerToPlay = true;
        float secondsToWait = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(secondsToWait);
        isWaitingForComputerToPlay = false;
        ComputerPlayer.PlayComputerTurnAfterPause();
    }
    private bool IsHumanTurn()
    {
        return currentMarkertype == firstPlayerMarkerType;
    }
    private void UpdateSlotImage(Slot slot)
    {
        Slots.UpdateSlot(slot, currentMarkertype);
    }

    private void RandomizePlayer()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
            currentMarkertype = MarkerType.Panther;
        else
            currentMarkertype = MarkerType.Paw;
    }
}
