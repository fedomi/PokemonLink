using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkmnCell : MonoBehaviour {

    private int type = 0;
    private bool swapping = false;
    private Vector3 swapTo;
    private float swapSpeed = 1.2f;
    private int X, Y;

    public void SetIndex(int x, int y) {
        X = x;
        Y = y;
    }

    public int GetX() { return X; }
    public int GetY() { return Y; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if (swapping)
        {
            Swap();
        }
    }

    void OnMouseDown()
    {
        if(!GameManager.S.IsSwapping())
            GameManager.S.PokemonSelected(gameObject);
        // this object was clicked - do something
        //Destroy(this.gameObject);
    }

    public void SwapTo(GameObject other) {
        swapTo = other.transform.position;
        swapping = true;
        GameManager.S.SetIsSwapping(swapping);
        //StartCoroutine(Swap());
    }

    private void Swap() {
        transform.position = Vector3.Lerp(transform.position, swapTo, swapSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, swapTo) < 0.2f)
        {
            transform.position = swapTo;
            swapping = false;
            GameManager.S.SetIsSwapping(swapping);
        }
    }

    /*
    IEnumerator Swap()
    {
        while (swapping)
        {
            //Debug.Log("OnCoroutine: " + (int)Time.time);
            transform.position = Vector3.Lerp(transform.position, swapTo, swapSpeed*Time.deltaTime);
            
            if (Vector3.Distance(transform.position, swapTo) < 0.3f)
            {
                transform.position = swapTo;
                swapping = false;
                StopCoroutine(Swap());
            }
            yield return new WaitForSeconds(0.1f);
        }
    }*/
}
