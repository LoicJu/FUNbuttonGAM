using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class generation : MonoBehaviour
{
	string path;
	string jsonString;
	
	List<Attribute> noms;
	List<Attribute> religions;
	List<Attribute> sexualites;
	List<Attribute> sexes;
	List<Attribute> professions;
	List<Attribute> applications;
	List<Attribute> couleurs;
	List<Attribute> ethnies;
	List<Attribute> fidels;

	public string prenom;
	public string nomFamille;
	public string religion;
	public string sexualite;
	public string sexe;
	public string profession;
	public string application;
	public string couleur;
	public string ethnie;
	public string fidel;
	public int scorePerso;
	
		// Start is called before the first frame update
	void Start()
	{
		noms = Telecharge("/nom.json");
		religions = Telecharge("/religion.json");
		sexualites = Telecharge("/sexualite.json");
		sexes = Telecharge("/sexe.json");
		professions = Telecharge("/proffession.json");
		applications = Telecharge("/application.json");
		couleurs = Telecharge("/couleur.json");
		ethnies = Telecharge("/ethnie.json");
		fidels = Telecharge("/fidel.json");
	}

	// Update is called once per frame
	void Update()
	{

	}
	
	public void generationPerdue(){
		scorePerso = 0;
		prenom = attribution(noms);
		nomFamille = attribution(noms);
		religion = attribution(religions);
		sexualite = attribution(sexualites);
		sexe = attribution(sexes);
		profession = attribution(professions);
		application = attribution(applications);
		couleur = attribution(couleurs);
		ethnie = attribution(ethnies);
		fidel = attribution(fidels);
	}
	
	string attribution(List<Attribute> listee){
		int x = Random.Range(0,listee.Count-1);
		scorePerso += listee[x].score;
		return listee[x].nom;
	}
	
	List<Attribute> Telecharge(string path){
		jsonString = File.ReadAllText(Application.dataPath + "/Attributes/"+ path);
		AttribList list = JsonUtility.FromJson<AttribList> (jsonString);
		return list.attribute;
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
	public List<Attribute> attribute;
}