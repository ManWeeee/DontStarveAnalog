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

    public void Visible(int amount)
    {
        icon.color = new Color(255, 255, 255, 255);
        number.enabled = true;
        number.text = amount.ToString();
    }

    public void Invisible()
    {
        icon.color = new Color(0, 0, 0, 0);
        number.enabled = false;
    }

    public void ChangeIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
