using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map{

	public int size;
	public Tile[,] tiles;
	public List<IGeographicalFeature> features;

	public Map(int size){
		this.size = size;
		features = new List<IGeographicalFeature>();	
		tiles = new Tile[size,size];

		for(int x=0;x<size;x++){
			for(int y=0;y<size;y++){
				tiles[x,y] = new Tile(x,y, size);
			}
		}
	}

	public void AddFeature(IGeographicalFeature feature){
		feature.Generate(this);

		features.Add(feature);
	}

	public IEnumerable<Tile> GetNeighbors(Tile tile){
		Stack<Tile> N = new Stack<Tile>();

		if(tile.x+1 < size) N.Push(tiles[tile.x+1, tile.y]);
		if(tile.x-1 > 0) N.Push(tiles[tile.x-1, tile.y]);
		if(tile.y+1 < size) N.Push(tiles[tile.x, tile.y+1]);
		if(tile.y-1 > 0) N.Push(tiles[tile.x, tile.y-1]);

		return N;
	}
}
