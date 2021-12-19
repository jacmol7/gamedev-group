using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour
{
    [ExecuteInEditMode]
    void Start()
    {
        // Makes the texture of whatever this is applied to tile correctly based off its size.
        // This avoids the need to manually set this in the unity editor when designing a level.
        // This won't support objects which change their size during gameplay but that is deliberate
        // for performance.
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }
}
