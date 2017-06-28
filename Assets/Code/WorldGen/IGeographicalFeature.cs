using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGeographicalFeature {

	HashSet<Tile> tiles{get;set;}

	void Generate(Map map);
}
