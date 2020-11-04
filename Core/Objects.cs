using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using Photon.Pun;

namespace TestMod
{
    public class Objects
    {
        #region Singleton implementation
        private static readonly Objects instance = new Objects();

        static Objects()
        {
        }

        private Objects()
        {
        }

        public static Objects Instance
        {
            get => instance;
        }
        #endregion

        public Player localPlayer;
        public Player[] players;

        public GhostInfo[] ghosts;

        public void Start()
        {
            MelonCoroutines.Start(CollectGameObjects());
        }

        private IEnumerator CollectGameObjects()
        {
            yield return new WaitForSeconds(2f);

            players = UnityEngine.Object.FindObjectsOfType<Player>();
            localPlayer = players.Where(x => x.field_Public_PhotonView_0.IsMine).FirstOrDefault();

            yield return new WaitForSeconds(0.25f);

            ghosts = UnityEngine.Object.FindObjectsOfType<GhostInfo>();

            MelonCoroutines.Start(CollectGameObjects());
        }
    }
}
