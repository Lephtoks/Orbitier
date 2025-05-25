using System.Collections.Generic;
using Game.Scripts.Registry;
using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Data
{
    public static class OrbitierAssets
    {
        private static readonly Dictionary<string, AssetReader> assetReaders = new Dictionary<string, AssetReader>();

        public static void RegisterAssetReader(string @namespace, string path)
        {
            assetReaders.Add(@namespace, new AssetReader(@namespace, path));
        }

        public static Texture GetTexture(Identifier texture)
        {
            return assetReaders[texture.getNamespace()].getTexture(texture.getPath());
        }

        public static Model GetModel(Identifier model)
        {
            return assetReaders[model.getNamespace()].getModel(model.getPath());
        }
    }
}