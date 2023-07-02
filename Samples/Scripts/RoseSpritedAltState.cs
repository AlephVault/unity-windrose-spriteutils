using System.Collections;
using System.Collections.Generic;
using AlephVault.Unity.WindRose.Authoring.Behaviours.Entities.Visuals.StateBundles;
using AlephVault.Unity.WindRose.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Samples
    {
        public class RoseSpritedAltState : SpriteRoseBundle
        {
            private static readonly State ALT_STATE = State.Get("alt");
            
            protected override State GetState()
            {
                return ALT_STATE;
            }
        }
    }
}
