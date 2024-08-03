using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.EnemySpawnSystem
{
    [Serializable]
    public class PatrolRoute
    {
        private const string PatrolPointsName = "PatrolPoints";
        
        public Transform[] Waypoints;

        public KeyValuePair<string, Vector3[]> GetRoute()
        {
            return new KeyValuePair<string, Vector3[]>(PatrolPointsName, Waypoints.Select(waypoint => waypoint.position).ToArray());
        }
    }
}