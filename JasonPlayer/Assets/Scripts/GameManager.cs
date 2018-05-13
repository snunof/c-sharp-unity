using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;


public class User
{
	public int ID;
	public string Name;
	public int Level;
	public string Pos;   //Vector(0,0,0) -> 0/0/0 store
	public string Rotation;
	public string InventoryItemList; // Identity of Item
	public string JobType; // ID

	public User(int id, string name, int level, string pos, string rotation, string inventoryitemlist, string jobtype)
	{
		ID = id;
		Name = name;
		Level = level;
		Pos = pos;
		Rotation = rotation;
		InventoryItemList = inventoryitemlist;
		JobType = jobtype;
	}
}


public class InventoryItemList
{

}
public class Job
{

}
public class GameManager : MonoBehaviour {

	public static GameManager GM;
	public User Mycharacter;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		
		if(GM == null)
		{

			DontDestroyOnLoad(gameObject);
			GM = this;
		}
		else if(GM != this)
		{
			Destroy(gameObject);
		}
	}
	
	public void SaveBtn() //click button
	{

		StartCoroutine(SaveUserData());

	}

	IEnumerator SaveUserData()
	{

		int ID = 0;
		string Name = "Jaejung";
		int Level = 0;
		string Pos = Player.transform.position.x + "/" + Player.transform.position.y + "/" + Player.transform.position.z;
		string Rotation = Player.transform.rotation.eulerAngles.x + "/" + Player.transform.rotation.eulerAngles.y + "/" + Player.transform.rotation.eulerAngles.z;
		string InventoryItemList = "0/1";
		string JobType = "";
		Mycharacter = (new User(ID, Name, Level, Pos, Rotation, InventoryItemList, JobType));
		//Debug.Log(Player.name + "::::" + Mycharacter.Rotation);
		JsonData UserJson = JsonMapper.ToJson(Mycharacter);

		//Create new file and write data. if file already exist, overwrite. 
		File.WriteAllText(Application.dataPath + "/Resource/User.json", UserJson.ToString());

		yield return null;
	}

	public void LoadBtn()
	{
		// StartCoroutine(LoadItemData());   // Load item data
		StartCoroutine(LoadUserData());   // Load character data.
		StartCoroutine(CreatCharacter());   // Creat 
	}

	IEnumerator LoadUserData()
	{

		string Jsonstring = File.ReadAllText(Application.dataPath + "/Resource/User.json");
		Debug.Log(Jsonstring);

		JsonData UserData = JsonMapper.ToObject(Jsonstring);

		GetUserInfo(UserData);
		yield return null;
	}

	private void GetUserInfo(JsonData name)
	{

		GM.Mycharacter = new User(int.Parse(name["ID"].ToString()), 
			name["Name"].ToString(), int.Parse(name["Level"].ToString()),
			name["Pos"].ToString(), name["Rotation"].ToString(),
			name["InventoryItemList"].ToString(),
			name["JobType"].ToString()); 
			// optimalize type
	}


	public GameObject PlayerPrefab;
	IEnumerator CreatCharacter()
	{

		string[] tmpPosArray = Mycharacter.Pos.Split('/');
		string[] tmpRoArray = Mycharacter.Rotation.Split('/');

		Vector3 TmpPos = new Vector3(float.Parse(tmpPosArray[0]), float.Parse(tmpPosArray[1]), float.Parse(tmpPosArray[2]));
		Vector3 TmpRo = new Vector3(float.Parse(tmpRoArray[0]), float.Parse(tmpRoArray[1]), float.Parse(tmpRoArray[2]));

		Player = (GameObject)Instantiate(PlayerPrefab, TmpPos, Quaternion.identity);
		Player.GetComponent<PlayerController>().CurrRo = TmpRo.y;

		yield return null;
	}



}
