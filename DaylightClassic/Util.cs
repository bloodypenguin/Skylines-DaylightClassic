using System;
using System.Linq;
using ColossalFramework;
using UnityEngine;

namespace DaylightClassic
{
    public static class Util
    {
        public static Texture3DWrapper LoadTexture(string path, string name)
        {
            var tex1 = LoadTextureFromAssembly(path, false);
            tex1.name = name;
            var wrapper = ScriptableObject.CreateInstance<Texture3DWrapper>();
            wrapper.name = name;
            wrapper.texture = Texture3DWrapper.Convert(tex1);
            return wrapper;
        }

        private static Texture2D LoadTextureFromAssembly(string path, bool readOnly = true)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var textureStream = assembly.GetManifestResourceStream(path);

            var buf = new byte[textureStream.Length];  //declare arraysize
            textureStream.Read(buf, 0, buf.Length); // read from stream to byte array
            var tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            tex.LoadImage(buf);
            tex.Apply(false, readOnly);
            return tex;
        }

        public static Type FindType(string className)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types.Where(type => type.Name == className))
                    {
                        return type;
                    }
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }

        public static bool InMenu()
        {
            return ToolManager.instance.m_properties.m_mode == ItemClass.Availability.None;
        }
    }
}