using BepInEx;
using HarmonyLib;

namespace NoIntermissions;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {	
  public const string PLUGIN_GUID = "com.earthlingOnFire.NoIntermissions";
  public const string PLUGIN_NAME = "No Intermissions";
  public const string PLUGIN_VERSION = "1.0.0";

  private void Start() {
    new Harmony(PLUGIN_GUID).PatchAll();
  }
}

[HarmonyPatch]
public static class Patches {
  [HarmonyPrefix]
  [HarmonyPatch(typeof(SceneHelper), nameof(SceneHelper.LoadScene))]
  private static bool SceneHelper_LoadScene_Prefix(string sceneName) {
    if (sceneName == "Intermission1") {
      SceneHelper.LoadScene("Level 4-1");
      return false;
    }
    if (sceneName == "Intermission2") {
      SceneHelper.LoadScene("Level 7-1");
      return false;
    }
    return true;
  }
}


