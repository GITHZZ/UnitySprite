using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	//public Texture2D texture;
	//public Vector2 position;
	public Sprite sprite;

	void Start () {
		//Rect sprRect = new Rect(position.x,position.y,texture.width,texture.height);
		//Sprite bgSpr = Sprite.Create(texture,sprRect,new Vector2(0,0));
		SpriteRenderer.Instantiate(sprite);
	}

	void Update () {
	
	}
}
