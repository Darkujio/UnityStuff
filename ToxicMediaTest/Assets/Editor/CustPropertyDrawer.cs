using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer {
	private float t = 0f;
	bool awaiter = false;
	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
		EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 18f;
		SerializedProperty data = property.FindPropertyRelative("rows");
		for(int j=0;j<8;j++){
			SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			newposition.height = 18f;
			if(row.arraySize != 8)
				row.arraySize = 8;
			newposition.width = position.width/8;
			for(int i=0;i<8;i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += 16f;
		}
		if (GUI.changed){
			t = DateTime.Now.Millisecond;
			awaiter = true;
		}
		if (t != DateTime.Now.Millisecond & awaiter){
			DataHolder.Getter();
			awaiter = false;
		}
	}

	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 18f * 8;
	}
}
