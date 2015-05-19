using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	// Board is referenced by column, row
	private int[,] board = new int[7,6];

	// Red = 1, Blue = 2

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 6; j++)
				board [i, j] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int DropChecker(int column, int color) {
		for (int row = 0; row < 6; row++) {
			if (board[column, row] == 0) {
				board[column, row] = color;
				return row;
			}
		}

		return -1;
	}
}
