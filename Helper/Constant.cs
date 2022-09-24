using System;
namespace AlkitabAPI.Helper
{
    public class Constant
    {
        public string Passage = "http://alkitab.sabda.org/api/passage.php?passage={0}";
        public string PassageUntil = "http://alkitab.sabda.org/api/passage.php?passage={passage}+{chapter}-{chapterIncrement}";
        public string PassageVerse = "http://alkitab.sabda.org/api/passage.php?passage={passage}+{chapter}:{verse}";
        public string PassageVerseUntil = "http://alkitab.sabda.org/api/passage.php?passage={passage}+{chapter}:{verse}-{verseIncrement}";
    }
}

