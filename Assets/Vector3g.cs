using UnityEngine;
using System.Collections;

public struct Vector3g
{
	public Vector3g(decimal x, decimal y, decimal z) {
		this.x = x; this.y = y; this.z = z;
	}
	public decimal x;
	public decimal y;
	public decimal z;

	static public implicit operator Vector3(Vector3g vec)
	{
		return new Vector3 ((float)(vec.x+CoordinateRemap.LocalOrigin.x),
		                    (float)(vec.y+CoordinateRemap.LocalOrigin.y), 
		                    (float)(vec.z+CoordinateRemap.LocalOrigin.z));
	}

	static public implicit operator Vector3g(Vector3 vec)
	{
		return new Vector3g((decimal)vec.x-CoordinateRemap.LocalOrigin.x, 
		                    (decimal)vec.y-CoordinateRemap.LocalOrigin.y, 
		                    (decimal)vec.z-CoordinateRemap.LocalOrigin.z);
	}

	public override string ToString ()
	{
		return string.Format ("({0}, {1}, {2})", x, y, z);
	}
}
