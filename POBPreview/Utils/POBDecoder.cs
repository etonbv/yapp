using System;
using System.Xml;
using System.IO.Compression;
using System.Text;

namespace POBPreview.Utils
{
	public static class POBDecoder
	{
        public static XmlDocument GetBuildXML(string pobCode)
        {
            if (string.IsNullOrEmpty(pobCode)) return null;

            byte[] decodedPobCode = Convert.FromBase64String(pobCode.Replace('-', '+').Replace('_', '/'));
            string unzippedPobCode = Unzip(decodedPobCode);

            XmlDocument fullPobXml = new XmlDocument();
            fullPobXml.LoadXml(unzippedPobCode);

            return fullPobXml;
        }

        private static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new ZLibStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
    }
}

