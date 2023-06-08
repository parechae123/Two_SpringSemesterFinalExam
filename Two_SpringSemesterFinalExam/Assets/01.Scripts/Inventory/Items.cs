using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class items
{
    public string flavorText;
    public string iconPath;
    public int ItemIndex;
    public abstract void SetItemValues();
    public abstract void ItemEffect();

}
public class HPpotion : items
{
    public override void SetItemValues()
    {
        flavorText = "�����̴�~";
        iconPath = "ItemIcon/Potion";
        ItemIndex = 1;
    }
    public override void ItemEffect()
    {

    }
}
public class HeadArmor : items
{

    public override void SetItemValues()
    {
        Debug.Log("���");
        flavorText = "����̴�~";
        iconPath = "ItemIcon/helmets";
        ItemIndex = 11;
    }
    public override void ItemEffect()
    {

    }
}
public class NullSlot : items
{

    public override void SetItemValues()
    {
        flavorText = "���̴�~";
        iconPath = "ItemIcon/null";
        ItemIndex = 0;
    }
    public override void ItemEffect()
    {

    }
}
