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
        flavorText = "Æ÷¼ÇÀÌ´ç~";
        iconPath = "ItemIcon/Potion";
        ItemIndex = 1;
    }
    public override void ItemEffect()
    {
        Debug.Log("Æ÷¼Ç»ç¿ë");
        GameManager.GMinstance().playerStatSave.hp += 10;
        //ÇÃ·¹ÀÌ¾î ½ºÅÝÀ» ½Ï´Ù GMÀ¸·Î ¿Å°ÜÁà¾ßÇÒµí
        UIManager.Instance().HPValueChanged();
    }
}
public class HeadArmor : items
{

    public override void SetItemValues()
    {
        Debug.Log("Çï¸ä");
        flavorText = "Çï¸äÀÌ´ç~";
        iconPath = "ItemIcon/helmets";
        ItemIndex = 100;
    }
    public override void ItemEffect()
    {
        
    }
}
public class NullSlot : items
{

    public override void SetItemValues()
    {
        flavorText = "³ÎÀÌ´ç~";
        iconPath = "ItemIcon/null";
        ItemIndex = 0;
    }
    public override void ItemEffect()
    {

    }
}
public class SlimeLiquid : items
{
    public override void SetItemValues()
    {
        flavorText = "²öÀû²öÀû";
        iconPath = "ItemIcon/mp";
        ItemIndex = 200;
    }
    public override void ItemEffect()
    {
        
    }
}
