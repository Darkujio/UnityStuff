using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DataHolder : MonoBehaviour {

	public ArrayLayout data;
	public GameObject[,] ObjectsArray = new GameObject[8,8];
	static private GameObject Editor;
	static public void Getter()
	{
		Editor = GameObject.Find("Characters");
		Editor.SendMessage("SetEntities");
	}
}
