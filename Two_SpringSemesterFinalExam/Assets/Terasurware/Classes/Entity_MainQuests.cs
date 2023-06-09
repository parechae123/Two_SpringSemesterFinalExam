using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum questType
{
    inputQuest, diaLogQuest, arriveToPoint, huntingQuest
}
public class Entity_MainQuests : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		public string questName;
		public questType QuestType;
		public string questText;
		public int questGoalTotal;
		public int questGoalCount;
		public bool isQuestDone;
		public int rewardItemIndex;
		public int rewardItemAcount;
		public bool isRewardExist;
		public int exeReward;
		public string huntTarget;
	}
}

