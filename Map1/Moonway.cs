using BergsMapPack;
using BergsMapPack.Map1;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Map.Spawners;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace BergsMapPack.Map1
{
    [HarmonyPatch]
    public class Moonway
    {
        public static Il2CppReferenceArray<PointInfo> mainTrack()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(MapHelper.AddPoint(-147.96298, 22.361126));
            list.Add(MapHelper.AddPoint(-109.25928, 64.7407));
            list.Add(MapHelper.AddPoint(-87.592606, 83.26859));
            list.Add(MapHelper.AddPoint(-71.48148, 97.11112));
            list.Add(MapHelper.AddPoint(-58.14815, 101.79633));
            list.Add(MapHelper.AddPoint(-46.851856, 98.38887));
            list.Add(MapHelper.AddPoint(-44.62964, 78.79633));
            list.Add(MapHelper.AddPoint(-47.407413, 4.685211));
            list.Add(MapHelper.AddPoint(-45.555565, -29.175915));
            list.Add(MapHelper.AddPoint(-40.185192, -48.342533));
            list.Add(MapHelper.AddPoint(-30.370369, -64.31479));
            list.Add(MapHelper.AddPoint(-15.1851845, -76.66662));
            list.Add(MapHelper.AddPoint(6.4814873, -84.75929));
            list.Add(MapHelper.AddPoint(26.296291, -88.37958));
            list.Add(MapHelper.AddPoint(48.703716, -90.50929));
            list.Add(MapHelper.AddPoint(77.5926, -89.23141));
            list.Add(MapHelper.AddPoint(110.37038, -87.52775));
            list.Add(MapHelper.AddPoint(128.14816, -86.03704));
            list.Add(MapHelper.AddPoint(145.1852, -84.33338));
            return (Il2CppReferenceArray<PointInfo>)list.ToArray();
        }

        public static Il2CppReferenceArray<PointInfo> secondTrack()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(MapHelper.AddPoint(-147.5926, -97.75));
            list.Add(MapHelper.AddPoint(-102.22223, -91.57408));
            list.Add(MapHelper.AddPoint(-69.07407, -86.03704));
            list.Add(MapHelper.AddPoint(-25.185184, -78.37042));
            list.Add(MapHelper.AddPoint(-14.259259, -76.2407));
            list.Add(MapHelper.AddPoint(7.407404, -84.12028));
            list.Add(MapHelper.AddPoint(27.592602, -87.7407));
            list.Add(MapHelper.AddPoint(49.25926, -90.296196));
            list.Add(MapHelper.AddPoint(77.777794, -88.80563));
            list.Add(MapHelper.AddPoint(110.925934, -87.10183));
            list.Add(MapHelper.AddPoint(127.96298, -85.82408));
            list.Add(MapHelper.AddPoint(138.88892, -84.972115));
            return (Il2CppReferenceArray<PointInfo>)list.ToArray();
        }

        public static Il2CppReferenceArray<AreaModel> areas()
        {
            List<AreaModel> newAreas = new List<AreaModel>();

            var mainLand = new List<Vector2>();
            mainLand.Add(new Vector2(-149.9f, -115.5f));
            mainLand.Add(new Vector2(150.1f, -115.5f));
            mainLand.Add(new Vector2(150.1f, 115.5f));
            mainLand.Add(new Vector2(-149.9f, 115.5f));

            var water = new List<Vector2>();
            water.Add(new Vector2((float)-133.8889, (float)-13.416619));
            water.Add(new Vector2((float)-120.55557, (float)-21.296198));
            water.Add(new Vector2((float)-115.00001, (float)-23.851831));
            water.Add(new Vector2((float)-108.33334, (float)-26.620281));
            water.Add(new Vector2((float)-100.74075, (float)-29.175915));
            water.Add(new Vector2((float)-92.77779, (float)-30.453661));
            water.Add(new Vector2((float)-87.40742, (float)-29.814789));
            water.Add(new Vector2((float)-79.44444, (float)-29.175915));
            water.Add(new Vector2((float)-73.148155, (float)-25.342535));
            water.Add(new Vector2((float)-71.85186, (float)-17.888872));
            water.Add(new Vector2((float)-75.555565, (float)-8.305493));
            water.Add(new Vector2((float)-79.81483, (float)1.9166198));
            water.Add(new Vector2((float)-83.70371, (float)9.370422));
            water.Add(new Vector2((float)-88.33334, (float)16.185211));
            water.Add(new Vector2((float)-93.70371, (float)16.824224));
            water.Add(new Vector2((float)-97.03705, (float)13.629718));
            water.Add(new Vector2((float)-104.44446, (float)11.074084));
            water.Add(new Vector2((float)-113.518524, (float)5.75));
            water.Add(new Vector2((float)-121.4815, (float)1.4907043));
            water.Add(new Vector2((float)-129.25928, (float)-2.9814086));
            water.Add(new Vector2((float)-134.07408, (float)-11.074084));

            var track = new List<Vector2>();
            track.Add(new Vector2((float)-147.40742, (float)-111.80549));
            track.Add(new Vector2((float)-70.18519, (float)-103.92591));
            track.Add(new Vector2((float)-55.370377, (float)-101.37028));
            track.Add(new Vector2((float)-26.851856, (float)-96.89817));
            track.Add(new Vector2((float)-14.0740795, (float)-90.50929));
            track.Add(new Vector2((float)-9.259264, (float)-89.87042));
            track.Add(new Vector2((float)8.148141, (float)-96.04633));
            track.Add(new Vector2((float)31.296305, (float)-99.87958));
            track.Add(new Vector2((float)49.25926, (float)-101.15746));
            track.Add(new Vector2((float)64.81482, (float)-101.15746));
            track.Add(new Vector2((float)87.03705, (float)-99.87958));
            track.Add(new Vector2((float)105.55557, (float)-98.81479));
            track.Add(new Vector2((float)124.07408, (float)-96.89817));
            track.Add(new Vector2((float)146.11113, (float)-94.981544));
            track.Add(new Vector2((float)146.11113, (float)-71.98141));
            track.Add(new Vector2((float)123.518524, (float)-74.96296));
            track.Add(new Vector2((float)97.777794, (float)-76.87958));
            track.Add(new Vector2((float)70.55557, (float)-79.00929));
            track.Add(new Vector2((float)43.8889, (float)-78.796196));
            track.Add(new Vector2((float)20.925936, (float)-76.2407));
            track.Add(new Vector2((float)0.5555571, (float)-70.91662));
            track.Add(new Vector2((float)-24.25926, (float)-53.453663));
            track.Add(new Vector2((float)-32.40741, (float)-36.842533));
            track.Add(new Vector2((float)-35.92593, (float)0.4259155));
            track.Add(new Vector2((float)-35.74074, (float)25.129578));
            track.Add(new Vector2((float)-32.40741, (float)52.81479));
            track.Add(new Vector2((float)-32.40741, (float)78.15746));
            track.Add(new Vector2((float)-33.888893, (float)99.45366));
            track.Add(new Vector2((float)-44.62964, (float)111.80549));
            track.Add(new Vector2((float)-65.740746, (float)112.231544));
            track.Add(new Vector2((float)-93.518524, (float)91.78704));
            track.Add(new Vector2((float)-119.81483, (float)67.93521));
            track.Add(new Vector2((float)-138.33334, (float)47.703663));
            track.Add(new Vector2((float)-148.8889, (float)35.990704));
            track.Add(new Vector2((float)-148.14816, (float)8.518591));
            track.Add(new Vector2((float)-130.55557, (float)26.620422));
            track.Add(new Vector2((float)-115.185196, (float)43.444508));
            track.Add(new Vector2((float)-98.148155, (float)60.907463));
            track.Add(new Vector2((float)-83.8889, (float)74.75));
            track.Add(new Vector2((float)-68.8889, (float)87.95366));
            track.Add(new Vector2((float)-60.74075, (float)94.12958));
            track.Add(new Vector2((float)-55.000008, (float)93.27775));
            track.Add(new Vector2((float)-57.407413, (float)43.657463));
            track.Add(new Vector2((float)-58.70371, (float)1.4907043));
            track.Add(new Vector2((float)-56.48149, (float)-28.111126));
            track.Add(new Vector2((float)-45.92593, (float)-58.56479));
            track.Add(new Vector2((float)-45.185184, (float)-64.52775));
            track.Add(new Vector2((float)-102.96297, (float)-73.47225));
            track.Add(new Vector2((float)-128.51854, (float)-76.2407));
            track.Add(new Vector2((float)-146.29631, (float)-79.00929));

            newAreas.Add(new AreaModel("land0", new Polygon(mainLand), Main.Empty(), 10, AreaType.land));
            newAreas.Add(new AreaModel("water", new Polygon(water), Main.Empty(), 10, AreaType.water));
            newAreas.Add(new AreaModel("track", new Polygon(track), Main.Empty(), 10, AreaType.track));


            return (Il2CppReferenceArray<AreaModel>)newAreas.ToArray();
        }

        public static PathSpawnerModel spawner()
        {
            return new PathSpawnerModel("", new SplitterModel("", new string[]
                    {
                        "MainPath",
                        "SecondPath"
                    }), new SplitterModel("", new string[]
                    {
                        "SecondPath",
                        "MainPath"
                    }));
        }

        public static PathModel[] pathmodel()
        {
            return new PathModel[]
                    {
                        new PathModel("MainPath", mainTrack(), true, false, new Vector3(), new Vector3(), null, null),
                        new PathModel("SecondPath", secondTrack(), true, false, new Vector3(), new Vector3(), null, null),

                    };
        }
    }
}