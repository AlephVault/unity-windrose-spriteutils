using System.Collections;
using System.Collections.Generic;
using GameMeanMachine.Unity.WindRose.Authoring.Behaviours.Entities.Visuals.StateBundles;
using GameMeanMachine.Unity.WindRose.Types;
using UnityEngine;


namespace GameMeanMachine.Unity.WindRose.SpriteUtils
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
