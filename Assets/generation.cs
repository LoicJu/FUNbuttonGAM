using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class generation : MonoBehaviour
{
	string path;
	string jsonString;
		// Start is called before the first frame update
		void Start()
		{
			path = Application.dataPath + "/application.json";
			jsonString = File.ReadAllText(path);
			Debug.Log(jsonString);
			AttribList list = JsonUtility.FromJson<AttribList> (jsonString);
			Debug.Log(list);
		}

	// Update is called once per frame
	void Update()
	{

	}
}

[System.Serializable]
public class Attribute
{
	public string nom;
	public int score;
}

[System.Serializable]
public class AttribList
{
	public List<Attribute> attributes;
}
