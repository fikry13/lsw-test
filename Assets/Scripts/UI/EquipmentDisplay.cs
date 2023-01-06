using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
    [SerializeField]
    private Image _hairStyleIcon;
    [SerializeField]
    private Image _outfitIcon;
    [SerializeField]
    private Image _accessoryIcon;

    private void Start()
    {
        _hairStyleIcon.gameObject.SetActive(false);
        _outfitIcon.gameObject.SetActive(false);
        _accessoryIcon.gameObject.SetActive(false);
    }

    public void UpdateSprite(Hairstyle hairstyle, Outfit outfit, Accessory accessory)
    {
        _hairStyleIcon.gameObject.SetActive(hairstyle != null);
        _outfitIcon.gameObject.SetActive(outfit != null);
        _accessoryIcon.gameObject.SetActive(accessory != null);

        if(hairstyle != null)
        {
            _hairStyleIcon.sprite = hairstyle.icon;
        }
        if(outfit != null)
        {
            _outfitIcon.sprite = outfit.icon;
        }
        if(accessory != null)
        {
            _accessoryIcon.sprite = accessory.icon;
        }
    }
}
