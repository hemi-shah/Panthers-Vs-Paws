using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TurnDisplay : MonoBehaviour
{
    public Image TurnImage;
    public Sprite PantherSprite;
    public Sprite PawSprite;

    public void Reset(MarkerType markerType)
    {
        Show(markerType);
    }
    public void Show(MarkerType markerType)
    {
        if (markerType == MarkerType.Paw)
            TurnImage.sprite = PawSprite;
        else
            TurnImage.sprite = PantherSprite;
    }
}
