using BergsMapPack;
using BergsMapPack.Map1;
using Harmony;
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
    public class ShellShock
    {
        public static Il2CppReferenceArray<PointInfo> mainTrack()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(MapHelper.AddPoint(-77.22224, 8.305634));
            list.Add(MapHelper.AddPoint(-69.81483, -2.3425353));
            list.Add(MapHelper.AddPoint(-61.481483, -10.222253));
            list.Add(MapHelper.AddPoint(-54.259262, -16.824083));
            list.Add(MapHelper.AddPoint(-48.14815, -21.509295));
            list.Add(MapHelper.AddPoint(-39.814823, -26.407324));
            list.Add(MapHelper.AddPoint(-32.22223, -31.305634));
            list.Add(MapHelper.AddPoint(-25.555563, -33.861126));
            list.Add(MapHelper.AddPoint(-18.14815, -36.41662));
            list.Add(MapHelper.AddPoint(-11.851851, -38.333378));
            list.Add(MapHelper.AddPoint(-5.1851845, -39.398167));
            list.Add(MapHelper.AddPoint(3.3333423, -40.03704));
            list.Add(MapHelper.AddPoint(10.370369, -39.824085));
            list.Add(MapHelper.AddPoint(18.14815, -38.759155));
            list.Add(MapHelper.AddPoint(25.555553, -36.842533));
            list.Add(MapHelper.AddPoint(33.148155, -34.925915));
            list.Add(MapHelper.AddPoint(40.18518, -31.51845));
            list.Add(MapHelper.AddPoint(48.703716, -27.685211));
            list.Add(MapHelper.AddPoint(55.555565, -23));
            list.Add(MapHelper.AddPoint(62.22223, -18.740704));
            list.Add(MapHelper.AddPoint(70.18519, -11.925916));
            list.Add(MapHelper.AddPoint(76.48148, -6.1759152));
            list.Add(MapHelper.AddPoint(82.77779, -0.21295775));
            list.Add(MapHelper.AddPoint(87.22223, 5.3240843));
            list.Add(MapHelper.AddPoint(91.11113, 11.5));
            return (Il2CppReferenceArray<PointInfo>)list.ToArray();
        }

        public static Il2CppReferenceArray<PointInfo> secondTrack()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(MapHelper.AddPoint(-77.22224, 8.305634));
            list.Add(MapHelper.AddPoint(-69.81483, -2.3425353));
            list.Add(MapHelper.AddPoint(-61.481483, -10.222253));
            list.Add(MapHelper.AddPoint(-54.259262, -16.824083));
            list.Add(MapHelper.AddPoint(-48.14815, -21.509295));
            list.Add(MapHelper.AddPoint(-39.814823, -26.407324));
            list.Add(MapHelper.AddPoint(-32.22223, -31.305634));
            list.Add(MapHelper.AddPoint(-25.555563, -33.861126));
            list.Add(MapHelper.AddPoint(-18.14815, -36.41662));
            list.Add(MapHelper.AddPoint(-11.851851, -38.333378));
            list.Add(MapHelper.AddPoint(-5.1851845, -39.398167));
            list.Add(MapHelper.AddPoint(3.3333423, -40.03704));
            list.Add(MapHelper.AddPoint(10.370369, -39.824085));
            list.Add(MapHelper.AddPoint(18.14815, -38.759155));
            list.Add(MapHelper.AddPoint(25.555553, -36.842533));
            list.Add(MapHelper.AddPoint(33.148155, -34.925915));
            list.Add(MapHelper.AddPoint(40.18518, -31.51845));
            list.Add(MapHelper.AddPoint(48.703716, -27.685211));
            list.Add(MapHelper.AddPoint(55.555565, -23));
            list.Add(MapHelper.AddPoint(62.22223, -18.740704));
            list.Add(MapHelper.AddPoint(70.18519, -11.925916));
            list.Add(MapHelper.AddPoint(76.48148, -6.1759152));
            list.Add(MapHelper.AddPoint(82.77779, -0.21295775));
            list.Add(MapHelper.AddPoint(87.22223, 5.3240843));
            list.Add(MapHelper.AddPoint(91.11113, 11.5));
            return (Il2CppReferenceArray<PointInfo>)list.ToArray();
        }

        public static Il2CppReferenceArray<AreaModel> areas()
        {
            List<AreaModel> newAreas = new List<AreaModel>();

            var mainLand = new List<Vector2>();
            mainLand.Add(new Vector2(119.01f, -115.17f));
            mainLand.Add(new Vector2(-150.1852f, 15.120422f));
            mainLand.Add(new Vector2(-140.55557f, 15.120422f));
            mainLand.Add(new Vector2(-133.70372f, 19.16662f));
            mainLand.Add(new Vector2(-122.22224f, 18.953661f));
            mainLand.Add(new Vector2(-113.88889f, 22.361126f));
            mainLand.Add(new Vector2(-106.48149f, 18.314789f));
            mainLand.Add(new Vector2(-101.11112f, 15.33338f));
            mainLand.Add(new Vector2(-94.07408f, 15.759295f));
            mainLand.Add(new Vector2(-86.66667f, 14.907464f));
            mainLand.Add(new Vector2(-37.037037f, 15.759295f));
            mainLand.Add(new Vector2(-41.481483f, -3.6204224f));
            mainLand.Add(new Vector2(-52.40741f, -37.694366f));
            mainLand.Add(new Vector2(-54.44445f, -41.10183f));
            mainLand.Add(new Vector2(-56.851856f, -47.91662f));
            mainLand.Add(new Vector2(-54.44445f, -52.175915f));
            mainLand.Add(new Vector2(-47.777782f, -52.388874f));
            mainLand.Add(new Vector2(-42.03704f, -51.75f));
            mainLand.Add(new Vector2(-40f, -48.981407f));
            mainLand.Add(new Vector2(-40.925926f, -44.509296f));
            mainLand.Add(new Vector2(-43.518524f, -41.31479f));
            mainLand.Add(new Vector2(-47.96297f, -35.990704f));
            mainLand.Add(new Vector2(-52.22223f, -37.48155f));
            mainLand.Add(new Vector2(-40.925926f, -3.4074645f));
            mainLand.Add(new Vector2(-35.74074f, 15.33338f));
            mainLand.Add(new Vector2(-33.518524f, 88.16662f));
            mainLand.Add(new Vector2(26.296291f, 89.87042f));
            mainLand.Add(new Vector2(29.444452f, 15.120422f));
            mainLand.Add(new Vector2(-3.8888905f, 4.898169f));
            mainLand.Add(new Vector2(-8.5185175f, 5.962958f));
            mainLand.Add(new Vector2(-12.962966f, 4.0463376f));
            mainLand.Add(new Vector2(-14.629628f, -0.4259155f));
            mainLand.Add(new Vector2(-15.740742f, -6.601831f));
            mainLand.Add(new Vector2(-39.444443f, -65.37958f));
            mainLand.Add(new Vector2(-130.1852f, -80.5f));
            mainLand.Add(new Vector2(-136.11113f, -85.82408f));
            mainLand.Add(new Vector2(-137.40742f, -98.81479f));
            mainLand.Add(new Vector2(-126.85187f, -99.2407f));
            mainLand.Add(new Vector2(-117.962975f, -96.259155f));
            mainLand.Add(new Vector2(-120.74075f, -87.52775f));
            mainLand.Add(new Vector2(-129.62964f, -80.5f));
            mainLand.Add(new Vector2(-38.888897f, -65.80549f));
            mainLand.Add(new Vector2(-14.629628f, -7.027746f));
            mainLand.Add(new Vector2(-10.925926f, -8.305493f));
            mainLand.Add(new Vector2(-3.3333335f, -8.305493f));
            mainLand.Add(new Vector2(-0.7407368f, -1.2777466f));
            mainLand.Add(new Vector2(-3.1481447f, 5.3240843f));
            mainLand.Add(new Vector2(30.370369f, 14.481548f));
            mainLand.Add(new Vector2(37.222233f, 14.481548f));
            mainLand.Add(new Vector2(30.18519f, -52.175915f));
            mainLand.Add(new Vector2(24.07408f, -62.18521f));
            mainLand.Add(new Vector2(26.296291f, -71.12958f));
            mainLand.Add(new Vector2(40.740738f, -69.63887f));
            mainLand.Add(new Vector2(44.62964f, -62.82408f));
            mainLand.Add(new Vector2(44.259262f, -54.305492f));
            mainLand.Add(new Vector2(37.222233f, -51.53704f));
            mainLand.Add(new Vector2(31.111107f, -52.388874f));
            mainLand.Add(new Vector2(38.70371f, 14.694507f));
            mainLand.Add(new Vector2(46.481487f, 14.907464f));
            mainLand.Add(new Vector2(49.81481f, 0.851831f));
            mainLand.Add(new Vector2(46.29631f, -7.8795776f));
            mainLand.Add(new Vector2(52.22222f, -14.481408f));
            mainLand.Add(new Vector2(58.70371f, -10.648169f));
            mainLand.Add(new Vector2(61.851852f, -6.388873f));
            mainLand.Add(new Vector2(60.55556f, -0.4259155f));
            mainLand.Add(new Vector2(54.62963f, 3.6204224f));
            mainLand.Add(new Vector2(49.444454f, 12.3518305f));
            mainLand.Add(new Vector2(50.185192f, 1.277887f));
            mainLand.Add(new Vector2(48.14816f, 15.546337f));
            mainLand.Add(new Vector2(122.59261f, 14.907464f));
            mainLand.Add(new Vector2(120.92594f, -68.78704f));
            mainLand.Add(new Vector2(117.037056f, -73.47225f));
            mainLand.Add(new Vector2(115.555565f, -83.907326f));
            mainLand.Add(new Vector2(132.7778f, -82.84254f));
            mainLand.Add(new Vector2(132.7778f, -76.02775f));
            mainLand.Add(new Vector2(131.85187f, -70.70366f));
            mainLand.Add(new Vector2(121.66668f, -69f));
            mainLand.Add(new Vector2(124.62964f, 15.120422f));
            mainLand.Add(new Vector2(150.1852f, 14.694507f));
            mainLand.Add(new Vector2(151.66667f, 115f));
            mainLand.Add(new Vector2(-150.37039f, 113.50929f));
            mainLand.Add(new Vector2(-149.62965f, 16.185211f));


            var track = new List<Vector2>();
            track.Add(new Vector2((float)-154.62965, (float)-114.78704));
            track.Add(new Vector2((float)149.44446, (float)-114.78704));
            track.Add(new Vector2((float)152.96297, (float)115));
            track.Add(new Vector2((float)-151.29631, (float)115));

            newAreas.Add(new AreaModel("track", new Polygon(track), Main.Empty(), 10, AreaType.track));
            newAreas.Add(new AreaModel("land0", new Polygon(mainLand), Main.Empty(), 10, AreaType.land));
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