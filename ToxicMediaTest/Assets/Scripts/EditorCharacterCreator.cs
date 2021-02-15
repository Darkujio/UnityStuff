using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class EditorCharacterCreator : MonoBehaviour
{
    public GameObject CharacterPrefab;
    public DataHolder BigData;

    void SetEntities()
    {   
        var tempList = gameObject.transform.Cast<Transform>().ToList();
        foreach(var child in tempList){
            DestroyImmediate(child.gameObject);
        }
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if (BigData.data.rows[i].row[j]){
                    GameObject Char = Instantiate(CharacterPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    Char.transform.parent = gameObject.transform;
                   }
            }
        }
    }
    
}
