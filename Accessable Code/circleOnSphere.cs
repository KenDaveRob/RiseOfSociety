    //Written by Kenneth Robertson 8-31-2016
	//Draws a circle on a sphere centered at lat1, lon1, the distance is still a little tricky to work with.
	float lat1 = 50f * Mathf.PI/180,lon1 = 150f * Mathf.PI/180f;
	float distance = 10f;
	float EPS = 0.000000005f;
	float dlon, lat2, lon2;
	float prevLat2 = float.NaN;
	float prevLon2 = float.NaN;
	const float querterPI = 0.0174532924f*90f;
	//float course=-Mathf.PI;  // radians
	distance /= (180f / Mathf.PI);
	//distance /= 1.852f;
	//distance /= (180f * 60f / Mathf.PI);  // in radians

	for (float course = -Mathf.PI; course < Mathf.PI; course += .01f) {
		// 5/16 changed to "long-range" algorithm
		if ((Mathf.Abs (Mathf.Cos (lat1)) < EPS) && !(Mathf.Abs (Mathf.Sin (course)) < EPS)) {
			Debug.Log ("Only N-S courses are meaningful, starting at a pole!");
		}

		lat2 = Mathf.Asin (Mathf.Sin (lat1) * Mathf.Cos (distance) +
		Mathf.Cos (lat1) * Mathf.Sin (distance) * Mathf.Cos (course));
		if (Mathf.Abs (Mathf.Cos (lat2)) < EPS) {
			lon2 = 0f; //endpoint a pole
		} else {
			dlon = Mathf.Atan2 (Mathf.Sin (course) * Mathf.Sin (distance) * Mathf.Cos (lat1),
				Mathf.Cos (distance) - Mathf.Sin (lat1) * Mathf.Sin (lat2));
			lon2 = modf (lon1 - dlon + Mathf.PI, 2 * Mathf.PI) - Mathf.PI;
		}

		Debug.Log ("lat2: " + lat2 + ", lon2: " + lon2);
		if (!float.IsNaN (prevLat2) && !float.IsNaN (prevLon2))
		{
			float prevLatD = Mathf.Rad2Deg * prevLat2, prevLonD = Mathf.Rad2Deg * prevLon2;
			float latDegree = Mathf.Rad2Deg * lat2, lonDegree = Mathf.Rad2Deg * lon2;
			AddSphericalLine (toCartesianCoords (prevLat2, prevLon2 + querterPI), toCartesianCoords (lat2, lon2 + querterPI), Color.red, .001f, 0.0025f);
			//AddSphericalLine (map.GetSpherePointFromLatLon(prevLatD, prevLonD), map.GetSpherePointFromLatLon (latDegree, lonDegree), Color.red, .001f, 0.0025f);
		}

		prevLat2 = lat2;
		prevLon2 = lon2;
	}

	Debug.Log(toCartesianCoords(50f * Mathf.PI/180, 150f * Mathf.PI/180f));