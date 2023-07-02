using System;
using AlephVault.Unity.SpriteUtils.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        namespace Selectors
        {
            /// <summary>
            ///   A simple & sprited selector involves just one sprite.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class SpritedPivotedSelection : MappedSpriteGridSelection<Tuple<Vector2Int, Vector2>, Sprite>
            {
                public SpritedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<Vector2Int, Vector2> selection
                ) : base(sourceGrid, selection)
                {
                }

                /// <summary>
                ///   The validation and mapping process involves a single sprite
                ///   from a single vector.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The position to select</param>
                /// <returns>The mapped sprite</returns>
                protected override Sprite ValidateAndMap(
                    SpriteGrid sourceGrid, Tuple<Vector2Int, Vector2> selection
                )
                {
                    return ValidateAndMapSprite(sourceGrid, selection.Item1, selection.Item2);
                }
            }
        }
    }
}