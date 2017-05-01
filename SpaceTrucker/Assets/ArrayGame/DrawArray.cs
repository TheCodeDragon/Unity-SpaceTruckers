using UnityEngine;
using System.Collections;
using UnityEngine.UI;		//Needed to access UI stuff


[RequireComponent(typeof(CVSLevelLoader))]
	
public class DrawArray : MonoBehaviour {
	
	public 	TextAsset LevelDesign;		//Link Level CSV file here

	public	Text	DebugText;

	public	GameObject[]	TilePrefab;	//Tiles to use

	int[,] mArray;		//Array of tiles
	GameObject[,] mArrayGO;


	CVSLevelLoader	mLL;		//Level Loader


	void Start () {
		mLL = GetComponent<CVSLevelLoader> ();
		mArray = mLL.LoadRoom (LevelDesign);
		mArrayGO = new GameObject [mArray.GetLength (0), mArray.GetLength (1)];

	}


	void	DrawTiles(int[,] vArray) {
		for(int tY=0;tY<vArray.GetLength(1);tY++) {
			for(int tX=0;tX<vArray.GetLength(0);tX++) {
				int tTileID = vArray [tX, tY];
				if (tTileID > 0) {	//Don't show zero tiles
					mArrayGO [tX, tY] = Instantiate (TilePrefab [tTileID - 1]);	//Get Tile Prefab object
					mArrayGO [tX, tY].transform.SetParent (transform);
					mArrayGO [tX, tY].transform.position = new Vector2 (Mathf.RoundToInt (tX), Mathf.RoundToInt (vArray.GetLength (1) - tY - 1));
				} else {
					if (mArrayGO [tX, tY] != null) {
						Destroy (mArrayGO [tX, tY]);
						mArrayGO [tX, tY] = null;
					}
				}
			}
		}
	}

	float	mTimeOut=0;

	void	Update() {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 tPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			int	tX = Mathf.RoundToInt(tPosition.x);
			int	tY = mArray.GetLength (1)-Mathf.RoundToInt(tPosition.y)-1;
			if (tX >= 0 && tX < mArray.GetLength (0) && tY >= 0 && tY < mArray.GetLength (1)) {
				DebugText.text = string.Format ("Hit [{0},{1}] = {2}", tX, tY, mArray [tX, tY]);
				mArray [tX, tY] = 1;
			} else {
				DebugText.text = string.Format ("Outside Game");
			}
		}
		mTimeOut += Time.deltaTime;
		if (mTimeOut > 0.5f) {
			mArray [2, 3] = (mArray [2, 3]+1)%3;
			mTimeOut = 0;	
			DrawTiles (mArray);
		}
	}
}
