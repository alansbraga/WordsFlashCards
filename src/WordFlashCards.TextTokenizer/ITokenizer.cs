using System.Collections.Generic;

namespace WordFlashCards.TextTokenizer
{
    public interface ITokenizer
    {
        int CurrentIndex { get; set; }
        List<Token> Tokens { get; set; }

        string CurrentLine();
        Token CurrentToken();
        Token NextToken();
        Token QueryToken(int offSet, bool ignoreSpaces);
        bool TestTokens(params string[] lista);
        bool TestTokens(bool ignoreSpaces, params string[] list);
    }
}