using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O = TestMod.Objects;
using CT = TestMod.Cheats.CheatToggles;
using UnityEngine;
using MelonLoader;
using Photon.Pun;

namespace TestMod.Cheats
{
    public class Main
    {
        public static void Update()
        {
            Speedhack();
        }

        private static void Speedhack()
        {
            var localPlayer = O.Instance.localPlayer;

            if (localPlayer == null)
                return;

            if (CT.speedHack)
            {
                localPlayer.field_Public_FirstPersonController_0.m_WalkSpeed = CT.speedHackMultiplier * 3f;
                localPlayer.field_Public_FirstPersonController_0.m_RunSpeed = CT.speedHackMultiplier * 3f;
            }
            else
            {
                localPlayer.field_Public_FirstPersonController_0.m_WalkSpeed = 1.2f;
                localPlayer.field_Public_FirstPersonController_0.m_RunSpeed = 1.6f;
            }
        }

        public static void Fullbright()
        {
            if (!CT.fullBright && CT.fullBrightLight != null)
            {
                UnityEngine.Object.Destroy(CT.fullBrightLight);
                return;
            }

            var localPlayer = O.Instance.localPlayer;

            if (localPlayer == null)
                return;

            var headBone = localPlayer.field_Public_Animator_0.GetBoneTransform(HumanBodyBones.Head);
            CT.fullBrightLight = headBone.gameObject.AddComponent<Light>();

            if (CT.fullBright)
            {
                CT.fullBrightLight.color = Color.white;
                CT.fullBrightLight.range = 100f;
                CT.fullBrightLight.spotAngle = 10000f;
                CT.fullBrightLight.intensity = 0.3f;
            }
        }
    }
}
