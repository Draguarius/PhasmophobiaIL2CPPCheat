using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using O = TestMod.Objects;
using CT = TestMod.Cheats.CheatToggles;
using MelonLoader;
using Photon.Pun;

namespace TestMod.Drawing
{
    public class ESP
    {
        public static float crosshairScale = 10f;
        public static float lineThickness = 2f;

        public static void OnGUI()
        {
            if (CT.crosshair)
                Crosshair();

            if (CT.playerNameESP)
                PlayerNameESP();

            if (CT.ghostNameESP)
                GhostNameESP();
        }

        private static void Crosshair()
        {
            var lineHorizontalStart = new Vector2(Screen.width / 2 - crosshairScale, Screen.height / 2);
            var lineHorizontalEnd = new Vector2(Screen.width / 2 + crosshairScale, Screen.height / 2);

            var lineVerticalStart = new Vector2(Screen.width / 2, Screen.height / 2 - crosshairScale);
            var lineVerticalEnd = new Vector2(Screen.width / 2, Screen.height / 2 + crosshairScale);

            Renderer.DrawLine(lineHorizontalStart, lineHorizontalEnd, Color.red, lineThickness);
            Renderer.DrawLine(lineVerticalStart, lineVerticalEnd, Color.red, lineThickness);
        }

        private static void PlayerNameESP()
        {
            var players = O.Instance.players;

            if (players == null)
                return;

            foreach (var plr in players)
            {
                if (plr != null && !plr.field_Public_PhotonView_0.IsMine)
                {
                    var plrPosition = plr.transform.position;
                    var w2s = Camera.main.WorldToScreenPoint(plrPosition);

                    w2s.y = Screen.height - (w2s.y + 1f);

                    if (w2s.z > 0)
                    {
                        var w2sVec2 = new Vector2(w2s.x, w2s.y);
                        var namePosition = new Rect(w2sVec2, new Vector2(300f, 100f));
                        var playerName = plr.field_Public_PhotonView_0.Owner.NickName;

                        GUI.color = Color.white;
                        GUI.Label(namePosition, playerName);
                    }
                }
            }
        }

        private static void GhostNameESP()
        {
            var ghosts = O.Instance.ghosts;

            if (ghosts == null)
                return;

            foreach (var ghost in ghosts)
            {
                if (ghost != null)
                {
                    var plrPosition = ghost.transform.position;
                    var w2s = Camera.main.WorldToScreenPoint(plrPosition);

                    w2s.y = Screen.height - (w2s.y + 1f);

                    if (w2s.z > 0)
                    {
                        var w2sVec2 = new Vector2(w2s.x, w2s.y);
                        var namePosition = new Rect(w2sVec2, new Vector2(100f, 100f));

                        var ghostName = ghost.field_Public_ValueTypePublicSealedObInBoStInBoInInInUnique_0.field_Public_String_0;
                        var ghostType = ghost.field_Public_ValueTypePublicSealedObInBoStInBoInInInUnique_0.field_Public_EnumNPublicSealedvanoSpWrPhPoBaJiMaReUnique_0.ToString();

                        var isHunting = ghost.ghost.field_Public_Boolean_3;

                        var ghostInfo = $"{ghostName}\n{ghostType}\n{(isHunting ? "<color=#EB2E2E>Hunting</color>" : "")}";

                        GUI.color = Color.cyan;
                        GUI.Label(namePosition, ghostInfo);
                    }
                }
            }
        }
    }
}
