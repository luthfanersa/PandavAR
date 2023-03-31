using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeW : MonoBehaviour
{
	public Texture[] textures;
	public int currentTexture;
	public int Color1;

	///
	public Texture[] textures1;
	public int currentTexture1;
	public int Color2;

	public Texture[] textures2;
	public int currentTexture2;
	public int Color3;

	public Texture[] textures3;
	public int currentTexture3;
	public int Color4;

	public Texture[] textures4;
	public int currentTexture4;
	public int Color5;

	public void SwapWayangPrev()
	{
		Debug.Log("Wayang is swaped!!!!!!");
		currentTexture++;
		currentTexture %= textures.Length;
		GetComponent<Renderer>().material.mainTexture = textures[Color1];
	}

	public void SwapWayangNext()
	{
		Debug.Log("Texture is swaped!!!!!!");
		currentTexture1++;
		currentTexture1 %= textures1.Length;
		GetComponent<Renderer>().material.mainTexture = textures1[Color1];
	}
}
