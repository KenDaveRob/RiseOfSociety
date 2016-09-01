using UnityEngine;
using System.Collections;
namespace WPM
{
    public class faceEarth : MonoBehaviour
    {
        [SerializeField] WorldMapGlobe map;

        // Use this for initialization
        void Start()
        {
            transform.LookAt(map.transform.position);
        }

    }
}
