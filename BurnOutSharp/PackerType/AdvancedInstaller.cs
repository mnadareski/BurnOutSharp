using System.Collections.Generic;
using BurnOutSharp.Matching;

namespace BurnOutSharp.PackerType
{
    // TODO: Add extraction and verify that all versions are detected
    public class AdvancedInstaller : IContentCheck
    {
        /// <summary>
        /// Set of all ContentMatchSets for this protection
        /// </summary>
        private static readonly List<ContentMatchSet> contentMatchers = new List<ContentMatchSet>
        {
            // Software\Caphyon\Advanced Installer
            new ContentMatchSet(new byte?[]
            {
                0x53, 0x6F, 0x66, 0x74, 0x77, 0x61, 0x72, 0x65,
                0x5C, 0x43, 0x61, 0x70, 0x68, 0x79, 0x6F, 0x6E,
                0x5C, 0x41, 0x64, 0x76, 0x61, 0x6E, 0x63, 0x65,
                0x64, 0x20, 0x49, 0x6E, 0x73, 0x74, 0x61, 0x6C,
                0x6C, 0x65, 0x72
            }, "Caphyon Advanced Installer"),
        };

        /// <inheritdoc/>
        public string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            return MatchUtil.GetFirstMatch(file, fileContent, contentMatchers, includePosition);
        }
    }
}
