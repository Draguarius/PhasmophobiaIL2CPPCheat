using Harmony;
using MelonLoader;
using System.Linq;
using TestMod.Drawing;
using UnityEngine;
using O = TestMod.Objects;

namespace TestMod
{
    public static class BuildInfo
    {
        public const string Name = "Phasmophobia p100 cheat"; // Name of the Mod.  (MUST BE SET)
        public const string Description = null; // Description for the Mod.  (Set as null if none)
        public const string Author = "Aragon12"; // Author of the Mod.  (Set as null if none)
        public const string Company = "Piss off Ltd."; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class TestMod : MelonMod
    {
        public override void OnApplicationStart()
        {
            O.Instance.Start();
        }

        public override void OnUpdate()
        {
            Cheats.Main.Update();
            Keyhandler.Update();
            Menu.Update();
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {

        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {

        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            Menu.OnGUI();
            ESP.OnGUI();
        }
    }
}