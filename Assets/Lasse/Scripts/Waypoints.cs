using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform waypoint;
    public Transform[] waypoints;

    public void SetWaypoint(int id)
    {
        if(id == 1)
        {
            waypoint.transform.position = waypoints[0].transform.position;
        }else if(id == 2)
        {
            waypoint.transform.position = waypoints[1].transform.position;
        }
    }
}
