using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class PathFinding : MonoBehaviour {

	public class Vertex 
	{
		public Vector2 position;
		public float val;

		public int CompareTo(Vertex value)
		{
			return this.val.CompareTo(value.val);
		}

		public override string ToString()
		{
			return "Position: " + position.ToString() + "\nValue: " + val.ToString();
		}
		public Vertex Copy()
		{
			Vertex t = new Vertex();
			t.val = val;
			t.position = new Vector2(position.x, position.y);
			return t;
		}
	}

	public class Heap
	{
		public int heapSize = 0;
		int ArrayLength = 0;
		public ArrayList Vertexes;

		public Heap()
		{
			Vertexes = new ArrayList();
		}

		void Swap(ref object a, ref object b)
		{
			//Debug.Log(((Vertex)b).val.ToString() + " < " + ((Vertex)a).val.ToString());
			object tmp = a;
			a = b;
			b = tmp;
		}
		int left(int a)
		{
			return a * 2 + 1;
		}
		int right(int a)
		{
			return a * 2 + 2;
		}
		int parent(int a)
		{
			return (a - 1) / 2;
		}
		public int Size()
		{
			return Vertexes.Count;
		}
		void MinHeapify(int i)
		{
			int l = left(i);
			int r = right(i);
			int t;
			if(l < Vertexes.Count && ((Vertex)Vertexes[i]).val > ((Vertex)Vertexes[l]).val)
				t = l;
			else
				t = i;
			if(r < Vertexes.Count && ((Vertex)Vertexes[t]).val > ((Vertex)Vertexes[r]).val)
				t = r;
			if(t != i)
			{
				var tmp = Vertexes[i];
				Vertexes[i] = Vertexes[t];
				Vertexes[t] = tmp;
				MinHeapify(t);
			}
		}
		public void BuildMinHeap()
		{
			for(int i = Vertexes.Count / 2 - 1; i >= 0; i++)
				MinHeapify(i);
		}

		public Vertex HeapMin()
		{
			return (Vertex)Vertexes[0];
		}
		
		public Vertex ExtractMin()
		{
			Vertex t = ((Vertex)Vertexes[0]).Copy();
			var tmp = Vertexes[0];
			Vertexes[0] = Vertexes[Vertexes.Count - 1];
			Vertexes[Vertexes.Count - 1] = tmp;
			Vertexes.RemoveAt(Vertexes.Count - 1);
			MinHeapify(0);
			return t;
		}

		void HeapKeyReset(int i, Vertex key)
		{
			Vertexes[i] = key;
			while(i > 0 && ((Vertex)Vertexes[parent(i)]).val > ((Vertex)Vertexes[i]).val)
			{
				var tmp = Vertexes[i];
				Vertexes[i] = Vertexes[parent(i)];
				Vertexes[parent(i)] = tmp;
				i = parent(i);
			}
		}
		public void Insert(Vertex key)
		{
			Vertexes.Add(key);
			HeapKeyReset(Vertexes.Count - 1, key);
		}
	}

	ArrayList Vertexes;
	Heap pq;

	void Start() 
	{
		pq = new Heap();
		pq.BuildMinHeap();
		GameObject[] t = GameObject.FindGameObjectsWithTag("Waypoint");
		Vertexes = new ArrayList();
		int j = 0;
		foreach(var g in t)
		{
			Vertex tmp = new Vertex();
			tmp.position = g.transform.position;
			tmp.val = Vector2.SqrMagnitude(tmp.position - (Vector2)transform.position);
			pq.Insert(tmp);
			Debug.Log(tmp.ToString());
			j++;
		}
		Vertex tmp1 = new Vertex();
		tmp1.position = transform.position;
		tmp1.val = 0;
		pq.Insert(tmp1);

		Debug.Log("Output");
		
		for (int i = 0; i <= j; i++)
		{
			Debug.Log(pq.ExtractMin().val);
		}
	}


	void Update () 
	{
		if(Input.GetKeyDown("x"))
		{
			RaycastHit2D[] ray = Physics2D.RaycastAll((Vector2)transform.position, new Vector2(1, 0), 5);
			foreach (var r in ray)
			{
				if(r.collider.gameObject.name != "Character")
				{
					Debug.Log(r.collider.gameObject.name);
				}
			}
		}
		if(Input.GetKeyDown("c"))
		{
			RaycastHit2D[] ray = Physics2D.RaycastAll((Vector2)transform.position, new Vector2(1, 0), 15);
			foreach (var r in ray)
			{
				if(r.collider.gameObject.name != "Character")
				{
					Debug.Log(r.collider.gameObject.name);
				}
			}
		}
	}
}
