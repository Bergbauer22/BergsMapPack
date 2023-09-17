using MelonLoader;
using BTD_Mod_Helper;
using BergsMapPack;
using UnityEngine;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Data.MapSets;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using HarmonyLib;
using Main = BergsMapPack.Main;
using Il2CppAssets.Scripts.Models.Map;
using System;
using System.Linq;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Map;
using Il2CppAssets.Scripts.Models.Map.Spawners;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MapSelect;
using Il2CppAssets.Scripts.Unity.Player;
using BergsMapPack.Map1;
using static BTD_Mod_Helper.Api.ModContent;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Utils;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Simulation.Bloons;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers;

[assembly: MelonInfo(typeof(Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BergsMapPack;


[HarmonyPatch]
public partial class Main : BloonsTD6Mod

{
    public static GameObject SummonBR = null;
    public static GameObject BadorRocket = null;
    static string lastMap = "";
    public string activeMap = "";
    public static AssetBundle? MoonwayAssetBundle;
    public override void OnTitleScreen()
    {
        MoonwayAssetBundle ??= GetBundle<Main>("badorrocket");
        if(MoonwayAssetBundle != null)
        {
            if (BadorRocket == null)
            {
                        BadorRocket = MoonwayAssetBundle.LoadAsset("BadorRocket").Cast<GameObject>();
                        SummonBR = GameObject.Instantiate(BadorRocket);
            }
            
        }
    }
    public int FrameCount;
    public override void OnUpdate()
    {
        if(InGameData.CurrentGame != null)
        {
            var ActiveMapInfo = InGameData.CurrentGame.selectedMap;
            activeMap = ActiveMapInfo.ToString();
        }

        if (!GameObject.Find("BadorRocket(Clone)").Exists() && activeMap == "Moonway")
        {
                MoonwayAssetBundle ??= GetBundle<Main>("badorrocket");
                BadorRocket = MoonwayAssetBundle.LoadAsset("BadorRocket").Cast<GameObject>();
                SummonBR = GameObject.Instantiate(BadorRocket);
                
        }
        if(GameObject.Find("BadorRocket(Clone)").Exists() && activeMap != "Moonway")
        {
            GameObject.Find("BadorRocket(Clone)").Destroy();
        }
        if (GameObject.Find("BadorRocket(Clone)").Exists())
        {
                
                Animator animator = GameObject.Find("BadorRocket(Clone)").GetComponent<Animator>();
                FrameCount++;
                var second = FrameCount / 60;
                if (second == 25)
                {
                    animator.SetBool("flugstart", true);
                    FrameCount = FrameCount + 90;
                }

                if (second >= 26)
                {
                    animator.SetBool("flugstart", false);
                    FrameCount = 0;
                }
        }
        
    }
    static bool isCustom(string map)
    {
        return mapList.Where(x => x.name == map).Count() > 0;
    }
    public static Il2CppReferenceArray<Il2CppAssets.Scripts.Simulation.SMath.Polygon> Empty()
    {
        return new Il2CppReferenceArray<Il2CppAssets.Scripts.Simulation.SMath.Polygon>(0);
    }
    class MapData
    {
        public string name; 
        public MapDifficulty difficulty;
        public PathModel[] paths; 
        public PathSpawnerModel spawner; 
        public Il2CppReferenceArray<AreaModel> areas; 
        public string mapMusic; 
        public string mapDisplayName; 
        public string mapType; 

        public MapData(string name, MapDifficulty difficulty, PathModel[] paths, PathSpawnerModel spawner, Il2CppReferenceArray<AreaModel> areas, string mapMusic, string mapDisplayName, string mapType)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.paths = paths;
            this.spawner = spawner;
            this.areas = areas;
            this.mapMusic = mapMusic;
            this.mapDisplayName = mapDisplayName;
            this.mapType = mapType;

        }
    }
    static MapData[] mapList = new MapData[]
    {

            new MapData("Moonway", MapDifficulty.Advanced, Moonway.pathmodel(), Moonway.spawner(), Moonway.areas(), "MusicDarkA", "Moonway", "EasyBergbauerMaps"),
            new MapData("ShellShock", MapDifficulty.Expert, ShellShock.pathmodel(), ShellShock.spawner(), ShellShock.areas(), "MusicDarkA", "ShellShock", "EasyBergbauerMaps"),

    };
    [HarmonyPatch(typeof(InputManager), nameof(InputManager.CursorDown))]
    internal class InputManager_CursorDown
    {
        [HarmonyPostfix]

        public static void Postfix(InputManager __instance)
        {
            int pierce = 1;
            int damage = 0;
            float Value = 0;
            List<Tower> towers = InGame.instance.GetTowers();
            int TC = towers.Count;
            for (int i = 0; i < TC; i++)
            {
                if (towers[i] != null)
                {
                    string text = towers[i].model.name;
                    if (text.Contains("MortarMonkey") || text.Contains("HeliPilot") || text.Contains("MonkeyAce") || text.Contains("MonkeyBuccaneer") || text.Contains("MonkeySub") || text.Contains("SniperMonkey") || text.Contains("DartlingGunner"))
                    {
                        Value = towers[i].SaleValue + Value;
                        
                    }
                    if (text.Contains("CaptainChurchill"))
                    {
                        pierce = pierce * 3;
                    }
                }
            }
            for(int i = 0; i <= (Value / 5000); i++)
            {
                damage++;
            }
            if (InGameData.CurrentGame != null)
            {
                var ActiveMapInfo = InGameData.CurrentGame.selectedMap;
                if(ActiveMapInfo.ToString() != "ShellShock")
                {
                    damage = 0;
                }
            }
            BloonToSimulation[] bloonsims = InGame.instance.bridge.GetAllBloons().ToArray();
            foreach (BloonToSimulation sim in bloonsims)
            {
                Bloon bloon = sim.GetBloon();
                if (Math.Sqrt(Math.Pow(bloon.Position.X - __instance.cursorPositionWorld.x, 2) + Math.Pow(bloon.Position.Y - __instance.cursorPositionWorld.y, 2)) < bloon.radius + 2)
                {
                    bloon.Damage(damage, null, true, true, true);
                    if (--pierce <= 0) break;
                }
            }
        }
    }
    [HarmonyPatch(typeof(TitleScreen), "Start")]
    public class Awake_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            foreach (var mapdata in mapList)
            {
                if (mapdata.mapType == "EasyBergbauerMaps")
                {
                    GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                    {
                        id = mapdata.name,
                        isBrowserOnly = false,
                        isDebug = false,
                        difficulty = mapdata.difficulty,
                        unlockDifficulty = MapDifficulty.Beginner,
                        mapMusic = mapdata.mapMusic,
                        mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                        coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    }).ToArray();
                }
            }
        }
        [HarmonyPatch(typeof(MapButton), "ShowMedal")]
        public class ShowMedal_Patch2
        {
            [HarmonyPrefix]
            public static bool Prefix(MapButton __instance, Btd6Player player, Animator medalAnimator, string mapId, string difficulty, string mode)
            {
                foreach (var mapData in mapList)
                {
                    Game.instance.GetBtd6Player().UnlockMap(mapData.name);
                }
                return true;
            }
        }
        [HarmonyPatch(typeof(MapLoader), nameof(MapLoader.LoadScene))]
        public class LoadMap
        {
            [HarmonyPrefix]
            internal static bool Fix(ref MapLoader __instance)
            {
                lastMap = __instance.currentMapName;
                if (isCustom(lastMap))
                {
                    __instance.currentMapName = "MuddyPuddles";
                }

                return true;
            }
        }
        static bool shouldRun = true;


        [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.InitMap))]
        internal class InitMap_Patch
        {
            [HarmonyPrefix]
            internal static bool Prefix(UnityToSimulation __instance, ref MapModel map)
            {
                try
                {
                    if (!isCustom(lastMap))
                    {
                        try
                        {
                            GameObject.Destroy(GameObject.Find("mapcube"));
                        }
                        catch
                        {
                        }
                        return true;
                    }
                    var ob2 = GameObject.Find("MuddyPuddlesTerrain");
                    try
                    {
                        GameObject.Destroy(GameObject.Find("mapcube"));
                    }
                    catch
                    {
                    }
                    MapData mapdata = mapList.Where(x => x.name == lastMap).First();
                    Texture2D tex = ModContent.GetTexture<Main>(mapdata.name);
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "mapcube";
                    cube.transform.position = new Vector3(0, -0.4901f, 0);
                    cube.transform.localScale = new Vector3(-300, 1f, -235);
                    cube.GetComponent<Renderer>().material = ob2.GetComponent<Renderer>().material;
                    cube.GetComponent<Renderer>().material.mainTexture = tex;
                    foreach (var ob in UnityEngine.Object.FindObjectsOfType<GameObject>())
                    {
                        if (ob.name.Contains("Festive") || ob.name.Contains("Rocket") || ob.name.Contains("Firework") || ob.name.Contains("Box") || ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Ripples") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow") || ob.name.Contains("WaterSplashes"))
                            if (ob.name != "MuddyPuddlesTerrain")
                                ob.transform.position = new Vector3(1000, 1000, 1000);
                    }

                    map.areas = mapdata.areas;
                    map.spawner = mapdata.spawner;
                    map.paths = mapdata.paths;
                    map.name = mapdata.name;
                    map.mapName = mapdata.name;


                    if (GameObject.Find("Rain"))
                        GameObject.Find("Rain").active = false;


                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    return true;
                }

            }


            [HarmonyPatch(typeof(TowerModel), "IsPlaceableInAreaType")]
            public class IsTowerPlaceableInAreaType_Patch
            {

                [HarmonyPrefix]
                static bool Prefix(ref bool __result, AreaType areaType)
                {
                    if (lastMap != "Epilogue" && lastMap != "Crossover") return true;
                    __result = true;
                    return false;
                }
            }

        }
    }
}