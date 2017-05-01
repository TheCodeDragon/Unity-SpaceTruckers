using 	UnityEngine;
using 	System.Collections;
using	System.Text;

//Load level file, using CSV files which can be edited in Excel
//In Excel save as CSV (comma delimited)


public class CVSLevelLoader : MonoBehaviour {

	int[,]	CreateRoom(TextAsset vRoomCSV) {		//Parse file to find size of array & create array
		int	tH = 1;
		int tW = 0;
		int	tMaxWidth = 0;
		foreach (var tChar in vRoomCSV.text) {
			switch (tChar) {
			case '\r':
				tW++;
				tMaxWidth = Mathf.Max (tMaxWidth, tW);
				tW = 0;
				tH++;
				break;
			case ',':
				tW++;
				break;
			default:
				break;
			}
		}
		return	new int[tMaxWidth, tH];
	}


	public	int[,]	LoadRoom(TextAsset vRoomCSV) {	//Load a CSV file level into array
		StringBuilder	tSB = new StringBuilder ();
		var	tMap = CreateRoom(vRoomCSV);
		int	tWidth = tMap.GetLength (0);
		int	tHeight = tMap.GetLength (1);
		int	tH = 0;
		int tW = 0;
		foreach (var tChar in vRoomCSV.text) {
			switch (tChar) {
			case '\r':
				tMap [tW, tH] = Value(tSB.ToString());
				tSB=new StringBuilder ();
				tW = 0;
				tH++;
				break;

			case ',':
				tMap [tW, tH] = Value(tSB.ToString());
				tSB=new StringBuilder ();
				tW++;
				break;

			default:
				tSB.Append (tChar.ToString ());
				break;
			}
		}
		tMap [tW, tH] = Value(tSB.ToString());
		return	tMap;
	}

	int	Value(string vString) {		//Make int from string, if no string use 0
		int tValue; 
		if(vString.Length>0 && int.TryParse(vString, out tValue)) {
			return	tValue;
		} else {
			return	0;
		}
	}
}
