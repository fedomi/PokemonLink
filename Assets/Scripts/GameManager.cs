using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager S;

    private bool waitingSecondClic = false;
    [SerializeField]
    private GameObject pkmn1, pkmn2;
    private int points = 0;
    private bool isSwapping = false;


    void Awake()
    {
        S = this;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PokemonSelected(GameObject pkmn) {
        if (waitingSecondClic)
        {
            pkmn2 = pkmn;
            waitingSecondClic = false;

            if (CanSwap(pkmn1, pkmn2))
            {
                //AddPoints(50);
                int p1x = pkmn1.GetComponent<PkmnCell>().GetX();
                int p1y = pkmn1.GetComponent<PkmnCell>().GetY();

                pkmn1.GetComponent<PkmnCell>().SetIndex(pkmn2.GetComponent<PkmnCell>().GetX(), pkmn2.GetComponent<PkmnCell>().GetY());
                pkmn2.GetComponent<PkmnCell>().SetIndex(p1x, p1y);


                pkmn1.GetComponent<PkmnCell>().SwapTo(pkmn2);
                pkmn2.GetComponent<PkmnCell>().SwapTo(pkmn1);
                //Destroy(pkmn1.gameObject);
                //Destroy(pkmn2.gameObject);
            }
            else {


            }

        }
        else {
            pkmn1 = pkmn;
            waitingSecondClic = true;
        }

    }

    private bool CanSwap(GameObject p1, GameObject p2) {
        int dx = Mathf.Abs(p1.GetComponent<PkmnCell>().GetX() - p2.GetComponent<PkmnCell>().GetX());
        int dy = Mathf.Abs(p1.GetComponent<PkmnCell>().GetY() - p2.GetComponent<PkmnCell>().GetY());

        Debug.Log("Trying to swap pokemons of indices: " + dx + " - " + dy);

        if (dx + dy < 2)
        {
            return true;
        }
        else return false;
    }

    private bool SameType(GameObject p1, GameObject p2) {
        SpriteRenderer p1SR= p1.GetComponent<SpriteRenderer>();
        SpriteRenderer p2SR = p2.GetComponent<SpriteRenderer>();

        if (p1SR.sprite.name == p2SR.sprite.name) return true;
        else return false;
        

    }

    public void AddPoints(int p)
    {
        points += p;
        UIManager.S.UpdatePointsText(points);
    }


    public bool IsSwapping() { return isSwapping; }
    public void SetIsSwapping(bool newValue) { isSwapping = newValue; }

}
