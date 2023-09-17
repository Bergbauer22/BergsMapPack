using Il2CppAssets.Scripts.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergsMapPack
{
    public static class MapHelper
    {
        private static System.Random random = new System.Random();

        public static PointInfo AddPoint(double x, double y)
        {
            return new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = random.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Il2CppAssets.Scripts.Simulation.SMath.Vector3((float)x, (float)y), bloonSpeedMultiplier = 1 };
        }

        public static PointInfo AddInvulnerablePoint(double x, double y)
        {
            return new PointInfo() { bloonScale = 1, bloonsInvulnerable = true, distance = 1, id = random.NextDouble() + "", moabScale = 1, moabsInvulnerable = true, rotation = 0, point = new Il2CppAssets.Scripts.Simulation.SMath.Vector3((float)x, (float)y), bloonSpeedMultiplier = 10 };
        }
    }
}
