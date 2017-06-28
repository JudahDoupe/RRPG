using System.Collections;
using System.Collections.Generic;

public class Tile{

	public Tile(int x, int y, int mapSize){
		this.x = x;
		this.y = y;
		elevation = 0;
	}

	public int x{get;set;}
	public int y{get;set;}
	public float elevation{get;set;}

}
