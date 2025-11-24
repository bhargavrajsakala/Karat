

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

code :
using System;
using System.Collections.Generic;

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
        var newNode = new TextNode { State = state, Next = null };

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            TextNode current = Head;
            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }
    }

    public TextNode GetLatest()
    {
        if (Head == null)
            return null;

        TextNode current = Head;
        while (current.Next != null)
            current = current.Next;

        return current;
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
        // Push current text to undo stack before changing
        _undoStack.Push(_currentText);

        // Update current text
        _currentText = newText;

        // Add new state to history
        _history.AddState(_currentText);

        // Clear redo stack because new typing invalidates redo states
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count == 0)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        // Push current state to redo stack
        _redoStack.Push(_currentText);

        // Pop from undo stack and restore it
        _currentText = _undoStack.Pop();

        // Add restored state to history
        _history.AddState(_currentText);
    }

    public void Redo()
    {
        if (_redoStack.Count == 0)
        {
            Console.WriteLine("Nothing to redo.");
            return;
        }

        // Push current state to undo stack
        _undoStack.Push(_currentText);

        // Pop from redo stack and restore it
        _currentText = _redoStack.Pop();

        // Add restored state to history
        _history.AddState(_currentText);
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
        editor.Print();

        editor.Redo(); // Should go to "Hello World"
        editor.Print();

        // Final text print
        editor.Print();
    }
}


