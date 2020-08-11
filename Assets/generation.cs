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
	List<Attribute> applications;
	List<Attribute> couleurs;
	List<Attribute> ethnies;
	List<Attribute> fidels;

	string prenom;
	string nomFamille;
	string religion;
	string sexualite;
	string sexe;
	string proffession;
	string application;
	string couleur;
	string ethnie;
	string fidel;
	int scorePerso;
	
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
	
	void generationPerdue(){
		attribution(noms, prenom);
		attribution(noms, nomFamille);
		attribution(religions, religion);
		attribution(sexualites, sexualite);
		attribution(sexes, sexe);
		attribution(professions, proffession);
		attribution(applications, application);
		attribution(couleurs, couleur);
		attribution(ethnies, ethnie);
		attribution(fidels, fidel);
	}
	
	void attribution(List<Attribute listee, string varii){
		int x = Random.Range(0,noms.size()-1);
		varii = listee[x].nom;
		scorePerso += listee[x].score;
	}
	
	List<Attribute> Telecharge(string path){
		jsonString = File.ReadAllText(path);
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