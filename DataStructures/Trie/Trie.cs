namespace DS;

public class TrieImplementation
{
    public class TrieNode
    {
        public char Letter { get; set; }
        public bool IsWord { get; set; }
        public TrieNode[] Children = new TrieNode[27]; // 26 alphabets in english (case-insensitive)

        public TrieNode(char letter, bool isWord = false)
        {
            this.Letter = letter;
            this.IsWord = isWord;
        }
    }

    public TrieNode Root { get; set; }

    public TrieImplementation()
    {
        Root = new TrieNode('*'); // indicates beginning of the string
    }

    public void Insert(string word)
    {
        TrieNode currentNode = Root;

        foreach (char c in word)
        {
            if (currentNode == null)
                return; // don't know when that will happen

            TrieNode? nextLetter = currentNode.Children[GetASCIIOffset(c)]; // can optimize this; fall-through child creation

            if (nextLetter == null)
            {
                currentNode.Children[GetASCIIOffset(c)] = new TrieNode(c);
                nextLetter = currentNode.Children[GetASCIIOffset(c)];
            }

            currentNode = nextLetter; // traverse through existing structure
        }

        // now, currentNode will always point to last letter
        currentNode.IsWord = true;
    }

    public void Delete()
    {
        // TODO
    }

    public void DFS(TrieNode root, string runningWord = "")
    {
        if (root == null)
        {
            return;
        }

        runningWord += root.Letter;

        if (root.IsWord)
        {
            Console.WriteLine(runningWord);
        }

        for (int i = 0; i < 27; i++)
        {
            DFS(root.Children[i], runningWord);
        }
    }

    public TrieNode? GetLastLetterNode(string word)
    {
        // get index using ASCII method
        int currentPosition = 0;
        TrieNode currentNode = Root;

        while (currentPosition < word.Length && HasChildLetter(currentNode, word[currentPosition]))
        {
            currentNode = currentNode.Children[GetASCIIOffset(word[currentPosition])];
            currentPosition++;
        }

        return currentPosition == word.Length ? currentNode : null;
    }

    public void GetAutoCompleteText(string word)
    {
        if (word.Length == 0) return;

        // transform word to lowercase
        word = word.ToLower();

        TrieNode? lastLetterNode = GetLastLetterNode(word); // meth: m -> e -> t -> h

        if (lastLetterNode != null)
        {
            DFS(lastLetterNode, word.Substring(0, word.Length - 1));
        }
        else
            Console.WriteLine("No possible words found in the trie");
    }

    private static int GetASCIIOffset(char c) => c - 97 > 0 ? c - 97 : 26;

    private static bool HasChildLetter(TrieNode parent, char c) => parent.Children[GetASCIIOffset(c)] != null;
}

public static class Trie
{
    public static void Begin()
    {
        TrieImplementation trie = new();
        trie.Insert("methran");
        trie.Insert("metro");
        trie.Insert("metal");
        trie.Insert("methamphetamine"); // fixed spelling & letters-only
        trie.Insert("method");
        trie.Insert("metaverse");
        trie.Insert("metroid");
        trie.Insert("metropolitan");

        trie.Insert("how to get rich quick");
        trie.Insert("how to get super smart");
        trie.Insert("how to become rich");
        trie.Insert("how to develop myself");
        trie.Insert("how to write hello world in c");

        string input = "";
        Console.Clear();


        while (true)
        {
            ConsoleKey current = Console.ReadKey().Key;
            if (current == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                    input = input.Substring(0, input.Length - 1);
            }
            else
            {
                input += (char)current;
            }

            Console.Clear();

            string searchEngineInput = input;
            Console.WriteLine($"\"{searchEngineInput}\" suggestions:");
            trie.GetAutoCompleteText(searchEngineInput);
        }
    }
}
