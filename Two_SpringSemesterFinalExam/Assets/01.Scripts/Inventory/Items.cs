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
        GameManager.GMinstance().plrStat.stat.hp += 10;
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
        GameManager.GMinstance().playerStatSave.maxHp += 10;
        GameManager.GMinstance().plrStat.stat.maxHp += 10;
        UIManager.Instance().StatusTextUpdate("hp");
        UIManager.Instance().HPValueChanged();
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
        GameManager.GMinstance().playerStatSave.maxHp += 10;
        GameManager.GMinstance().plrStat.stat.maxHp += 10;
        UIManager.Instance().StatusTextUpdate("hp");
        UIManager.Instance().HPValueChanged();
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
        GameManager.GMinstance().playerStatSave.moveSpeed += 1;
        GameManager.GMinstance().plrStat.stat.moveSpeed += 1;
        UIManager.Instance().StatusTextUpdate("moveSpeed");
    }
}
public class Bow : items
{
    public override void SetItemValues()
    {
        flavorText = "¶¯¶¯";
        iconPath = "ItemIcon/bow";
        ItemIndex = 101;
    }
    public override void ItemEffect()
    {
        GameManager.GMinstance().playerStatSave.atk += 10;
        GameManager.GMinstance().plrStat.stat.atk += 10;
        UIManager.Instance().StatusTextUpdate("atk");
        //ÇÃ·¹ÀÌ¾î ½ºÅÝÀ» ½Ï´Ù GMÀ¸·Î ¿Å°ÜÁà¾ßÇÒµí
    }
}