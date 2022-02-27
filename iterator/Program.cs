using System.Collections;

var collection = new WordsCollection();
collection.AddItem("First");
collection.AddItem("Second");
collection.AddItem("Third");

Console.WriteLine("Straight traversal:");

foreach (var element in collection)
{
    Console.WriteLine(element);
}

Console.WriteLine("\nReverse traversal:");

collection.ReverseDirection();

foreach (var element in collection)
{
    Console.WriteLine(element);
}




abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    public abstract int Key();
    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();

}

abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

class AlphabeticalOrderIterator : Iterator
{
    private int _position = -1;
    private bool _reverse = false;

    private WordsCollection _collection;

    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        _collection = collection;
        _reverse = reverse;

        if (reverse)
        {
            _position = collection.GetItems().Count;
        }
    }

    public override object Current()=>_collection.GetItems()[_position];
    

    public override int Key()=>_position;

    public override bool MoveNext()
    {
        int updatedPosition = _position + (_reverse ? -1 : 1);
        if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
        {
            _position = updatedPosition;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()=>_position = _reverse ? _collection.GetItems().Count - 1 : 0;



    
}
class WordsCollection : IteratorAggregate
{
    List<string> _collection = new List<string>();

    bool _direction = false;

    public List<string> GetItems() => _collection;

    public void AddItem(string item) => _collection.Add(item);

    public override IEnumerator GetEnumerator() => new AlphabeticalOrderIterator(this, _direction);
    public void ReverseDirection()=>_direction=!_direction;

}