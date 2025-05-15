using System.Collections.Generic;
using Game.Scripts.Render;
using System;
using System.IO;
using Game.Scripts.Registry;
using UnityEngine;

namespace Game.Scripts.data
{
    public class AssetReader
    {
        private readonly Dictionary<string, Model> cacheModels = new Dictionary<string, Model>();
        private readonly Dictionary<string, Texture> cacheTextures = new Dictionary<string, Texture>();
        private readonly string name;
        private readonly string dir;
        private readonly string fullPath;

        public AssetReader(string name, string dir)
        {
            this.name = name;
            this.dir = dir;
            this.fullPath = dir + "/" + name;
        }

        public Model getModel(string path)
        {
            if (cacheModels.TryGetValue(path, out var tex)) return tex;
            
            ModelRoot root = JsonUtility.FromJson<ModelRoot>(File.ReadAllText(fullPath +  "/models/" + path +  ".json"));
            
            var entries = new List<Model.ModelEntry>();

            foreach (var element in root.elements)
            {
                var modelEntry = new Model.ModelEntry(OrbitierAssets.GetTexture(Identifier.Parse(element.texture)), element.size, element.offset, element.rotation);
                entries.Add(modelEntry);
            }
            Model model = new Model(entries);
            cacheModels.Add(path, model);
            return model;
        }

        public Texture getTexture(string path)
        {
            if (cacheTextures.TryGetValue(path, out var tex)) return tex;
            
            byte[] bytes = File.ReadAllBytes(fullPath +  "/textures/" + path + ".png");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            
            cacheTextures.Add(path, texture);
            return texture;
        }
        
        [Serializable]
        private class JSONModel
        {
            public Vector2 offset;
            public Vector2 size;
            public float rotation;
            public string texture;
        }

        [Serializable]
        private class ModelRoot
        {
            public List<JSONModel> elements;
        }
    }
}