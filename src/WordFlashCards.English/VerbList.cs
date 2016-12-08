﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFlashCards.English
{
    public class VerbList
    {
        private List<Verb> _verbs;

        public VerbList()
        {
            InitializeVerbs();
        }

        public IEnumerable<Verb> FindConjugatedVerb(string text)
        {
            var result = new List<Verb>();

            if (text.EndsWith("ed"))
                ProcessVerbEnding(result, text.Substring(0, text.Length - 2));
            else if (text.EndsWith("ing"))
                ProcessVerbEnding(result, text.Substring(0, text.Length - 3));
            else if (text.EndsWith("s") && (text != "has") && (text != "was"))
                result.Add(new Verb(text.Substring(0, text.Length - 2), text));
            else
            {
                var irregulars = _verbs.Where(v => (v.Infinitive == text) || (v.Form == text));
                if (irregulars.Any())
                    result.AddRange(irregulars);
            }
            result.Add(new Verb(text, text));
            return result;
        }

        private void ProcessVerbEnding(List<Verb> result, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (text.Length <= 1)
                return;

            var textMinusOne = text.Substring(0, text.Length - 1);
            var lastChar = text[text.Length - 1];

            if (lastChar == text[text.Length - 2])
                result.Add(new Verb(textMinusOne, text));
            else if (lastChar == 'y')
                result.Add(new Verb(textMinusOne + "ie", text));
            else if ("bcdfghjklmnpqrtvwxz".Contains(lastChar))
                result.Add(new Verb(text + "e", text));
            else if (lastChar == 'i')
                result.Add(new Verb(text + "e", text));
        }

        private void InitializeVerbs()
        {
            _verbs = new List<Verb>()
            {
                new Verb("arise", "arisen"),
                new Verb("arise", "arose"),
                new Verb("awake", "awakened"),
                new Verb("awake", "awoke"),
                new Verb("awake", "awoken"),
                new Verb("backslide", "backslid"),
                new Verb("backslide", "backslidden"),
                new Verb("be", "been"),
                new Verb("be", "were"),
                new Verb("be", "was"),
                new Verb("be", "wasn"),
                new Verb("be", "wasn't"),
                new Verb("be", "am"),
                new Verb("be", "m"),
                new Verb("be", "are"),
                new Verb("be", "aren"),
                new Verb("be", "aren't"),
                new Verb("be", "re"),
                new Verb("be", "is"),
                new Verb("be", "isn't"),
                new Verb("be", "isn"),
                new Verb("be", "'s"),
                new Verb("bear", "bore"),
                new Verb("bear", "born"),
                new Verb("bear", "borne"),
                new Verb("beat", "beat"),
                new Verb("beat", "beaten"),
                new Verb("become", "became"),
                new Verb("become", "become"),
                new Verb("begin", "began"),
                new Verb("begin", "begun"),
                new Verb("bend", "bent"),
                new Verb("bet", "bet"),
                new Verb("bet", "betted"),
                new Verb("bid", "bade"),
                new Verb("bid", "bid"),
                new Verb("bid", "bidden"),
                new Verb("bind", "bound"),
                new Verb("bite", "bit"),
                new Verb("bite", "bitten"),
                new Verb("bleed", "bled"),
                new Verb("blow", "blew"),
                new Verb("blow", "blown"),
                new Verb("break", "broke"),
                new Verb("break", "broken"),
                new Verb("breed", "bred"),
                new Verb("bring", "brought"),
                new Verb("broadcast", "broadcast"),
                new Verb("broadcast", "broadcasted"),
                new Verb("browbeat", "browbeat"),
                new Verb("browbeat", "browbeaten"),
                new Verb("build", "built"),
                new Verb("burn", "burned"),
                new Verb("burn", "burnt"),
                new Verb("burst", "burst"),
                new Verb("bust", "bust"),
                new Verb("bust", "busted"),
                new Verb("buy", "bought"),
                new Verb("cast", "cast"),
                new Verb("catch", "caught"),
                new Verb("choose", "chose"),
                new Verb("choose", "chosen"),
                new Verb("cling", "clung"),
                new Verb("clothe", "clad"),
                new Verb("clothe", "clothed"),
                new Verb("come", "came"),
                new Verb("come", "come"),
                new Verb("cost", "cost"),
                new Verb("creep", "crept"),
                new Verb("crossbreed", "crossbred"),
                new Verb("cut", "cut"),
                new Verb("daydream", "daydreamed"),
                new Verb("daydream", "daydreamt"),
                new Verb("deal", "dealt"),
                new Verb("dig", "dug"),
                new Verb("disprove", "disproved"),
                new Verb("disprove", "disproven"),
                new Verb("dive", "dived"),
                new Verb("dive", "dove"),
                new Verb("do", "did"),
                new Verb("do", "done"),
                new Verb("draw", "drawn"),
                new Verb("draw", "drew"),
                new Verb("dream", "dreamed"),
                new Verb("dream", "dreamt"),
                new Verb("drink", "drank"),
                new Verb("drink", "drunk"),
                new Verb("drive", "driven"),
                new Verb("drive", "drove"),
                new Verb("dwell", "dwelled"),
                new Verb("dwell", "dwelt"),
                new Verb("eat", "ate"),
                new Verb("eat", "eaten"),
                new Verb("fall", "fallen"),
                new Verb("fall", "fell"),
                new Verb("feed", "fed"),
                new Verb("feel", "felt"),
                new Verb("fight", "fought"),
                new Verb("find", "found"),
                new Verb("fit", "fit"),
                new Verb("fit", "fitted"),
                new Verb("flee", "fled"),
                new Verb("fling", "flung"),
                new Verb("fly", "flew"),
                new Verb("fly", "flown"),
                new Verb("forbid", "forbade"),
                new Verb("forbid", "forbidden"),
                new Verb("forecast", "forecast"),
                new Verb("forego", "foregone"),
                new Verb("forego", "forewent"),
                new Verb("foresee", "foresaw"),
                new Verb("foresee", "foreseen"),
                new Verb("foretell", "foretold"),
                new Verb("forget", "forgot"),
                new Verb("forget", "forgotten"),
                new Verb("forgive", "forgave"),
                new Verb("forgive", "forgiven"),
                new Verb("forsake", "forsaken"),
                new Verb("forsake", "forsook"),
                new Verb("freeze", "froze"),
                new Verb("freeze", "frozen"),
                new Verb("frostbite", "frostbit"),
                new Verb("frostbite", "frostbitten"),
                new Verb("get", "got"),
                new Verb("get", "gotten"),
                new Verb("give", "gave"),
                new Verb("give", "given"),
                new Verb("go", "gone"),
                new Verb("go", "went"),
                new Verb("grind", "ground"),
                new Verb("grow", "grew"),
                new Verb("grow", "grown"),
                new Verb("hand-feed", "hand-fed"),
                new Verb("handwrite", "handwritten"),
                new Verb("handwrite", "handwrote"),
                new Verb("hang", "hung"),
                new Verb("have", "had"),
                new Verb("have", "has"),
                new Verb("have", "hasn"),
                new Verb("have", "hasn't"),
                new Verb("hear", "heard"),
                new Verb("hew", "hewed"),
                new Verb("hew", "hewn"),
                new Verb("hide", "hid"),
                new Verb("hide", "hidden"),
                new Verb("hit", "hit"),
                new Verb("hold", "held"),
                new Verb("hurt", "hurt"),
                new Verb("inbreed", "inbred"),
                new Verb("inlay", "inlaid"),
                new Verb("input", "input"),
                new Verb("input", "inputted"),
                new Verb("interbreed", "interbred"),
                new Verb("interweave", "interweaved"),
                new Verb("interweave", "interwove"),
                new Verb("interweave", "interwoven"),
                new Verb("interwind", "interwound"),
                new Verb("jerry-build", "jerry-built"),
                new Verb("keep", "kept"),
                new Verb("kneel", "kneeled"),
                new Verb("kneel", "knelt"),
                new Verb("knit", "knit"),
                new Verb("knit", "knitted"),
                new Verb("know", "knew"),
                new Verb("know", "known"),
                new Verb("lay", "laid"),
                new Verb("lead", "led"),
                new Verb("lean", "leaned"),
                new Verb("lean", "leant"),
                new Verb("leap", "leaped"),
                new Verb("leap", "leapt"),
                new Verb("learn", "learned"),
                new Verb("learn", "learnt"),
                new Verb("leave", "left"),
                new Verb("lend", "lent"),
                new Verb("let", "let"),
                new Verb("lie", "lain"),
                new Verb("lie", "lay"),
                new Verb("lie", "lied"),
                new Verb("light", "lighted"),
                new Verb("light", "lit"),
                new Verb("lip-read", "lip-read"),
                new Verb("lose", "lost"),
                new Verb("make", "made"),
                new Verb("mean", "meant"),
                new Verb("meet", "met"),
                new Verb("miscast", "miscast"),
                new Verb("misdeal", "misdealt"),
                new Verb("misdo", "misdid"),
                new Verb("misdo", "misdone"),
                new Verb("mishear", "misheard"),
                new Verb("mislay", "mislaid"),
                new Verb("mislead", "misled"),
                new Verb("mislearn", "mislearned"),
                new Verb("mislearn", "mislearnt"),
                new Verb("misread", "misread"),
                new Verb("misset", "misset"),
                new Verb("misspeak", "misspoke"),
                new Verb("misspeak", "misspoken"),
                new Verb("misspell", "misspelled"),
                new Verb("misspell", "misspelt"),
                new Verb("misspend", "misspent"),
                new Verb("mistake", "mistaken"),
                new Verb("mistake", "mistook"),
                new Verb("misteach", "mistaught"),
                new Verb("misunderstand", "misunderstood"),
                new Verb("miswrite", "miswritten"),
                new Verb("miswrite", "miswrote"),
                new Verb("mow", "mowed"),
                new Verb("mow", "mown"),
                new Verb("offset", "offset"),
                new Verb("outbid", "outbid"),
                new Verb("outbreed", "outbred"),
                new Verb("outdo", "outdid"),
                new Verb("outdo", "outdone"),
                new Verb("outdraw", "outdrawn"),
                new Verb("outdraw", "outdrew"),
                new Verb("outdrink", "outdrank"),
                new Verb("outdrink", "outdrunk"),
                new Verb("outdrive", "outdriven"),
                new Verb("outdrive", "outdrove"),
                new Verb("outfight", "outfought"),
                new Verb("outfly", "outflew"),
                new Verb("outfly", "outflown"),
                new Verb("outgrow", "outgrew"),
                new Verb("outgrow", "outgrown"),
                new Verb("outleap", "outleaped"),
                new Verb("outleap", "outleapt"),
                new Verb("outlie", "outlied"),
                new Verb("outride", "outridden"),
                new Verb("outride", "outrode"),
                new Verb("outrun", "outran"),
                new Verb("outrun", "outrun"),
                new Verb("outsell", "outsold"),
                new Verb("outshine", "outshined"),
                new Verb("outshine", "outshone"),
                new Verb("outshoot", "outshot"),
                new Verb("outsing", "outsang"),
                new Verb("outsing", "outsung"),
                new Verb("outsit", "outsat"),
                new Verb("outsleep", "outslept"),
                new Verb("outsmell", "outsmelled"),
                new Verb("outsmell", "outsmelt"),
                new Verb("outspeak", "outspoke"),
                new Verb("outspeak", "outspoken"),
                new Verb("outspeed", "outsped"),
                new Verb("outspend", "outspent"),
                new Verb("outswear", "outswore"),
                new Verb("outswear", "outsworn"),
                new Verb("outswim", "outswam"),
                new Verb("outswim", "outswum"),
                new Verb("outthink", "outthought"),
                new Verb("outthrow", "outthrew"),
                new Verb("outthrow", "outthrown"),
                new Verb("outwrite", "outwritten"),
                new Verb("outwrite", "outwrote"),
                new Verb("overbid", "overbid"),
                new Verb("overbreed", "overbred"),
                new Verb("overbuild", "overbuilt"),
                new Verb("overbuy", "overbought"),
                new Verb("overcome", "overcame"),
                new Verb("overcome", "overcome"),
                new Verb("overdo", "overdid"),
                new Verb("overdo", "overdone"),
                new Verb("overdraw", "overdrawn"),
                new Verb("overdraw", "overdrew"),
                new Verb("overdrink", "overdrank"),
                new Verb("overdrink", "overdrunk"),
                new Verb("overeat", "overate"),
                new Verb("overeat", "overeaten"),
                new Verb("overfeed", "overfed"),
                new Verb("overhang", "overhung"),
                new Verb("overhear", "overheard"),
                new Verb("overlay", "overlaid"),
                new Verb("overpay", "overpaid"),
                new Verb("override", "overridden"),
                new Verb("override", "overrode"),
                new Verb("overrun", "overran"),
                new Verb("overrun", "overrun"),
                new Verb("oversee", "oversaw"),
                new Verb("oversee", "overseen"),
                new Verb("oversell", "oversold"),
                new Verb("oversew", "oversewed"),
                new Verb("oversew", "oversewn"),
                new Verb("overshoot", "overshot"),
                new Verb("oversleep", "overslept"),
                new Verb("overspeak", "overspoke"),
                new Verb("overspeak", "overspoken"),
                new Verb("overspend", "overspent"),
                new Verb("overspill", "overspilled"),
                new Verb("overspill", "overspilt"),
                new Verb("overtake", "overtaken"),
                new Verb("overtake", "overtook"),
                new Verb("overthink", "overthought"),
                new Verb("overthrow", "overthrew"),
                new Verb("overthrow", "overthrown"),
                new Verb("overwind", "overwound"),
                new Verb("overwrite", "overwritten"),
                new Verb("overwrite", "overwrote"),
                new Verb("partake", "partaken"),
                new Verb("partake", "partook"),
                new Verb("pay", "paid"),
                new Verb("plead", "pleaded"),
                new Verb("plead", "pled"),
                new Verb("prebuild", "prebuilt"),
                new Verb("predo", "predid"),
                new Verb("predo", "predone"),
                new Verb("premake", "premade"),
                new Verb("prepay", "prepaid"),
                new Verb("presell", "presold"),
                new Verb("preset", "preset"),
                new Verb("preshrink", "preshrank"),
                new Verb("preshrink", "preshrunk"),
                new Verb("proofread", "proofread"),
                new Verb("prove", "proved"),
                new Verb("prove", "proven"),
                new Verb("put", "put"),
                new Verb("quick-freeze", "quick-froze"),
                new Verb("quick-freeze", "quick-frozen"),
                new Verb("quit", "quit"),
                new Verb("quit", "quitted"),
                new Verb("read", "read"),
                new Verb("reawake", "reawaken"),
                new Verb("reawake", "reawoke"),
                new Verb("rebid", "rebid"),
                new Verb("rebind", "rebound"),
                new Verb("rebroadcast", "rebroadcast"),
                new Verb("rebroadcast", "rebroadcasted"),
                new Verb("rebuild", "rebuilt"),
                new Verb("recast", "recast"),
                new Verb("recut", "recut"),
                new Verb("redeal", "redealt"),
                new Verb("redo", "redid"),
                new Verb("redo", "redone"),
                new Verb("redraw", "redrawn"),
                new Verb("redraw", "redrew"),
                new Verb("refit", "refit"),
                new Verb("refit", "refitted"),
                new Verb("regrind", "reground"),
                new Verb("regrow", "regrew"),
                new Verb("regrow", "regrown"),
                new Verb("rehang", "rehung"),
                new Verb("rehear", "reheard"),
                new Verb("reknit", "reknit"),
                new Verb("reknit", "reknitted"),
                new Verb("relay", "relaid"),
                new Verb("relay", "relayed"),
                new Verb("relearn", "relearned"),
                new Verb("relearn", "relearnt"),
                new Verb("relight", "relighted"),
                new Verb("relight", "relit"),
                new Verb("remake", "remade"),
                new Verb("repay", "repaid"),
                new Verb("reread", "reread"),
                new Verb("rerun", "reran"),
                new Verb("rerun", "rerun"),
                new Verb("resell", "resold"),
                new Verb("resend", "resent"),
                new Verb("reset", "reset"),
                new Verb("resew", "resewed"),
                new Verb("resew", "resewn"),
                new Verb("retake", "retaken"),
                new Verb("retake", "retook"),
                new Verb("reteach", "retaught"),
                new Verb("retear", "retore"),
                new Verb("retear", "retorn"),
                new Verb("retell", "retold"),
                new Verb("rethink", "rethought"),
                new Verb("retread", "retread"),
                new Verb("retrofit", "retrofit"),
                new Verb("retrofit", "retrofitted"),
                new Verb("rewake", "rewaked"),
                new Verb("rewake", "rewaken"),
                new Verb("rewake", "rewoke"),
                new Verb("rewear", "rewore"),
                new Verb("rewear", "reworn"),
                new Verb("reweave", "reweaved"),
                new Verb("reweave", "rewove"),
                new Verb("reweave", "rewoven"),
                new Verb("rewed", "rewed"),
                new Verb("rewed", "rewedded"),
                new Verb("rewet", "rewet"),
                new Verb("rewet", "rewetted"),
                new Verb("rewin", "rewon"),
                new Verb("rewind", "rewound"),
                new Verb("rewrite", "rewritten"),
                new Verb("rewrite", "rewrote"),
                new Verb("rid", "rid"),
                new Verb("ride", "ridden"),
                new Verb("ride", "rode"),
                new Verb("ring", "rang"),
                new Verb("ring", "rung"),
                new Verb("rise", "risen"),
                new Verb("rise", "rose"),
                new Verb("roughcast", "roughcast"),
                new Verb("run", "ran"),
                new Verb("run", "run"),
                new Verb("sand-cast", "sand-cast"),
                new Verb("saw", "sawed"),
                new Verb("saw", "sawn"),
                new Verb("say", "said"),
                new Verb("see", "saw"),
                new Verb("see", "seen"),
                new Verb("seek", "sought"),
                new Verb("sell", "sold"),
                new Verb("send", "sent"),
                new Verb("set", "set"),
                new Verb("sew", "sewed"),
                new Verb("sew", "sewn"),
                new Verb("shake", "shaken"),
                new Verb("shake", "shook"),
                new Verb("shave", "shaved"),
                new Verb("shave", "shaven"),
                new Verb("shear", "sheared"),
                new Verb("shear", "shorn"),
                new Verb("shed", "shed"),
                new Verb("shine", "shined"),
                new Verb("shine", "shone"),
                new Verb("shit", "shat"),
                new Verb("shit", "shit"),
                new Verb("shit", "shitted"),
                new Verb("shoot", "shot"),
                new Verb("show", "showed"),
                new Verb("show", "shown"),
                new Verb("shrink", "shrank"),
                new Verb("shrink", "shrunk"),
                new Verb("shut", "shut"),
                new Verb("sight-read", "sight-read"),
                new Verb("sing", "sang"),
                new Verb("sing", "sung"),
                new Verb("sink", "sank"),
                new Verb("sink", "sunk"),
                new Verb("sit", "sat"),
                new Verb("slay", "slain"),
                new Verb("slay", "slayed"),
                new Verb("slay", "slew"),
                new Verb("sleep", "slept"),
                new Verb("slide", "slid"),
                new Verb("sling", "slung"),
                new Verb("slink", "slinked"),
                new Verb("slink", "slunk"),
                new Verb("slit", "slit"),
                new Verb("smell", "smelled"),
                new Verb("smell", "smelt"),
                new Verb("sneak", "sneaked"),
                new Verb("sneak", "snuck"),
                new Verb("sow", "sowed"),
                new Verb("sow", "sown"),
                new Verb("speak", "spoke"),
                new Verb("speak", "spoken"),
                new Verb("speed", "sped"),
                new Verb("speed", "speeded"),
                new Verb("spell", "spelled"),
                new Verb("spell", "spelt"),
                new Verb("spend", "spent"),
                new Verb("spill", "spilled"),
                new Verb("spill", "spilt"),
                new Verb("spin", "spun"),
                new Verb("spit", "spat"),
                new Verb("spit", "spit"),
                new Verb("split", "split"),
                new Verb("spoil", "spoiled"),
                new Verb("spoil", "spoilt"),
                new Verb("spoon-feed", "spoon-fed"),
                new Verb("spread", "spread"),
                new Verb("spring", "sprang"),
                new Verb("spring", "sprung"),
                new Verb("stand", "stood"),
                new Verb("steal", "stole"),
                new Verb("steal", "stolen"),
                new Verb("stick", "stuck"),
                new Verb("sting", "stung"),
                new Verb("stink", "stank"),
                new Verb("stink", "stunk"),
                new Verb("strew", "strewed"),
                new Verb("strew", "strewn"),
                new Verb("stride", "stridden"),
                new Verb("stride", "strode"),
                new Verb("strike", "stricken"),
                new Verb("strike", "struck"),
                new Verb("string", "strung"),
                new Verb("strive", "strived"),
                new Verb("strive", "striven"),
                new Verb("strive", "strove"),
                new Verb("sublet", "sublet"),
                new Verb("sunburn", "sunburned"),
                new Verb("sunburn", "sunburnt"),
                new Verb("swear", "swore"),
                new Verb("swear", "sworn"),
                new Verb("sweat", "sweat"),
                new Verb("sweat", "sweated"),
                new Verb("sweep", "swept"),
                new Verb("swell", "swelled"),
                new Verb("swell", "swollen"),
                new Verb("swim", "swam"),
                new Verb("swim", "swum"),
                new Verb("swing", "swung"),
                new Verb("take", "taken"),
                new Verb("take", "took"),
                new Verb("teach", "taught"),
                new Verb("tear", "tore"),
                new Verb("tear", "torn"),
                new Verb("telecast", "telecast"),
                new Verb("tell", "told"),
                new Verb("test-drive", "test-driven"),
                new Verb("test-drive", "test-drove"),
                new Verb("test-fly", "test-flew"),
                new Verb("test-fly", "test-flown"),
                new Verb("think", "thought"),
                new Verb("throw", "threw"),
                new Verb("throw", "thrown"),
                new Verb("thrust", "thrust"),
                new Verb("tread", "trod"),
                new Verb("tread", "trodden"),
                new Verb("typecast", "typecast"),
                new Verb("typeset", "typeset"),
                new Verb("typewrite", "typewritten"),
                new Verb("typewrite", "typewrote"),
                new Verb("unbend", "unbent"),
                new Verb("unbind", "unbound"),
                new Verb("unclothe", "unclad"),
                new Verb("unclothe", "unclothed"),
                new Verb("underbid", "underbid"),
                new Verb("undercut", "undercut"),
                new Verb("underfeed", "underfed"),
                new Verb("undergo", "undergone"),
                new Verb("undergo", "underwent"),
                new Verb("underlie", "underlain"),
                new Verb("underlie", "underlay"),
                new Verb("undersell", "undersold"),
                new Verb("underspend", "underspent"),
                new Verb("understand", "understood"),
                new Verb("undertake", "undertaken"),
                new Verb("undertake", "undertook"),
                new Verb("underwrite", "underwritten"),
                new Verb("underwrite", "underwrote"),
                new Verb("undo", "undid"),
                new Verb("undo", "undone"),
                new Verb("unfreeze", "unfroze"),
                new Verb("unfreeze", "unfrozen"),
                new Verb("unhang", "unhung"),
                new Verb("unhide", "unhid"),
                new Verb("unhide", "unhidden"),
                new Verb("unknit", "unknit"),
                new Verb("unknit", "unknitted"),
                new Verb("unlearn", "unlearned"),
                new Verb("unlearn", "unlearnt"),
                new Verb("unsew", "unsewed"),
                new Verb("unsew", "unsewn"),
                new Verb("unsling", "unslung"),
                new Verb("unspin", "unspun"),
                new Verb("unstick", "unstuck"),
                new Verb("unstring", "unstrung"),
                new Verb("unweave", "unweaved"),
                new Verb("unweave", "unwove"),
                new Verb("unweave", "unwoven"),
                new Verb("unwind", "unwound"),
                new Verb("uphold", "upheld"),
                new Verb("upset", "upset"),
                new Verb("wake", "waked"),
                new Verb("wake", "woke"),
                new Verb("wake", "woken"),
                new Verb("waylay", "waylaid"),
                new Verb("wear", "wore"),
                new Verb("wear", "worn"),
                new Verb("weave", "weaved"),
                new Verb("weave", "wove"),
                new Verb("weave", "woven"),
                new Verb("wed", "wed"),
                new Verb("wed", "wedded"),
                new Verb("weep", "wept"),
                new Verb("wet", "wet"),
                new Verb("wet", "wetted"),
                new Verb("whet", "whetted"),
                new Verb("win", "won"),
                new Verb("wind", "wound"),
                new Verb("withdraw", "withdrawn"),
                new Verb("withdraw", "withdrew"),
                new Verb("withhold", "withheld"),
                new Verb("withstand", "withstood"),
                new Verb("wring", "wrung"),
                new Verb("write", "written"),
                new Verb("write", "wrote")
            };


        }
    }
}