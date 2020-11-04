using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMod.Cheats;
using UnityEngine;
using CT = TestMod.Cheats.CheatToggles;
using O = TestMod.Objects;
using Random = System.Random;

namespace TestMod.Drawing
{
    public class Menu : MonoBehaviour
    {
        private static readonly Random random = new Random(Environment.TickCount);

        private static readonly int windowIDKeybinds = random.Next(int.MaxValue);
        private static Rect windowRectKeybinds = new Rect(5f, 5f, 200f, 300f);

        private static readonly int windowIDGeneral = random.Next(int.MaxValue);
        private static Rect windowRectGeneral = new Rect(405f, 5f, 200f, 50f);

        private static readonly int windowIDESP = random.Next(int.MaxValue);
        private static Rect windowRectESP = new Rect(205f, 5f, 200f, 50f);

        private static readonly int windowIDStats = random.Next(int.MaxValue);
        private static Rect windowRectStats = new Rect(Screen.width - 210f, 5f, 200f, 50f);

        private static List<string> itemNames = new List<string>
        {
            "EMFReaderInventory",
            "FlashlightInventory",
            "CameraInventory",
            "LighterInventory",
            "CandleInventory",
            "UVFlashlightInventory",
            "CrucifixInventory",
            "DSLRCameraInventory",
            "EVPRecorderInventory",
            "SaltInventory",
            "SageInventory",
            "TripodInventory",
            "StrongFlashlightInventory",
            "MotionSensorInventory",
            "SoundSensorInventory",
            "SanityPillsInventory",
            "ThermometerInventory",
            "GhostWritingBookInventory",
            "IRLightSensorInventory",
            "ParabolicMicrophoneInventory",
            "IRLightSensorInventory",
            "ParabolicMicrophoneInventory",
            "GlowstickInventory",
            "HeadMountedCameraInventory"
        };

        private static int ping = 0;

        public static void Update()
        {
            // I'm doing this inside Update instead of OnGUI because OnGUI can run multiple times per frame.
            ping = PhotonNetwork.GetPing();
        }

        public static void OnGUI()
        {
            if (!CT.drawMenu)
                return;

            windowRectKeybinds = GUILayout.Window(windowIDKeybinds, windowRectKeybinds, (GUI.WindowFunction)KeybindMenu, "Keybinds", default);
            windowRectGeneral = GUILayout.Window(windowIDGeneral, windowRectGeneral, (GUI.WindowFunction)GeneralMenu, "General", default);
            windowRectESP = GUILayout.Window(windowIDESP, windowRectESP, (GUI.WindowFunction)ESPMenu, "ESP", default);
            windowRectStats = GUILayout.Window(windowIDStats, windowRectStats, (GUI.WindowFunction)StatMenu, "Stats", default);
        }

        private static void KeybindMenu(int id)
        {
            string colour = "#7CFC00"; // Green

            if (ping <= 40)
                colour = "#7CFC00"; // Green
            if (ping >= 50)
                colour = "#ffbf00"; // Amber
            if (ping >= 72)
                colour = "#EB2E2E"; // Red

            GUILayout.Label("[INSERT] Open/Close menu", default);

            GUILayout.Label(UIHelper.MakeEnable("[F1] Speedhack ", CT.speedHack), default);
            GUILayout.Label(UIHelper.MakeEnable("[F2] Fullbright ", CT.fullBright), default);

            GUILayout.Label($"Speed multiplier: {Math.Round(CT.speedHackMultiplier)}", default);
            CT.speedHackMultiplier = GUILayout.HorizontalSlider(CT.speedHackMultiplier, 1f, 10f, default);

            GUILayout.Label($"Ping: <color={colour}>{ping}</color>", default);

            GUI.DragWindow();
        }

        private static void GeneralMenu(int id)
        {
            GUILayout.Label("Custom name: ", default);
            CT.customName = GUILayout.TextField(CT.customName, default);

            if (GUILayout.Button("Change name", default))
                PhotonNetwork.NickName = CT.customName;

            GUI.DragWindow();
        }

        private static void ESPMenu(int id)
        {
            var toggleText = UIHelper.MakeEnable("Crosshair ", CT.crosshair);
            CT.crosshair = GUILayout.Toggle(CT.crosshair, toggleText, default);

            toggleText = UIHelper.MakeEnable("Player name ", CT.playerNameESP);
            CT.playerNameESP = GUILayout.Toggle(CT.playerNameESP, toggleText, default);

            toggleText = UIHelper.MakeEnable("Ghost name ", CT.ghostNameESP);
            CT.ghostNameESP = GUILayout.Toggle(CT.ghostNameESP, toggleText, default);

            GUILayout.Label("Crosshair scale:", default);
            ESP.crosshairScale = GUILayout.HorizontalSlider(ESP.crosshairScale, 1f, 15f, default);

            GUILayout.Label("Line thickness:", default);
            ESP.lineThickness = GUILayout.HorizontalSlider(ESP.lineThickness, 1f, 5f, default);

            GUI.DragWindow();
        }

        private static void StatMenu(int id)
        {
            GUILayout.Label("Level:", default);
            CT.customLevel = GUILayout.TextArea(CT.customLevel, default);

            GUILayout.Label("Money:", default);
            CT.customMoney = GUILayout.TextArea(CT.customMoney, default);

            if (GUILayout.Button("Set", default))
            {
                PlayerStats.SetPlayerLevel(int.Parse(CT.customLevel));
                PlayerStats.SetPlayerMoney(int.Parse(CT.customMoney));
            }

            CT.showItemCustomiser = GUILayout.Toggle(CT.showItemCustomiser, "Items", default);

            if (CT.showItemCustomiser)
            {
                GUILayout.Label("Amount:", default);

                CT.customItems = int.Parse(GUILayout.TextArea(CT.customItems.ToString(), default));

                foreach (var item in itemNames)
                {
                    if (GUILayout.Button(item, default))
                        PlayerStats.SetItemCount(item, CT.customItems);
                }
            }
            else // Reset window height so it isn't huge.
                windowRectStats.height = 50f;
            
            GUI.DragWindow();
        }
    }
}
