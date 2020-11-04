using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestMod.Cheats
{
    public class CheatToggles
    {
        public static bool speedHack;

        public static float speedHackMultiplier = 3f;

        public static bool drawMenu = true;

        public static string customName = PhotonNetwork.NickName;

        public static bool forceHost;

        public static bool crosshair = true;

        public static bool playerNameESP = true;

        public static bool ghostNameESP = true;

        public static bool fullBright;

        public static Light fullBrightLight;

        public static string customLevel = (FileBasedPrefs.GetInt("myTotalExp", 1) * 100).ToString();

        public static string customMoney = FileBasedPrefs.GetInt("PlayersMoney", 0).ToString();

        public static int customItems = 1;

        public static bool showItemCustomiser = false;
    }
}
