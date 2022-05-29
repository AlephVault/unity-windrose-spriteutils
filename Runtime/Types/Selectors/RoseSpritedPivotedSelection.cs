using System;
using System.Collections.Generic;
using AlephVault.Unity.Layout.Utils;
using AlephVault.Unity.SpriteUtils.Types;
using GameMeanMachine.Unity.WindRose.Authoring.ScriptableObjects.VisualResources;
using GameMeanMachine.Unity.WindRose.Types;
using UnityEngine;
using Object = UnityEngine.Object;


namespace GameMeanMachine.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        namespace Selectors
        {
            /// <summary>
            ///   An oriented & sprited selector involves just one sprite per direction.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class RoseSpritedPivotedSelection : MappedSpriteGridSelection<
                Tuple<RoseTuple<Vector2Int>, Vector2>, SpriteRose
            >
            {
                public RoseSpritedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<RoseTuple<Vector2Int>, Vector2> selection
                ) : base(sourceGrid, selection)
                {
                    if (selection == null) throw new ArgumentNullException(nameof(selection));
                }

                /// <summary>
                ///   The validation and mapping involves a single sprite from a single
                ///   vector for each direction.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The positions rose tuple to select</param>
                /// <returns>The mapped WindRose sprites rose</returns>
                protected override SpriteRose ValidateAndMap(
                    SpriteGrid sourceGrid, Tuple<RoseTuple<Vector2Int>, Vector2> selection
                )
                {
                    SpriteRose spriteRose = ScriptableObject.CreateInstance<SpriteRose>();
                    Behaviours.SetObjectFieldValues(spriteRose, new Dictionary<string, object>() {
                        { "up", ValidateAndMapSprite(sourceGrid, selection.Item1.Up, selection.Item2) },
                        { "down", ValidateAndMapSprite(sourceGrid, selection.Item1.Down, selection.Item2) },
                        { "left", ValidateAndMapSprite(sourceGrid, selection.Item1.Left, selection.Item2) },
                        { "right", ValidateAndMapSprite(sourceGrid, selection.Item1.Right, selection.Item2) }
                    });
                    return spriteRose;
                }

                ~RoseSpritedPivotedSelection()
                {
                    if (result != null)
                    {
                        Object.Destroy(result);
                    }
                }
            }
        }
    }
}
