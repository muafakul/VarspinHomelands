using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharStats : MonoBehaviour {

    public int Stamina { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public new Text[] guiText;
    private bool result;




    // Use this for initialization
    void Start () {
        Stamina = 10;
        Strength = 10;
        Intelligence = 10;
        Agility = 10;
        MaxHealth = Stamina * 11;
        CurrentHealth = MaxHealth/2;
        guiText = GetComponentsInChildren<Text>();



        foreach (Text txt in guiText)
        {


            switch (txt.name)
            {
                case "Health":
                    txt.text = ("HP: " + CurrentHealth + " / " + MaxHealth);
                    break;
                case "Stamina":
                    txt.text = ("Sta: " + Stamina);
                    break;
                case "Agility":
                    txt.text = ("Agi: " + Agility);
                    break;
                case "Strength":
                    txt.text = ("Str: " + Strength);
                    break;
                case "Intelligence":
                    txt.text = ("Int: " + Intelligence);
                    break;
                default:
                    break;
            }

        }
     

        
	}
	
	// Update is called once per frame
	void Update () {
        guiText[0].text = ("HP: " + CurrentHealth + " / " + MaxHealth);

    }
}
