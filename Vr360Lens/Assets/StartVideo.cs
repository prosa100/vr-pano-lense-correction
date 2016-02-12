using UnityEngine;
using System.Collections;

public class StartVideo : MonoBehaviour {
    MovieTexture movie;
	// Use this for initialization
	void Start () {
        movie.loop = true;
        movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
