﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	[System.Serializable]
	public struct rowData{
		public bool[] row;
	}

	public rowData[] rows = new rowData[8]; //Grid of 8x8
}
