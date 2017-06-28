using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : IGeographicalFeature {
    public Directions direction {get; set;}

    public HashSet<Tile> tiles{get;set;}
	public HashSet<Tile> smoothed{get;set;}

	public Map map;

    public Mountain(){
		 tiles = new HashSet<Tile>();
		 smoothed = new HashSet<Tile>();
	}

    public void Generate(Map map)
    {
		this.map = map;
		int x = Random.Range(0,map.size);
		int y = Random.Range(0,map.size);
		Tile tile = map.tiles[x,y];
		Spread(tile, Random.Range(1,2));
		Smooth(tile);
    }

	private void Spread(Tile tile, float strength){
		tiles.Add(tile);
		tile.elevation += 8 + strength;

		foreach(Tile n in map.GetNeighbors(tile)){
			if(tiles.Contains(n)) continue;

			float newStrength = strength - Random.Range(0,0.5f);
			if(newStrength > 0) Spread(n,newStrength);
		}
	}

	private void Smooth(Tile tile){
		if(smoothed.Contains(tile))return;
		smoothed.Add(tile);

		float totalElevation = 0;
		int totalNeighbors = 0;
		foreach(Tile n in map.GetNeighbors(tile)){
			if(tiles.Contains(n))continue;
			totalElevation += n.elevation;
			totalNeighbors++;
		}
		if(totalNeighbors == 0)return;

		float avgElevation = totalElevation/totalNeighbors;
		if(tile.elevation-avgElevation < 0.5f) return;
			
		tile.elevation = avgElevation;
		foreach(Tile n in map.GetNeighbors(tile)){
			Smooth(n);
		}
	}
}
