using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public TicTacToeGame TicTacToeGame;
    public List<Slot> SlotsList;

    public Sprite PawSprite;
    public Sprite PantherSprite;
    public Sprite BlankSprite;

    public List<MarkerType> slotOccupants;
    public void OnSlotClicked(Slot slot)
    {
        TicTacToeGame.OnSlotClicked(slot);
    }

    public void UpdateSlot(Slot slot, MarkerType markerType)
    {
        SetSlotImage(slot, markerType);
        SetSlotOccupant(slot, markerType);
    }

    public List<MarkerType> SlotOccupants()
    {
        return slotOccupants;
    }
    
    public void Reset()
    {
        ResetSlotOccupants();
        ResetSlotImages();
    }

    public Slot GetSlot(int slotIndex)
    {
        return SlotsList[slotIndex];
    }

    public Slot RandomFreeSlot()
    {
        // find list of all empty slots
        List<int> emptySlotIndicies = FindEmptySlotIndicies();
        
        // {0, 3, 4}
        // pick random slot from list
        int randomIndex = Random.Range(0, emptySlotIndicies.Count);

        int randomSlotIndex = emptySlotIndicies[randomIndex];

        return SlotsList[randomSlotIndex];
    }

    private List<int> FindEmptySlotIndicies()
    {
        List<int> emptySlotIndicies = new List<int>();

        for (int i = 0; i < SlotsList.Count; i++)
        {
            if (SlotsList[i].IsEmpty())
                emptySlotIndicies.Add(i);
        }
        
        return emptySlotIndicies;
    }

    private void SetSlotOccupant(Slot slot, MarkerType markerType)
    {
        int slotIndex = slot.SlotNumber - 1;
        slotOccupants[slotIndex] = markerType;
    }

    private void SetSlotImage(Slot slot, MarkerType markerType)
    {
        if (markerType == MarkerType.Panther)
            slot.Mark(PantherSprite);
        else
            slot.Mark(PawSprite);
    }

    private void ResetSlotImages()
    {
        foreach (Slot slot in SlotsList)
            slot.Reset(BlankSprite);
    }
    public void ResetSlotOccupants()
    {
        slotOccupants = new List<MarkerType>();
        for (int i = 0; i < 9; i++)
            slotOccupants.Add(MarkerType.None);
    }
}
