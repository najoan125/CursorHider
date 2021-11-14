using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityModManagerNet;

namespace AdofaiFirstMod
{
    public class Setting : UnityModManager.ModSettings
    {
        //타입은 임시로 해둔거지 꼭 이렇게 하라는건 아닙니다
        public bool EditorShow = false;

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            var filepath = GetPath(modEntry);
            try
            {
                using (var writer = new StreamWriter(filepath))
                {
                    var serializer = new XmlSerializer(GetType());
                    serializer.Serialize(writer, this);
                }
            }
            catch
            {
            }
        }

        public override string GetPath(UnityModManager.ModEntry modEntry)
        {
            return Path.Combine(modEntry.Path, GetType().Name + ".xml");
        }

    }
}
