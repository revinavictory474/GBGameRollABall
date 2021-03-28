using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class RadarController : RadarModel
    {
		
		public static void RegisterRadarObject(GameObject o, Image i)
		{
			Image image = Instantiate(i);
			RadObjects.Add(new RadarObject { Owner = o, Icon = image });
		}

		public static void RemoveRadarObject(GameObject o)
		{
			List<RadarObject> newList = new List<RadarObject>();
			foreach (RadarObject t in RadObjects)
			{
				if (t.Owner == o)
				{
					Destroy(t.Icon);
					continue;
				}
				newList.Add(t);
			}
			RadObjects.RemoveRange(0, RadObjects.Count);
			RadObjects.AddRange(newList);
		}
		
	}
}