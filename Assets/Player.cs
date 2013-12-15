using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

enum PlayerState{
	standing = 0,
	running = 1
};

public class Player : MonoBehaviour {

	public Texture2D _spriteTexture;
	public int rows;
	public int cols;
	public int targetFrameRate = 45;

	private SpriteRenderer _spriteRender;
	private ArrayList _sprites;

	private PlayerState _state;

	private int index;
	private int currentIndex;
	private int newIndex;

	private const float intervalTime = 0.1f;/*delay time 0.1 s*/
	private float interval;

	private Vector2 currentDir;

	void Awake(){
		_sprites = new ArrayList();
		_spriteRender = this.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

		_state = PlayerState.standing;

		index = 0;
		currentIndex = 0;
		newIndex = 0;

		currentDir = new Vector2(0,0);

		interval = intervalTime;

		Application.targetFrameRate = targetFrameRate;
	}

	void Start () {
		/*init with sprite textures*/
		for(int j = 0 ; j < rows ; j++){
			ArrayList animFrames = new ArrayList();
			for(int i = 0 ; i < cols ; i++){
				Rect spriteRect = new Rect(_spriteTexture.width/cols * i,
				                           _spriteTexture.height/rows * j ,
				                           _spriteTexture.width/cols,
				                           _spriteTexture.height/rows);
				Sprite tempSprite = Sprite.Create(_spriteTexture,spriteRect,new Vector2(0,0));
				animFrames.Add(tempSprite);
			}
			_sprites.Add(animFrames);
		}

		ArrayList array = (ArrayList)_sprites[currentIndex];
		_spriteRender.sprite = array[0] as Sprite;
	}

	void Update () {
		if(_state == PlayerState.running){
			interval -= Time.deltaTime;
			if(interval <= 0){
				index ++;
				
				ArrayList array = (ArrayList)_sprites[currentIndex];
				_spriteRender.sprite = array[index % cols] as Sprite;

				/*init interval Time*/
				interval = intervalTime;
			}

			/*move player*/
			this.transform.Translate(currentDir * Time.deltaTime);
		}

		KeyDownEvent();

		/*any key up*/
		if(!Input.anyKey){
			if(_state == PlayerState.running) _state = PlayerState.standing;
		}
	}

	void KeyDownEvent(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(_state == PlayerState.standing) _state = PlayerState.running;
			newIndex = 1;
			if(newIndex != currentIndex) currentIndex = newIndex;
			currentDir = Vector2.up;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(_state == PlayerState.standing) _state = PlayerState.running;
			newIndex = 3;
			if(newIndex != currentIndex) currentIndex = newIndex;
			currentDir = -Vector2.up;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(_state == PlayerState.standing) _state = PlayerState.running;
			newIndex = 2;
			if(newIndex != currentIndex) currentIndex = newIndex;
			currentDir = -Vector2.right;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(_state == PlayerState.standing) _state = PlayerState.running;
			newIndex = 0;
			if(newIndex != currentIndex) currentIndex = newIndex;
			currentDir = Vector2.right;
		}
	}
}

