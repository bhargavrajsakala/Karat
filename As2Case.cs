

CASE STUDY 2 Custom Linked List + Stack for Undo/Redo System

**Concepts:** Custom LinkedList, Stack, navigating nodes
**Theme:** Text editor undo/redo functionality

Requirements

Implement a simple text editor model where:

* A **custom singly linked list** stores text history snapshots.
* An **Undo stack** and **Redo stack** manage navigation.
* When text changes:

  * Push previous state onto **Undo Stack**
* On Undo:

  * Pop from Undo, push current state to Redo
* On Redo:

  * Pop from Redo, restore state

Complete missing parts in the code.


```csharp
// Custom node-based linked list for tracking text states
public class TextNode
{
    public string State;
    public TextNode Next;
}

public class TextHistory
{
    public TextNode Head;

    public void AddState(string state)
    {
        // TODO: append node at end
    }

    public TextNode GetLatest()
    {
        // TODO: return last node in list
        return null;
    }
}

public class Editor
{
    private TextHistory _history = new TextHistory();
    private Stack<string> _undoStack = new Stack<string>();
    private Stack<string> _redoStack = new Stack<string>();
    private string _currentText = "";

    public void Type(string newText)
    {
        // TODO: push current text to undo stack
        // TODO: update text, add to history
    }

    public void Undo()
    {
        // TODO: move current state to redo, restore from undo
    }

    public void Redo()
    {
        // TODO: move current state to undo, restore from redo
    }

    public void Print()
    {
        Console.WriteLine("Current text: " + _currentText);
    }
}

class Program
{
    static void Main()
    {
        var editor = new Editor();

        editor.Type("Hello");
        editor.Type("Hello World");

        editor.Undo(); // Should go back to "Hello"
        editor.Redo(); // Should go to "Hello World"

        // TODO: print final text
    }
}
```

