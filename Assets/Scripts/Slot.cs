using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Slots Slots;
    public Image MarkerImage;
    public int SlotNumber;
    
    private bool isMarked = false;
    
    public void OnClick()
    {
        if (isMarked)
            return;
        
        // do clicky things
        Slots.OnSlotClicked(this);
    }

    public bool IsEmpty()
    {
        if (isMarked == false)
            return true;
        return false;
    }

    public void Reset(Sprite sprite)
    {
        isMarked = false;
        SetTexture(sprite);
    }
    
    public void Mark(Sprite markerSprite)
    {
        isMarked = true;
        SetTexture(markerSprite);
    }

    private void SetTexture(Sprite sprite)
    {
        MarkerImage.sprite = sprite;
    }
}
