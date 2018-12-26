using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Texture2D spritesheet;
    private string spritesPath = "Pokemon";
    Sprite[] sprites;
    public GameObject pokemon;

    private float spawnTimer = 2.0f;
    private float currentTimer;
    private int X = 5, Y = 7;

	// Use this for initialization
	void Start () {
        sprites = Resources.LoadAll<Sprite>(spritesPath);
        currentTimer = 0;
        InitializeLevel();
	}
	
	// Update is called once per frame
	void Update () {
        currentTimer += Time.deltaTime;

        if (currentTimer >= spawnTimer) {
            


        } 

	}

    private void InitializeLevel() {
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                GameObject go = Instantiate(pokemon, new Vector3(i,j,0), Quaternion.identity);
                int n = Random.Range(0, 20);
                n -= n % 3;
                go.GetComponent<SpriteRenderer>().sprite = sprites[n];
                go.GetComponent<PkmnCell>().SetIndex(i, j);
                go.transform.parent = transform;

            }

        }

    }


}
