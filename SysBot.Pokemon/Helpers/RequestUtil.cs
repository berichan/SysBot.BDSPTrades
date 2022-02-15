using PKHeX.Core;
using PKHeX.Core.AutoMod;
using SysBot.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SysBot.Pokemon
{
    public enum RequestType
    {
        ShinyLock,
        AlphaLock,
        OTLock
    }

    public static class RequestUtil<T> where T : PKM, new()
    {
        public static string Prefix { get; set; } = "!";

        public static T? GetPokemonViaNamedRequest(string folder, string name, out IReadOnlyList<RequestType>? rt)
        {
            var pkm = FetchFile(folder, name, out var rts);
            if (pkm != null)
            {
                rt = rts;
                return pkm;
            }

            pkm = GenViaSet(name, out var rtsgen);
            if (pkm != null)
            {
                rt = rtsgen;
                return pkm;
            }

            LogUtil.LogError($"Not found: {name}.", nameof(RequestUtil<T>));
            rt = null;
            return null;
        }

        static T? GenViaSet(string setb, out IReadOnlyList<RequestType>? rt)
        {
            var set = new ShowdownSet(setb);
            var template = (RegenTemplate)AutoLegalityWrapper.GetTemplate(set);
            var ret = new List<RequestType>();

            if (set.InvalidLines.Count != 0)
            {
                rt = null;
                return null;
            }

            var pk = AttemptGenerate(template);
            if (pk == null)
            {
                rt = null;
                return null;
            }

            if (!Contains(setb, "shiny:", StringComparison.OrdinalIgnoreCase) && !template.Shiny)
            {
                template.Shiny = true;
                template.Regen.Extra.ShinyType = Shiny.AlwaysSquare;

                var pkshiny = AttemptGenerate(template);
                if (pkshiny == null)
                {
                    ret.Add(RequestType.ShinyLock);
                    rt = ret;
                    return pk;
                }

                pk = pkshiny;
            }

            if (typeof(T) == typeof(PA8) && !Contains(setb, "alpha:", StringComparison.OrdinalIgnoreCase) && !template.Regen.Extra.Alpha)
            {
                template.Regen.Extra.Alpha = true;

                var pkalpha = AttemptGenerate(template);
                if (pkalpha == null)
                {
                    ret.Add(RequestType.AlphaLock);
                    rt = ret;
                    return pk;
                }

                pk = pkalpha;
            }

            // pure guess
            var cln = pk.Clone();
            cln.OT_Name = "berichan";
            var la = new LegalityAnalysis(cln);
            if (!la.Valid)
                ret.Add(RequestType.OTLock);

            rt = ret;
            return pk;
        }

        static T? AttemptGenerate(RegenTemplate template)
        {
            try
            {
                var sav = AutoLegalityWrapper.GetTrainerInfo<T>();
                var pkm = sav.GetLegal(template, out var result);
                var la = new LegalityAnalysis(pkm);
                var spec = GameInfo.Strings.Species[template.Species];
                pkm = PKMConverter.ConvertToType(pkm, typeof(T), out _) ?? pkm;
                if (pkm is not T pk || !la.Valid)
                    return null;
                pk.ResetPartyStats();
                return (T?)pkm;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return null;
            }
        }

        static T? FetchFile(string folder, string name, out IReadOnlyList<RequestType>? rt)
        {
            var files = EnumerateSpecificFiles(folder, name).ToArray();
            var lockTypes = new List<RequestType>();

            if (files.Length > 0)
            {
                // get the filename that most closely resembles the one they asked for
                var fileNameGet = files[0];
                int bestDistance = int.MaxValue;

                foreach (string file in files)
                {
                    var thisDistance = LevenshteinDistance.Compute(Path.GetFileNameWithoutExtension(file), name);
                    if (thisDistance < bestDistance)
                    {
                        bestDistance = thisDistance;
                        fileNameGet = file;
                    }
                }

                var pkm = PKMConverter.GetPKMfromBytes(File.ReadAllBytes(fileNameGet));
                if (pkm != null)
                {
                    pkm.ResetPartyStats();

                    if (!pkm.IsShiny)
                        lockTypes.Add(RequestType.ShinyLock);

                    if (pkm is PA8 pA8 && !pA8.IsAlpha)
                        lockTypes.Add(RequestType.AlphaLock);

                    var checkerClone = pkm.Clone();
                    checkerClone.OT_Name = "berichan";
                    checkerClone.Language = 2;

                    var la = new LegalityAnalysis(checkerClone);
                    if (!la.Valid)
                        lockTypes.Add(RequestType.OTLock);
                }

                rt = lockTypes;
                return (T?)pkm;
            }

            rt = null;
            return null;
        }

        static IEnumerable<string> EnumerateSpecificFiles(string directory, string initialTextForFileName)
        {
            foreach (string file in Directory.EnumerateFiles(directory))
            {
                var pt = Path.GetFileNameWithoutExtension(file);
                if (pt.StartsWith(initialTextForFileName, StringComparison.OrdinalIgnoreCase))
                {
                    yield return file;
                }
            }
        }

        static bool Contains(string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
