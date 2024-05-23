using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour
{
    public Image WinnerImage;
    public Sprite PantherSprite;
    public Sprite PawSprite;
    public Sprite TieSprite;
    public Sprite BlankSprite;
    public void Reset()
    {
       Show(MarkerType.None);
    }
    public void Show(MarkerType markerType)
    {
        if (markerType == MarkerType.Paw)
            WinnerImage.sprite = PawSprite;
        else if (markerType == MarkerType.Panther)
            WinnerImage.sprite = PantherSprite;
        else if (markerType == MarkerType.Tie)
            WinnerImage.sprite = TieSprite;
        else
            WinnerImage.sprite = BlankSprite;
    }
}
