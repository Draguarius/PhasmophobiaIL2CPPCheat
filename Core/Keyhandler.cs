using MelonLoader;
using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using CT = TestMod.Cheats.CheatToggles;
using O = TestMod.Objects;

namespace TestMod
{
    public class Keyhandler
    {
        public static void Update()
        {
            MelonCoroutines.Start(Keys());
        }

        private static IEnumerator Keys()
        {
            var keyboard = Keyboard.current;

            if (keyboard.f1Key.wasPressedThisFrame)
                CT.speedHack = !CT.speedHack;

            if (keyboard.f2Key.wasPressedThisFrame)
            {
                CT.fullBright = !CT.fullBright;

                Cheats.Main.Fullbright();
            }

            if (keyboard.insertKey.wasPressedThisFrame)
                CT.drawMenu = !CT.drawMenu;

            yield return new WaitForEndOfFrame();
        }
    }
}
