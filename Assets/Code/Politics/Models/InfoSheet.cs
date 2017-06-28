using System;
using System.Collections.Generic;
using UnityEngine;

public class InfoSheet : MonoBehaviour{
	public Score score = new Score();
	public Attr attr = new Attr();
	public Rep rep = new Rep();
}

public static class Dice{
	private static System.Random rnd = new System.Random();
	public static int Roll(int sides){
		return (rnd.Next()%sides)+1;
	}
	public static int RollNorm(int sides){
		//this does not work yet
		return (rnd.Next()%sides)+1;
	}
}

public class Score{
	private Dictionary<string,int> items = new Dictionary<string,int>();
	public static bool debug = false;


	public bool Set(string key, int val){
		if(this.items.ContainsKey(key)){
			items[key] = val;
		}else{
			items.Add(key,val);
		}
		return true;
	}
	public int Get(string key){
		if(!this.items.ContainsKey(key)){
			this.items.Add(key,Calculate(key));
		}
		return this.items[key];
	}
	public int Add(string key, int val){
		val = this.Get(key) + val;
		if(val > 20) val = 20;
		if(debug) Debug.Log(key + " == " + val + ".");
		return this.items[key] = val;
	}
	public int Sub(string key, int val){
		val = this.Get(key) - val;
		if(val < 0) val = 0;
		if(debug) Debug.Log(key + " == " + val + ".");
		return this.items[key] = val;
	}

	private int Calculate(string key){
		return 0;	
	}
}

public class Attr{
	private List<string> items = new List<string>();
	public static bool debug = false;

	public bool Has(string val){
		if(this.items.Contains(val)){
			return true;
		}
		return false;
	}
	public bool Add(string val){
		if(!this.items.Contains(val)){
			this.items.Add(val);
		}
		return true;
	}
}

public class Rep{
	private Dictionary<InfoSheet,Score> known = new Dictionary<InfoSheet,Score>();
	public static bool debug = false;

	public bool Knows(InfoSheet name){
		if(this.known.ContainsKey(name)){
			return true;
		}
		return false;
	}
	public bool Meet(InfoSheet name){
		if(!this.known.ContainsKey(name)){
			this.known.Add(name, new Score());
		}
		return true;
	}
	public Score Get(InfoSheet name){
		if(!this.known.ContainsKey(name)){
			this.known.Add(name,new Score());
		}
		return this.known[name];
	}
}
