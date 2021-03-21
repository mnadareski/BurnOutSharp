using System.Collections.Generic;
using System.IO;

namespace BurnOutSharp.PackerType
{
    // The official website for CExe also includes the source code (which does have to be retrieved by the Wayback Machine). http://www.scottlu.com/Content/CExe.html
    public class CExe : IContentCheck, IScannable
    {
        /// <inheritdoc/>
        public bool ShouldScan(byte[] magic) => true;

        /// <inheritdoc/>
        public string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            // "%WoÁa6.a6.a6.a6.{6..).f6.).`6.Ù0.`6."
            byte?[] check = new byte?[] { 0x25, 0x57, 0x6F, 0xC1, 0x61, 0x36, 0x01, 0x92, 0x61, 0x36, 0x01, 0x92, 0x61, 0x36, 0x01, 0x92, 0x61, 0x36, 0x00, 0x92, 0x7B, 0x36, 0x01, 0x92, 0x03, 0x29, 0x12, 0x92, 0x66, 0x36, 0x01, 0x92, 0x89, 0x29, 0x0A, 0x92, 0x60, 0x36, 0x01, 0x92, 0xD9, 0x30, 0x07, 0x92, 0x60, 0x36, 0x01, 0x92 };
            if (fileContent.FirstPosition(check, out int position))
            {
                return "CExe";
            }

            return null;
        }

        /// <inheritdoc/>
        public Dictionary<string, List<string>> Scan(Scanner scanner, string file)
        {
            if (!File.Exists(file))
                return null;

            using (var fs = File.OpenRead(file))
            {
                return Scan(scanner, fs, file);
            }
        }

        /// <inheritdoc/>
        // TODO: Add extraction if viable
        public Dictionary<string, List<string>> Scan(Scanner scanner, Stream stream, string file)
        {
            return null;
        }
    }
}
