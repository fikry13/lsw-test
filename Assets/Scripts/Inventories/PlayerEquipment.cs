using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Hairstyle hairstyle { get; private set; }

    public Outfit outfit { get; private set; }

    public Accessory accessory { get; private set; }

    public Action<Hairstyle, Outfit, Accessory> onEquipmentChange;

    public Equipment Equip(Equipment equipment)
    {
        Equipment equipped = null;
        if (equipment.GetType() == typeof(Hairstyle))
        {
            if(hairstyle != null)
            {
                equipped = hairstyle;
            }
            hairstyle = (Hairstyle)equipment;
        }
        else if (equipment.GetType() == typeof(Outfit))
        {
            if (outfit != null)
            {
                equipped = outfit;
            }
            outfit = (Outfit)equipment;
        }

        else if (equipment.GetType() == typeof(Accessory))
        {
            if (accessory != null)
            {
                equipped = accessory;
            }
            accessory = (Accessory)equipment;
        }

        onEquipmentChange?.Invoke(hairstyle, outfit, accessory);

        return equipped;
    }

}
