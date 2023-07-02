using System;
using System.Collections.Generic;
using AlephVault.Unity.SpriteUtils.Authoring.Types;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.WindRose.Authoring.Behaviours.Entities.Visuals;
using AlephVault.Unity.WindRose.SpriteUtils.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Authoring
    {
        namespace Behaviours
        {
            /// <summary>
            ///   Multi-State Sprited selector appliers are added on top of <see cref="MultiSprited"/>
            ///   visuals so they are able to replace the multiple sprites they use.
            /// </summary>
            [RequireComponent(typeof(MultiSprited))]
            public class MultiSpritedSelectionApplier : MultiStateSelectionApplier<Sprite, MultiSprited> {}
        }
    }
}