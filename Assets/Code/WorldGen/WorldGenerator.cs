using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public int mapSize = 10;
	public Map map;

	void Start(){
		map = new Map(mapSize);
		map.AddFeature(new Mountain());
		Show();
	}

	public void Show(){
		for(int x=0;x<map.size;x++){
			for(int y=0;y<map.size;y++){
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = new Vector3(x,map.tiles[x,y].elevation,y);
			}
		}
	}
}
