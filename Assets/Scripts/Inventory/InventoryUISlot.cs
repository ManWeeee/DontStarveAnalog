using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    [SerializeField]
    Image backgroundImage;
    [SerializeField]
    Image icon;
    [SerializeField]
    Text number;
    [SerializeField]
    Text strength;

    public void Visible(InventorySlot item)
    {
        icon.color = new Color(255, 255, 255, 255);
        icon.sprite = item.GetItem.GetSprite;
        number.enabled = true;
        number.text = item.Amount.ToString();
        if (item.GetItem.GetStrength > 0)
        {
            number.enabled = false;
            strength.enabled = true;
            strength.text = item.GetItem.GetStrength.ToString() + "%";
        }
    }

    public void Invisible()
    {
        icon.color = new Color(0, 0, 0, 0);
        number.enabled = false;
        strength.enabled = false;
    }

    public void ChangeIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
