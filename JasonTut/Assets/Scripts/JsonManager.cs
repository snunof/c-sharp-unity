using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Item
{
	public int ID;
	public string Name;
	public string Dis;

	public Item(int id, string name, string dis)
	{
		ID = id;
		Name = name;
		Dis = dis;
	}
}
public class JsonManager : MonoBehaviour {


	public List<Item> ItemList = new List<Item>(); //Origin Item List
	public List<Item> MyInventory = new List<Item>(); //My Item List


	// Use this for initialization
	void Start () {
		
		ItemList.Add(new Item(0,"Sword", "This is sword"));
		ItemList.Add(new Item(1,"Dress", "This is dress"));
		ItemList.Add(new Item(2,"portion", "This is portion"));
		ItemList.Add(new Item(3,"Lance", "This is Lance"));

	}
	
	public void SaveFunc()
	{
		Debug.Log("저장합니다.");
		//for(int i=0; i<ItemList.Count; i++)
		//{
		//	Debug.Log(ItemList[i].ID);
		//}

		JsonData ItemJson = JsonMapper.ToJson(ItemList);
		
		File.WriteAllText(Application.dataPath + "/Resource/ItemData.json" ,ItemJson.ToString());

	}
	public void LoadFunc()
	{
		
		Debug.Log("불러옵니다.");

		StartCoroutine(LoadCo());

	}


	IEnumerator LoadCo()
	{
		string Jsonstring = File.ReadAllText(Application.dataPath + "/Resource/ItemData.json");

		Debug.Log(Jsonstring);

		JsonData itemData = JsonMapper.ToObject(Jsonstring);

		ParsingJsonItem(itemData);
		yield return null;
	} 

	private void ParsingJsonItem(JsonData name)
	{
		for(int i=0; i < name.Count; i++)
		{
			Debug.Log(name[i]["ID"]);	

			for(int j=0; j < ItemList.Count; j++)
			{
				if(name[i]["ID"].ToString() == ItemList[j].ID.ToString())
				{
					MyInventory.Add(ItemList[j]);
				}
			}

		}

	for(int i =0; i < MyInventory.Count; i++)
	{
		Debug.Log(MyInventory[i].Name);
	}



	}

}
