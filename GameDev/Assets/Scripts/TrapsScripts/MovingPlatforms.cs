using UnityEngine;

namespace TrapsScripts
{
    public class MovingPlatforms : MonoBehaviour
    {
        [SerializeField] private GameObject[] _waypoints;
        private int currentIndex = 0;
        [SerializeField] private float speed = 1f;


        void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, _waypoints[currentIndex].transform.position) < .1f)
            {
                currentIndex++;
                if (currentIndex >= _waypoints.Length)
                {
                    currentIndex = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[currentIndex].transform.position,
                speed * Time.deltaTime);
        }
    }
}