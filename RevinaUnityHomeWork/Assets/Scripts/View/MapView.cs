using UnityEngine;

namespace Geekbrains
{
    public class MapView : MapModel
    {
        private void Start()
        {
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            GetComponent<Camera>().targetTexture = rt;
        }
    }
}