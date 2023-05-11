using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class QuestLists_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/09.DataBaseXMLs/QuestLists.xls";
	private static readonly string exportPath = "Assets/09.DataBaseXMLs/QuestLists.asset";
	private static readonly string[] sheetNames = { "MainQuests","AdventurerGuild", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_MainQuests data = (Entity_MainQuests)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_MainQuests));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_MainQuests> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Entity_MainQuests.Sheet s = new Entity_MainQuests.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_MainQuests.Param p = new Entity_MainQuests.Param ();
						
					cell = row.GetCell(0); p.index = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.questName = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.questType = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.questText = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.questGoalTotal = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.questGoalCount = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.isQuestDone = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(7); p.rewardItemIndex = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.rewardItemAcount = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.isRewardExist = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(10); p.exeReward = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(11); p.huntTarget = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
